using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Cosmos.Website.Recursos.Utilerias;
using Newtonsoft.Json;

namespace Cosmos.Website.Recursos.UserControls
{
    public partial class ucSeleccionaModulo : System.Web.UI.UserControl
    {
        protected string ImagenLogo(int id)
        {
            string imgURL = string.Format("~/Recursos/Imagenes/Modulo/{0}.png", id.ToString());
            if (!File.Exists(Server.MapPath(imgURL)))
            {
                imgURL = "~/Recursos/Imagenes/Modulo/NoEncontrado.png";
            }
            return imgURL;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                List<Cosmos.Seguridad.Entidades.Modulo> modulos = Cosmos.Seguridad.Api.Client.Usuario.ListadoModulos();
                if (modulos.Count>0)
                {
                    DataList1.DataSource = modulos;
                    DataList1.DataBind();
                }
                else
                {
                    AppGlobals.MotivoLogout = "El usuario no tiene módulos asignados, la sesión ha sido terminada.";
                    //el usuario no tiene modulos, sacalo del sistema
                    Response.Redirect("~/Cuenta/Logout.aspx");
                }
            }
        }
        protected void imgLogo_Click(object sender, ImageClickEventArgs e)
        {
            int moduloID = CastHelper.CInt2(((ImageButton)sender).CommandArgument);
            if (moduloID > 0)
            {
                AppGlobals.ModuloID = moduloID;
                Response.Redirect("~/Sistema/Default.aspx");
            }
        }
    }
}