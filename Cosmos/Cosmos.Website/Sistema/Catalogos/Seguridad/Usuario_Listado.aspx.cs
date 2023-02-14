


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using DevExpress.Web;
using Newtonsoft.Json;
using Cosmos.Framework;

namespace Cosmos.Website.Sistema.Catalogos.Seguridad
{
    public partial class Usuario_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaUsuario_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaUsuario_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioID"]);
                string correoElectronico = CastHelper.CStr2(e.InsertValues[i].NewValues["CorreoElectronico"]);
                string contrasena = CastHelper.CStr2(e.InsertValues[i].NewValues["Contrasena"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string alias = CastHelper.CStr2(e.InsertValues[i].NewValues["Alias"]);
                bool activo = CastHelper.CBool2(e.InsertValues[i].NewValues["Activo"]);
                int intentos = CastHelper.CInt2(e.InsertValues[i].NewValues["Intentos"]);
                bool bloqueado = CastHelper.CBool2(e.InsertValues[i].NewValues["Bloqueado"]);
                string usuarioAD = CastHelper.CStr2(e.InsertValues[i].NewValues["UsuarioAD"]);
                bool administrador = CastHelper.CBool2(e.InsertValues[i].NewValues["Administrador"]);
                DateTime ultimoAcceso =  CastHelper.CDate2(e.InsertValues[i].NewValues["UltimoAcceso"]);
                int ultimaEmpresaID = CastHelper.CInt2(e.InsertValues[i].NewValues["UltimaEmpresaID"]);
                int ultimoModuloID = CastHelper.CInt2(e.InsertValues[i].NewValues["UltimoModuloID"]);
                int ultimaOpcionID = CastHelper.CInt2(e.InsertValues[i].NewValues["UltimaOpcionID"]);
                string ultimaIP = CastHelper.CStr2(e.InsertValues[i].NewValues["UltimaIP"]);
                Cosmos.Seguridad.Api.Client.Usuario.Guardar(usuarioID, correoElectronico, nombre, alias, activo, intentos, bloqueado, usuarioAD, administrador, ultimoAcceso, ultimaEmpresaID, ultimoModuloID, ultimaOpcionID, ultimaIP);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UsuarioID"]);
                string correoElectronico = CastHelper.CStr2(e.UpdateValues[i].NewValues["CorreoElectronico"]);
                string contrasena = CastHelper.CStr2(e.UpdateValues[i].NewValues["Contrasena"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string alias = CastHelper.CStr2(e.UpdateValues[i].NewValues["Alias"]);
                bool activo = CastHelper.CBool2(e.UpdateValues[i].NewValues["Activo"]);
                int intentos = CastHelper.CInt2(e.UpdateValues[i].NewValues["Intentos"]);
                bool bloqueado = CastHelper.CBool2(e.UpdateValues[i].NewValues["Bloqueado"]);
                string usuarioAD = CastHelper.CStr2(e.UpdateValues[i].NewValues["UsuarioAD"]);
                bool administrador = CastHelper.CBool2(e.UpdateValues[i].NewValues["Administrador"]);
                DateTime ultimoAcceso =  CastHelper.CDate2(e.UpdateValues[i].NewValues["UltimoAcceso"]);
                int ultimaEmpresaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UltimaEmpresaID"]);
                int ultimoModuloID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UltimoModuloID"]);
                int ultimaOpcionID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UltimaOpcionID"]);
                string ultimaIP = CastHelper.CStr2(e.UpdateValues[i].NewValues["UltimaIP"]);
                Cosmos.Seguridad.Api.Client.Usuario.Guardar(usuarioID, correoElectronico, nombre, alias, activo, intentos, bloqueado, usuarioAD, administrador, ultimoAcceso, ultimaEmpresaID, ultimoModuloID, ultimaOpcionID, ultimaIP);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(e.DeleteValues[i].Values["UsuarioID"]);
                Cosmos.Seguridad.Api.Client.Usuario.Eliminar(usuarioID);
            }
            e.Handled = true;
            Grid.DataBind();

        }

        protected void cbpEditar_Callback(object sender, CallbackEventArgsBase e)
        {
            cbpEditar.JSProperties["cp_refresh"] = "";
            cbpEditar.JSProperties["cp_show"] = "";
            cbpEditar.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] p = e.Parameter.Split('|');
                int id = 0;
                if (p.Length > 1) { id = CastHelper.CInt2(p[1]); }
                switch (p[0])
                {
                    case "NUEVO":
                        hfID.Value = "0";
                        Session["Usuario_Listado_UsuarioID"] = id;
                        flEditar.DataBind();
                        txtNombre.Text = "";
                        txtAlias.Text = "";
                        txtCorreoElectronico.Text = "";
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        break;
                    case "EDITAR":
                        hfID.Value = id.ToString();
                        Session["Usuario_Listado_UsuarioID"] = id;
                        flEditar.DataBind();
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        break;
                    case "ELIMINAR":
                        Session["Usuario_Listado_UsuarioID"] = id;
                        try
                        {
                            if (id > 0)
                            {
                                Cosmos.Seguridad.Api.Client.Usuario.Eliminar(id);
                            }
                            cbpEditar.JSProperties["cp_show"] = 0;
                            cbpEditar.JSProperties["cp_refresh"] = 1;
                        }
                        catch (Exception ex)
                        {
                            cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
                            cbpEditar.JSProperties["cp_show"] = 0;
                            cbpEditar.JSProperties["cp_refresh"] = 0;
                        }
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Usuario_Listado_UsuarioID"]);
                        //Session["Usuario_Listado_UsuarioID"] = id;
                        Cosmos.Seguridad.Entidades.Usuario oUsuario = Cosmos.Seguridad.Api.Client.Usuario.Consultar(id);
                        if (oUsuario == null) { oUsuario = new Cosmos.Seguridad.Entidades.Usuario(); }
                        oUsuario.Nombre = txtNombre.Text;
                        oUsuario.CorreoElectronico = txtCorreoElectronico.Text;
                        oUsuario.Alias = txtAlias.Text;
                        oUsuario.Activo = chkActivo.Checked;
                        oUsuario.Bloqueado = chkBloqueado.Checked;
                        string contrasena = CastHelper.CStr2(txtContrasena.Text).Trim();
                        string contrasenaConfirmacion = CastHelper.CStr2(txtContrasenaConfirmacion.Text).Trim();
                        bool actualizaContrasena = false;
                        if (contrasena != "")
                        {
                            if (contrasena == contrasenaConfirmacion)
                            {
                                actualizaContrasena = true;
                            }
                            else
                            {
                                throw new Exception("La contraseña y su confirmación no coinciden.");
                            }
                        }

                        oUsuario.Contrasena = txtContrasena.Text;
                        Cosmos.Seguridad.Entidades.Usuario resultado = Cosmos.Seguridad.Api.Client.Usuario.Guardar(id, oUsuario.CorreoElectronico, txtNombre.Text, txtAlias.Text,
                            chkActivo.Checked, oUsuario.Intentos, chkBloqueado.Checked, oUsuario.UsuarioAD, chkAdministrador.Checked, oUsuario.UltimoAcceso,
                            oUsuario.UltimaEmpresaID, oUsuario.UltimoModuloID, oUsuario.UltimaOpcionID, oUsuario.UltimaIP);

                        Session["Usuario_Listado_UsuarioID"] = resultado.UsuarioID;

                        if (actualizaContrasena) {
                            Cosmos.Seguridad.Api.Client.Usuario.ActualizaContrasena(resultado.UsuarioID, contrasena);
                        }

                        //gvPerfiles.UpdateEdit();

                        cbpEditar.JSProperties["cp_show"] = 0;
                        cbpEditar.JSProperties["cp_refresh"] = 1;
                        break;

                }
            }
            catch (Exception ex) {
                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarPerfiles_Callback(object sender, CallbackEventArgsBase e)
        {
            cbpEditarPerfiles.JSProperties["cp_refresh"] = "";
            cbpEditarPerfiles.JSProperties["cp_show"] = "";
            cbpEditarPerfiles.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] p = e.Parameter.Split('|');
                int id = 0;
                if (p.Length > 1) { id = CastHelper.CInt2(p[1]); }
                switch (p[0])
                {
                    case "EDITAR":
                        hfPerfilesID.Value = id.ToString();                        
                        Session["Usuario_Listado_UsuarioID"] = id;
                        gvPerfiles.DataBind();
                        cbpEditarPerfiles.JSProperties["cp_show"] = 1;
                        cbpEditarPerfiles.JSProperties["cp_refresh"] = 0;
                        break;                    
                }
            }
            catch (Exception ex)
            {
                cbpEditarPerfiles.JSProperties["cp_errorMessage"] = ex.Message;
            }


        }

