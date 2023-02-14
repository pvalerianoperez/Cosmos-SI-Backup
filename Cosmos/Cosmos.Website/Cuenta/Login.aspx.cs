using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using Newtonsoft.Json;

namespace Cosmos.Website.Cuenta
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            RespuestaBase respuesta;
            lblError.Text = "";
            respuesta = Cosmos.Seguridad.Api.Client.Usuario.IniciarSesion(txtCorreoElectronico.Text, txtContrasena.Text);
            if (respuesta.Exitoso)
            {
                //carga los datos del usuario, ultima empresa seleccionada, ultimo modulo seleccionado
                AppGlobals.UsuarioID = respuesta.UsuarioID;
                List<Cosmos.Seguridad.Entidades.Usuario> lst = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (lst.Count > 0) {
                    AppGlobals.EmpresaID = lst[0].UltimaEmpresaID;
                    AppGlobals.ModuloID = lst[0].UltimoModuloID;
                }
                Response.Redirect("~/Sistema/Default.aspx");                
            }
            else {
                lblError.Text = respuesta.MensajeError;
            }
        }
    }
}