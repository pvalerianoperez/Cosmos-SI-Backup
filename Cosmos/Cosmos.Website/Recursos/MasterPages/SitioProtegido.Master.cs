using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using System.Web.UI.HtmlControls;
using Cosmos.Seguridad.Entidades;
using Cosmos.Framework;
using Cosmos.Utilerias;
using DevExpress.Web;

namespace Cosmos.Website.Recursos.MasterPages
{
    public partial class SitioProtegido : System.Web.UI.MasterPage
    {
        private bool HideNavigation() {
            return CastHelper.CStr2(Request.QueryString["hidenavigation"]).Trim() == "1";
        }
        protected void Page_Init(object sender, EventArgs e)
        {

            Cosmos.Framework.APIHelper.APIURL = Properties.Settings.Default.ApiURL;
            Cosmos.Framework.APIHelper.APIEmpresaID = AppGlobals.EmpresaID;
            Cosmos.Framework.APIHelper.APIModuloID = AppGlobals.ModuloID;
            Cosmos.Framework.APIHelper.APISesionID = AppGlobals.SesionID;
            Cosmos.Framework.APIHelper.APIUsuarioID = AppGlobals.UsuarioID;

            if (!IsPostBack) {
                string path = HttpContext.Current.Request.Url.AbsolutePath;

                if (AppGlobals.UsuarioID == 0)
                {
                    Response.Redirect("~/Cuenta/Login.aspx");
                }                
                if (AppGlobals.EmpresaID == 0)
                {
                    if (!path.ToLower().EndsWith("seleccionempresa.aspx"))
                    {
                        Response.Redirect("~/Sistema/SeleccionEmpresa.aspx");
                    }                    
                }
                if (AppGlobals.ModuloID == 0)
                {
                    if (!path.ToLower().EndsWith("seleccionmodulo.aspx"))
                    {
                        Response.Redirect("~/Sistema/SeleccionModulo.aspx");
                    }
                }                
            }

            AgregaCss("~/Recursos/Css/Sitio.css");
            AgregaCss("~/Recursos/Css/sweetalert.css");
            AgregaScript("~/scripts/jquery-3.3.1.js");
            AgregaScript("~/scripts/sweetalert.min.js");
        }

        private void AgregaCss(string url) {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            link.Href = Page.ResolveUrl(url);
            Page.Header.Controls.Add(link);
        }
        private void AgregaScript(string url)
        {
            LiteralControl literal = new LiteralControl();
            literal.Text = string.Format("<script src=\"{0}\"></script>", Page.ResolveUrl(url));
            Page.Header.Controls.Add(literal);
        }