        protected void gvPerfiles_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            string usuarioID = CastHelper.CInt2(Session["Usuario_Listado_UsuarioID"]).ToString();
            string perfilID = "0";
            string empresaID = "0";
            e.NewValues["CompositeKey"] = string.Format("{0}_{1}_{2}", usuarioID, perfilID, empresaID);
            e.NewValues["UsuarioID"] = usuarioID;            
        }

     
        protected void gvPerfiles_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(Session["Usuario_Listado_UsuarioID"]);
                int perfilID = CastHelper.CInt2(e.InsertValues[i].NewValues["PerfilID"]);
                int empresaID = CastHelper.CInt2(e.InsertValues[i].NewValues["EmpresaID"]);
                Cosmos.Seguridad.Api.Client.UsuarioPerfil.Guardar(usuarioID, perfilID, empresaID);                
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(Session["Usuario_Listado_UsuarioID"]);
                int perfilID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PerfilID"]);
                int empresaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["EmpresaID"]);
                Cosmos.Seguridad.Api.Client.UsuarioPerfil.Guardar(usuarioID, perfilID, empresaID);                
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int usuarioID = CastHelper.CInt2(Session["Usuario_Listado_UsuarioID"]);
                int perfilID = CastHelper.CInt2(e.DeleteValues[i].Values["PerfilID"]);
                int empresaID = CastHelper.CInt2(e.DeleteValues[i].Values["EmpresaID"]);
                Cosmos.Seguridad.Api.Client.UsuarioPerfil.Eliminar(usuarioID, perfilID, empresaID);
            }
            e.Handled = true;
            Grid.DataBind();
        }


        protected void Grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh") {
                Grid.DataBind();
            }
        }
    }
}
