using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cosmos.Framework;
using Cosmos.Website.Recursos.Utilerias;


namespace Cosmos.Website.Recursos.UserControls
{
    public partial class ucSeleccionEmpresa : System.Web.UI.UserControl
    {
        protected string ImagenLogo(int id)
        {
            string imgURL = string.Format("~/Recursos/Imagenes/Empresa/{0}.png", id.ToString());
            if (!File.Exists(Server.MapPath(imgURL)))
            {
                imgURL = "~/Recursos/Imagenes/Empresa/NoEncontrado.png";
            }
            return imgURL;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Cosmos.Seguridad.Entidades.Empresa> empresas = Cosmos.Seguridad.Api.Client.Usuario.ListadoEmpresas();
                if (empresas.Count>0)
                {
                        DataList1.DataSource = empresas;
                        DataList1.DataBind();
                }
                else
                {
                    //el usuario no tiene empresas, sacalo del sistema
                    AppGlobals.MotivoLogout = "El usuario no tiene empresas asignadas, la sesión ha sido terminada.";
                    Response.Redirect("~/Cuenta/Logout.aspx");
                }
            }
        }
        protected void imgLogo_Click(object sender, ImageClickEventArgs e)
        {
            int empresaID = CastHelper.CInt2(((ImageButton)sender).CommandArgument);
            if (empresaID > 0)
            {
                AppGlobals.EmpresaID = empresaID;
                AppGlobals.ModuloID = 0;
                Response.Redirect("~/Sistema/Default.aspx");
            }
        }
    }
}