        protected void CargaMenu(ref List<Cosmos.Seguridad.Entidades.OpcionListado> opciones, ref DevExpress.Web.MenuItem padre, int padreID = 0) {
                        
            List<Cosmos.Seguridad.Entidades.OpcionListado> opcionesModulo = opciones.Where(o => o.ModuloID == AppGlobals.ModuloID && o.OpcionID!=0 && o.PadreID == padreID).ToList();            
            foreach (Cosmos.Seguridad.Entidades.OpcionListado item in opcionesModulo)
            {
                if (item.Activo && item.VisibleMenu) {
                    //carga las opciones del modulo
                    DevExpress.Web.MenuItem mi = new DevExpress.Web.MenuItem();
                    mi.Text = item.Nombre;
                    mi.NavigateUrl = item.RecursoWebsite;
                    CargaMenu(ref opciones, ref mi, item.OpcionID);
                    if (padre != null)
                    {
                        padre.Items.Add(mi);
                    }
                }                                
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RespuestaBase respuesta;

                
                if (HideNavigation()) {
                    this.ASPxMenu1.Visible = false;
                    this.ASPxMenu2.Visible = false;
                    this.hlLogo.Visible = false;
                    this.divEncabezado.Visible = false;                    
                }else{
                    //este bloque solo aplica mientras no se haya especificado que se oculte el menu                
                    this.ASPxMenu1.Visible = true;
                    this.ASPxMenu2.Visible = true;
                    this.hlLogo.Visible = true;

                    //carga el menu
                    this.ASPxMenu1.Items.Clear();

                    //agrega la primera opcion (seleccion del modulo)
                    DevExpress.Web.MenuItem mSeleccionaModulo = new DevExpress.Web.MenuItem();
                    mSeleccionaModulo.Text = "Sistema";
                    mSeleccionaModulo.Image.Url = "~/Recursos/Imagenes/Menu/mnSistema.png";
                    mSeleccionaModulo.Name = "mnSistema";
                    ASPxMenu1.Items.Add(mSeleccionaModulo);

                    //construye el menu
                    List<Cosmos.Seguridad.Entidades.OpcionListado> opciones =  Cosmos.Seguridad.Api.Client.Usuario.ListadoOpciones(AppGlobals.UsuarioID, AppGlobals.EmpresaID, AppGlobals.ModuloID);
                    if (opciones.Count > 0)
                    {
                        List<Cosmos.Seguridad.Entidades.OpcionListado> opcionesModulo = opciones.Where(o => o.ModuloID == AppGlobals.ModuloID && o.OpcionID != 0 && o.PadreID == 0).ToList();
                        foreach (OpcionListado item in opcionesModulo)
                        {
                            //carga las opciones del modulo
                            if (item.Activo && item.VisibleMenu) {
                                DevExpress.Web.MenuItem mi = new DevExpress.Web.MenuItem();
                                mi.Text = item.Nombre;
                                mi.NavigateUrl = item.RecursoWebsite;
                                CargaMenu(ref opciones, ref mi, item.OpcionID);
                                this.ASPxMenu1.Items.Add(mi);
                            }
                            
                        }
                    }

                    //cual es el usuario actual?
                    Usuario usuario = Cosmos.Seguridad.Api.Client.Usuario.Consultar(AppGlobals.UsuarioID);
                    if (usuario != null)
                    {
                        ASPxMenu2.Items[0].Text = usuario.Nombre;
                    }
                    else
                    {
                        Response.Redirect("~/Cuenta/Logout.aspx");
                    }

                    //cual es la empresa actual?                
                    Empresa empresa = Cosmos.Seguridad.Api.Client.Empresa.Consultar(AppGlobals.EmpresaID);
                    if (empresa != null)
                    {
                        ASPxMenu2.Items[1].Text = empresa.Nombre;
                    }
                    else
                    {
                        ASPxMenu2.Items[1].Visible = false;
                    }

                    //cual es el modulo actual?
                    Modulo modulo = Cosmos.Seguridad.Api.Client.Modulo.Consultar(AppGlobals.ModuloID);
                    if (modulo != null)
                    {

                        ASPxMenu2.Items[2].Text = modulo.Nombre;
                    }
                    else
                    {
                        ASPxMenu2.Items[2].Visible = false;
                    }
                }

                // tiene permisos para el recurso actual???                
                string urlActual = HttpContext.Current.Request.Url.AbsolutePath;
                List<Cosmos.Seguridad.Entidades.OpcionListado> opcionesAcciones = Cosmos.Seguridad.Api.Client.Usuario.ListadoAcciones(AppGlobals.UsuarioID, AppGlobals.EmpresaID, AppGlobals.ModuloID, urlActual);               
                if (opcionesAcciones.Count > 0)
                {
                    foreach (string s in opcionesAcciones[0].AccionesPermitidas)
                    {
                        hfAcciones[s] = "1";
                    }
                }
                else
                {
                    //no se encontraron registros, no tiene permiso para entrar a este recurso...
                    if (!urlActual.ToLower().EndsWith("sistema/default.aspx")) {
                        //Response.Redirect("~/Sistema/Default.aspx");
                    }                    
                }                                            
            }
        }

        //public ASPxHiddenField Acciones() {
        //    return hfAcciones;
        //}

        public bool PermisoAccion(string accion)
        {
            string opcionesAcciones = CastHelper.CStr2(ViewState["OpcionesAcciones"]);
            //ASPxHiddenField hfAcciones = ((Cosmos.Website.Recursos.MasterPages.SitioProtegido)Page.Master).Acciones();
            return (Funciones.GetControlValue(hfAcciones, accion)).Equals("1");
        }

        public UserControls.ucMenuAcciones MenuAcciones() {
            return this.ucMenuAcciones1;
        }


    }
}