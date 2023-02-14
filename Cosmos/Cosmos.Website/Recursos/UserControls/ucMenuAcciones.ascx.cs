using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cosmos.Api.Entidades;
using Cosmos.Seguridad.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using Newtonsoft.Json;

namespace Cosmos.Website.Recursos.UserControls
{
    public partial class ucMenuAcciones : System.Web.UI.UserControl
    {
        public DevExpress.Web.MenuItem mnAgregar
        {
            get {
                return ASPxMenu3.Items[0];
            }
            set {
            }
        }

        public DevExpress.Web.MenuItem mnModificar
        {
            get
            {
                return ASPxMenu3.Items[1];
            }
            set {
            }
        }
        public DevExpress.Web.MenuItem mnEliminar
        {
            get
            {
                return ASPxMenu3.Items[2];
            }
            set {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                // tiene permisos para el recurso actual???                
                SolicitudBase solicitud = new SolicitudBase();
                string urlActual = HttpContext.Current.Request.Url.AbsolutePath;
                List<OpcionListado> opcionesAcciones = Cosmos.Seguridad.Api.Client.Usuario.ListadoAcciones(AppGlobals.UsuarioID, AppGlobals.EmpresaID, AppGlobals.ModuloID, urlActual);                
                if (opcionesAcciones.Count > 0)
                {
                    for (int i = 0; i < ASPxMenu3.Items.Count; i++)
                    {
                        ASPxMenu3.Items[i].Visible = false;
                        //ASPxMenu3.Items[i].Enabled = false;
                    }
                    string[] datosMigaja = opcionesAcciones[0].Migaja.Split('>');
                    if (datosMigaja.Length > 1)
                    {
                        lblMigaja.Text = opcionesAcciones[0].Migaja.Replace(datosMigaja[datosMigaja.Length-1], "").Trim();
                        lblMigajaUbicacionActual.Text = datosMigaja[datosMigaja.Length - 1].Trim();
                    }
                    else {
                        lblMigaja.Text = opcionesAcciones[0].Migaja;
                    }
                    
                    //tiene permiso para entrar al recurso...
                    foreach (OpcionListado o in opcionesAcciones)
                    {
                        foreach (string accion in o.AccionesDisponibles)
                        {
                            switch (accion.ToUpper()) {
                                case "AGREGAR":
                                    //ASPxMenu3.Items[0].Visible = true;
                                    ASPxMenu3.Items[0].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "MODIFICAR":
                                    //ASPxMenu3.Items[1].Visible = true;
                                    //ASPxMenu3.Items[1].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "ELIMINAR":
                                    //ASPxMenu3.Items[2].Visible = true;
                                    //ASPxMenu3.Items[2].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "IMPRIMIR":
                                    //ASPxMenu3.Items[3].Visible = true;
                                    ASPxMenu3.Items[3].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "EXPORTAR_PDF":
                                    //ASPxMenu3.Items[4].Visible = true;
                                    ASPxMenu3.Items[4].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "EXPORTAR_EXCEL":
                                    //ASPxMenu3.Items[5].Visible = true;
                                    ASPxMenu3.Items[5].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "AUTORIZAR":
                                    //ASPxMenu3.Items[6].Visible = true;
                                    ASPxMenu3.Items[6].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                                case "CANCELAR":
                                    //ASPxMenu3.Items[7].Visible = true;
                                    ASPxMenu3.Items[7].Visible = (o.AccionesPermitidas.ToList().IndexOf(accion) >= 0);
                                    break;
                            }
                        }
                        //foreach (string accion in o.AccionesPermitidas)
                        //{
                        //    switch (accion.ToUpper())
                        //    {
                        //        case "AGREGAR":
                        //            ASPxMenu3.Items[0].Enabled = true;
                        //            break;
                        //        case "MODIFICAR":
                        //            ASPxMenu3.Items[1].Enabled = true;
                        //            break;
                        //        case "ELIMINAR":
                        //            ASPxMenu3.Items[2].Enabled = true;
                        //            break;
                        //        case "IMPRIMIR":
                        //            ASPxMenu3.Items[3].Enabled = true;
                        //            break;
                        //        case "EXPORTAR_PDF":
                        //            ASPxMenu3.Items[4].Enabled = true;
                        //            break;
                        //        case "EXPORTAR_EXCEL":
                        //            ASPxMenu3.Items[5].Enabled = true;
                        //            break;
                        //        case "AUTORIZAR":
                        //            ASPxMenu3.Items[6].Enabled = true;
                        //            break;
                        //        case "CANCELAR":
                        //            ASPxMenu3.Items[7].Visible = true;
                        //            break;
                        //    }
                        //}
                    }
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}