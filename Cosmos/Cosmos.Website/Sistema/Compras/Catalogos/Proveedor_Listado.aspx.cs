


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

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Proveedor_Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Proveedor_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Proveedor_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }
        }


        protected void Grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }

            switch (accion)
            {
                case "REFRESH":
                    ((ASPxGridView)sender).DataBind();
                    break;
                case "CLEAR":
                    ((ASPxGridView)sender).DataSource = null;
                    ((ASPxGridView)sender).DataBind();
                    break;
                case "ELIMINAR":
                    //eliminar
                    break;
            }
        }

        protected void cbpEditar_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditar.JSProperties["cp_refresh"] = "";
            cbpEditar.JSProperties["cp_show"] = "";
            cbpEditar.JSProperties["cp_errorMessage"] = "";
            cbpEditar.JSProperties["cp_HabilitaCapturaTipoPersona"] = "";
            cbpEditar.JSProperties["cp_HabilitaDetalleCasado"] = "";
            try {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                switch (accion)
                {
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        try{
                            Cosmos.Compras.Api.Client.Proveedor.Eliminar(id);
                            cbpEditar.JSProperties["cp_show"] = 0;
                            cbpEditar.JSProperties["cp_refresh"] = 1;
                        }
                        catch (Exception ex) {
                            cbpEditar.JSProperties["cp_show"] = 0;
                            cbpEditar.JSProperties["cp_refresh"] = 0;
                            cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
                        }
                        break;
                    case "EDITAR":                        
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                        txtRFC.Text = "";
                        txtRazonSocial.Text = "";
                        txtNombreComercial.Text = "";
                        txtNombreCorto.Text = "";
                        ddlTipoPersona.SelectedItem = ddlTipoPersona.Items.FindByValue("F");
                        txtNombres.Text = "";
                        txtApellidoPaterno.Text = "";
                        txtApellidoMaterno.Text = "";
                        txtSobrenombre.Text = "";
                        txtIniciales.Text = "";
                        txtFechaNacimiento.Text = "";
                        ddlSexoID.SelectedIndex = -1;
                        ddlEstadoCivilID.SelectedIndex = -1;
                        ddlTipoProveedorID.SelectedIndex = -1;
                        ddlGiroEmpresaID.SelectedIndex = -1;
                        ddlMedioContactoID.SelectedIndex = -1;
                        ddlVinculoID.SelectedIndex = -1;
                        gridTelefonos.DataSource = null;
                        gridTelefonos.DataBind();
                        gridDomicilios.DataSource = null;
                        gridDomicilios.DataBind();
                        gridTelefonos.DataSource = null;
                        gridTelefonos.DataBind();
                        gridRepresentantes.DataSource = null;
                        gridRepresentantes.DataBind();
                        if (id > 0)
                        {
                            Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                            if (proveedor != null)
                            {
                                txtRFC.Text = proveedor.RFC;
                                txtRazonSocial.Text = proveedor.RazonSocial;
                                txtNombreComercial.Text = proveedor.NombreComercial;
                                ddlTipoPersona.SelectedItem = ddlTipoPersona.Items.FindByValue(proveedor.FisicaMoral);
                                txtNombres.Text = proveedor.Nombre;
                                txtApellidoPaterno.Text = proveedor.ApellidoPaterno;
                                txtApellidoMaterno.Text = proveedor.ApellidoMaterno;
                                txtSobrenombre.Text = proveedor.SobreNombre;
                                txtIniciales.Text = proveedor.Iniciales;
                                txtFechaNacimiento.Date = proveedor.FechaNacimiento;
                                ddlSexoID.SelectedItem = ddlSexoID.Items.FindByValue(proveedor.SexoID);
                                ddlEstadoCivilID.SelectedItem = ddlEstadoCivilID.Items.FindByValue(proveedor.EstadoCivilID);
                                ddlTipoProveedorID.SelectedItem = ddlTipoProveedorID.Items.FindByValue(proveedor.TipoProveedorID);
                                ddlGiroEmpresaID.SelectedItem = ddlGiroEmpresaID.Items.FindByValue(proveedor.GiroEmpresaID);
                                ddlMedioContactoID.SelectedItem = ddlMedioContactoID.Items.FindByValue(proveedor.MedioContactoID);
                                ddlVinculoID.SelectedItem = ddlVinculoID.Items.FindByValue(proveedor.VinculoID);
                                txtCURP.Text = proveedor.CURP;
                                txtNombreCorto.Text = proveedor.NombreCorto;
                                gridDomicilios.DataSource = proveedor.Domicilios;
                                gridDomicilios.DataBind();

                                //gridSucursales.DataSource = proveedor.Sucursales;
                                //gridSucursales.DataBind();

                                gridTelefonos.DataSource = proveedor.Telefonos;
                                gridTelefonos.DataBind();

                                gridRepresentantes.DataSource = proveedor.Representantes;
                                gridRepresentantes.DataBind();
                            }
                        }
                        cbpEditar.JSProperties["cp_HabilitaCapturaTipoPersona"] = 1;
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_HabilitaDetalleCasado"] = 1;
                        break;                    
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                        Cosmos.Compras.Entidades.Proveedor o;
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.Proveedor();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.Proveedor.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.Proveedor();
                        }
                        o.RFC = txtRFC.Text;
                        o.NombreCorto = txtNombreCorto.Text;
                        o.RazonSocial = txtRazonSocial.Text;
                        o.NombreComercial = txtNombreComercial.Text;
                        o.ApellidoPaterno = txtApellidoPaterno.Text;
                        o.ApellidoMaterno = txtApellidoMaterno.Text;
                        o.Nombre = txtNombres.Text;
                        o.Iniciales = txtIniciales.Text;
                        o.SobreNombre = txtSobrenombre.Text;
                        o.FechaNacimiento =  CastHelper.CDate2(txtFechaNacimiento.Value);
                        o.CasadoCivil = chkCasadoCivil.Checked;
                        o.CasadoIglesia = chkCasadoIglesia.Checked;
                        o.CURP = txtCURP.Text;

                        if (ddlTipoPersona.SelectedItem != null)
                        {
                            o.FisicaMoral = CastHelper.CStr2(ddlTipoPersona.SelectedItem.Value);
                        }
                        if (ddlSexoID.SelectedItem != null)
                        {
                            o.SexoID = CastHelper.CInt2(ddlSexoID.SelectedItem.Value);
                        }
                        if (ddlEstadoCivilID.SelectedItem != null)
                        {
                            o.EstadoCivilID = CastHelper.CInt2(ddlEstadoCivilID.SelectedItem.Value);
                        }
                        if (ddlTipoProveedorID.SelectedItem != null) {
                            o.TipoProveedorID = CastHelper.CInt2(ddlTipoProveedorID.SelectedItem.Value);
                        }
                        if (ddlGiroEmpresaID.SelectedItem != null)
                        {
                            o.GiroEmpresaID = CastHelper.CInt2(ddlGiroEmpresaID.SelectedItem.Value);
                        }
                        if (ddlMedioContactoID.SelectedItem != null)
                        {
                            o.MedioContactoID = CastHelper.CInt2(ddlMedioContactoID.SelectedItem.Value);
                        }
                        if (ddlVinculoID.SelectedItem != null)
                        {
                            o.VinculoID = CastHelper.CInt2(ddlVinculoID.SelectedItem.Value);
                        }

                        Cosmos.Compras.Entidades.Persona oAux = Cosmos.Compras.Api.Client.Persona.Guardar(o.PersonaID, o.PersonaClave, o.FisicaMoral, o.NombreComercial, o.RazonSocial,
                            o.Nombre, o.ApellidoPaterno, o.ApellidoMaterno, o.RFC, o.CURP, o.SexoID, o.FechaNacimiento, o.CiudadNacimientoID, o.EstadoCivilID,
                            o.CasadoCivil, o.CasadoIglesia, o.Iniciales, o.SobreNombre);
                        Cosmos.Compras.Api.Client.Proveedor.Guardar(id, oAux.PersonaID, o.NombreCorto, o.TipoProveedorID, o.GiroEmpresaID, o.MedioContactoID, o.VinculoID);

                        cbpEditar.JSProperties["cp_show"] = 0;
                        cbpEditar.JSProperties["cp_refresh"] = 1;
                        break;
                
                }
            }catch (Exception ex){
                cbpEditar.JSProperties["cp_show"] = 1;
                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
            }            
        }  

        protected void cbpEditarDomicilio_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarDomicilio.JSProperties["cp_refresh"] = "";
            cbpEditarDomicilio.JSProperties["cp_show"] = "";
            cbpEditarDomicilio.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.ProveedorDomicilio o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorDomicilioID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorDomicilioID"]);

                        txtProveedorDomicilioNombre.Text = "";
                        txtProveedorDomicilioCalle.Text = "";
                        txtProveedorDomicilioNumeroExterior.Text = "";
                        txtProveedorDomicilioNumeroInterior.Text = "";
                        txtProveedorDomicilioColonia.Text = "";
                        txtProveedorDomicilioCodigoPostal.Text = "";
                        txtProveedorDomicilioEntrecalles1.Text = "";
                        txtProveedorDomicilioEntrecalles2.Text = "";
                        ddlProveedorDomicilioCiudadID.SelectedIndex = -1;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.ProveedorDomicilio.Consultar(id);
                            if (o != null)
                            {
                                txtProveedorDomicilioNombre.Text = o.Nombre;
                                txtProveedorDomicilioCalle.Text = o.Calle;
                                txtProveedorDomicilioNumeroExterior.Text = o.NumeroExterior;
                                txtProveedorDomicilioNumeroInterior.Text = o.NumeroInterior;
                                txtProveedorDomicilioColonia.Text = o.Colonia;
                                txtProveedorDomicilioCodigoPostal.Text = o.CodigoPostal.ToString();
                                txtProveedorDomicilioEntrecalles1.Text = o.EntreCalle1;
                                txtProveedorDomicilioEntrecalles2.Text = o.EntreCalle2;
                                ddlProveedorDomicilioCiudadID.SelectedItem = ddlProveedorDomicilioCiudadID.Items.FindByValue(o.CiudadID);
                            }
                        }
                        cbpEditarDomicilio.JSProperties["cp_show"] = 1;
                        cbpEditarDomicilio.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorDomicilioID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);                        
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.ProveedorDomicilio();
                        }
                        else {
                            o = Cosmos.Compras.Api.Client.ProveedorDomicilio.Consultar(id);
                        }
                        if (o == null) {
                            o = new Cosmos.Compras.Entidades.ProveedorDomicilio();
                        }
                        o.Nombre = txtProveedorDomicilioNombre.Text;
                        o.Calle = txtProveedorDomicilioCalle.Text;
                        o.NumeroExterior = txtProveedorDomicilioNumeroExterior.Text;
                        o.NumeroInterior = txtProveedorDomicilioNumeroInterior.Text;
                        o.Colonia = txtProveedorDomicilioColonia.Text;
                        o.CodigoPostal = CastHelper.CInt2(txtProveedorDomicilioCodigoPostal.Text);
                        o.EntreCalle1 = txtProveedorDomicilioEntrecalles1.Text;
                        o.EntreCalle2 = txtProveedorDomicilioEntrecalles2.Text;
                        if (ddlProveedorDomicilioCiudadID.SelectedItem != null)
                        {
                            o.CiudadID = CastHelper.CInt2(ddlProveedorDomicilioCiudadID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Entidades.Domicilio oDom = Cosmos.Compras.Api.Client.Domicilio.Guardar(o.DomicilioID, o.Calle, o.NumeroExterior, o.NumeroInterior, o.EntreCalle1, o.EntreCalle2, o.CodigoPostal, o.Colonia, o.Coordenadas, o.CiudadID);
                        o.DomicilioID = oDom.DomicilioID;
                        Cosmos.Compras.Api.Client.ProveedorDomicilio.Guardar(o.ProveedorDomicilioID, proveedorID, o.DomicilioID, o.Nombre);

                        cbpEditarDomicilio.JSProperties["cp_show"] = 0;
                        cbpEditarDomicilio.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorDomicilioID"] = id;
                        Cosmos.Compras.Api.Client.ProveedorDomicilio.Eliminar(id);

                        cbpEditarDomicilio.JSProperties["cp_show"] = 0;
                        cbpEditarDomicilio.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex) {
                cbpEditarDomicilio.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarTelefono_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarTelefono.JSProperties["cp_refresh"] = "";
            cbpEditarTelefono.JSProperties["cp_show"] = "";
            cbpEditarTelefono.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.ProveedorTelefono o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorTelefonoID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorTelefonoID"]);

                        txtProveedorTelefonoNombre.Text = "";
                        txtProveedorTelefonoLadaPais.Text = "";
                        txtProveedorTelefonoNumeroTelefonico.Text = "";
                        ddlProveedorTelefonoTipoTelefonoID.SelectedIndex = -1;
                        chkProveedorTelefonoPredeterminado.Checked = false;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.ProveedorTelefono.Consultar(id);
                            if (o != null)
                            {
                                txtProveedorTelefonoNombre.Text = o.Comentarios;
                                txtProveedorTelefonoLadaPais.Text = o.LadaPais;
                                txtProveedorTelefonoNumeroTelefonico.Text = o.NumeroTelefonico;
                                chkProveedorTelefonoPredeterminado.Checked = o.Predeterminado;
                                ddlProveedorTelefonoTipoTelefonoID.SelectedItem = ddlProveedorTelefonoTipoTelefonoID.Items.FindByValue(o.TipoTelefonoID);
                            }
                        }
                        cbpEditarTelefono.JSProperties["cp_show"] = 1;
                        cbpEditarTelefono.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorTelefonoID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);                        
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.ProveedorTelefono();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.ProveedorTelefono.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.ProveedorTelefono();
                        }
                        o.Comentarios = txtProveedorTelefonoNombre.Text;
                        o.LadaPais = txtProveedorTelefonoLadaPais.Text;
                        o.NumeroTelefonico = txtProveedorTelefonoNumeroTelefonico.Text;
                        o.Predeterminado = chkProveedorTelefonoPredeterminado.Checked;
                        if (ddlProveedorTelefonoTipoTelefonoID.SelectedItem != null)
                        {
                            o.TipoTelefonoID = CastHelper.CInt2(ddlProveedorTelefonoTipoTelefonoID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Entidades.Telefono oAux = Cosmos.Compras.Api.Client.Telefono.Guardar(o.TelefonoID, o.LadaPais, o.NumeroTelefonico, o.TipoTelefonoID);
                        o.TelefonoID = oAux.TelefonoID;
                        Cosmos.Compras.Api.Client.ProveedorTelefono.Guardar(o.ProveedorTelefonoID, proveedorID,o.TelefonoID,o.Predeterminado,o.Comentarios);

                        cbpEditarTelefono.JSProperties["cp_show"] = 0;
                        cbpEditarTelefono.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorTelefonoID"] = id;
                        Cosmos.Compras.Api.Client.ProveedorTelefono.Eliminar(id);

                        cbpEditarTelefono.JSProperties["cp_show"] = 0;
                        cbpEditarTelefono.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                cbpEditarTelefono.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarMail_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarMail.JSProperties["cp_refresh"] = "";
            cbpEditarMail.JSProperties["cp_show"] = "";
            cbpEditarMail.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.ProveedorMail o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorMailID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorMailID"]);

                        txtProveedorMailNombre.Text = "";
                        txtProveedorMail.Text = "";
                        ddlProveedorMailTipoMailID.SelectedIndex = -1;
                        chkProveedorMailPredeterminado.Checked = false;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.ProveedorMail.Consultar(id);
                            if (o != null)
                            {
                                txtProveedorMailNombre.Text = o.Comentarios;
                                txtProveedorMail.Text = o.Mail;
                                chkProveedorMailPredeterminado.Checked = o.Predeterminado;
                                ddlProveedorMailTipoMailID.SelectedItem = ddlProveedorMailTipoMailID.Items.FindByValue(o.TipoMailID);
                            }
                        }
                        cbpEditarMail.JSProperties["cp_show"] = 1;
                        cbpEditarMail.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorMailID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.ProveedorMail();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.ProveedorMail.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.ProveedorMail();
                        }
                       
                        o.Comentarios = txtProveedorMailNombre.Text;
                        o.Mail = txtProveedorMail.Text;
                        o.Predeterminado = chkProveedorMailPredeterminado.Checked;
                        if (ddlProveedorMailTipoMailID.SelectedItem != null)
                        {
                            o.TipoMailID = CastHelper.CInt2(ddlProveedorMailTipoMailID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Api.Client.ProveedorMail.Guardar(o.ProveedorMailID, proveedorID,o.TipoMailID, o.Mail, o.Predeterminado, o.Comentarios);
                        
                        cbpEditarMail.JSProperties["cp_show"] = 0;
                        cbpEditarMail.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_ProveedorMailID"] = id;
                        Cosmos.Compras.Api.Client.ProveedorMail.Eliminar(id);

                        cbpEditarMail.JSProperties["cp_show"] = 0;
                        cbpEditarMail.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                cbpEditarMail.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarRepresentanteProveedor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarRepresentanteProveedor.JSProperties["cp_refresh"] = "";
            cbpEditarRepresentanteProveedor.JSProperties["cp_show"] = "";
            cbpEditarRepresentanteProveedor.JSProperties["cp_errorMessage"] = "";
            cbpEditarRepresentanteProveedor.JSProperties["cp_HabilitaDetalleCasado"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.RepresentanteProveedor o;
                switch (accion)
                {
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorID"] = id;
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                        Cosmos.Compras.Api.Client.RepresentanteProveedor.Eliminar(id);
                        cbpEditarRepresentanteProveedor.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedor.JSProperties["cp_refresh"] = 1;
                        break;
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                        txtRepresentanteProveedorApellidoPaterno.Text = "";
                        txtRepresentanteProveedorApellidoMaterno.Text = "";
                        txtRepresentanteProveedorNombres.Text = "";
                        txtRepresentanteProveedorSobrenombre.Text = "";
                        txtRepresentanteProveedorIniciales.Text = "";
                        txtRepresentanteProveedorFechaNacimiento.Text = "";
                        ddlRepresentanteProveedorSexoID.SelectedIndex = -1;
                        ddlRepresentanteProveedorLugarNacimientoID.SelectedIndex = -1;
                        ddlRepresentanteProveedorEstadoCivilID.SelectedIndex = -1;
                        chkRepresentanteProveedorCasadoCivil.Checked = false;
                        chkRepresentanteProveedorCasadoIglesia.Checked = false;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                            if (o != null)
                            {
                                txtRepresentanteProveedorRFC.Text = o.RFC;
                                txtRepresentanteProveedorApellidoPaterno.Text = o.ApellidoPaterno;
                                txtRepresentanteProveedorApellidoMaterno.Text = o.ApellidoMaterno;
                                txtRepresentanteProveedorNombres.Text = o.Nombre;
                                txtRepresentanteProveedorSobrenombre.Text = o.SobreNombre;
                                txtRepresentanteProveedorIniciales.Text = o.Iniciales;
                                txtRepresentanteProveedorFechaNacimiento.Date = o.FechaNacimiento;
                                ddlRepresentanteProveedorSexoID.SelectedItem = ddlRepresentanteProveedorSexoID.Items.FindByValue(o.SexoID);
                                ddlRepresentanteProveedorLugarNacimientoID.SelectedItem = ddlRepresentanteProveedorLugarNacimientoID.Items.FindByValue(o.CiudadNacimientoID);
                                ddlRepresentanteProveedorEstadoCivilID.SelectedItem = ddlRepresentanteProveedorEstadoCivilID.Items.FindByValue(o.EstadoCivilID);
                                chkRepresentanteProveedorCasadoCivil.Checked = o.CasadoCivil;
                                chkRepresentanteProveedorCasadoIglesia.Checked = o.CasadoIglesia;

                                gridRepresentanteProveedorDomicilios.DataSource = o.Domicilios;
                                gridRepresentanteProveedorDomicilios.DataBind();

                                gridRepresentanteProveedorMails.DataSource = o.Mails;
                                gridRepresentanteProveedorMails.DataBind();

                                gridRepresentanteProveedorTelefonos.DataSource = o.Telefonos;
                                gridRepresentanteProveedorTelefonos.DataBind();

                            }
                        }
                        cbpEditarRepresentanteProveedor.JSProperties["cp_show"] = 1;
                        cbpEditarRepresentanteProveedor.JSProperties["cp_refresh"] = 0;
                        cbpEditarRepresentanteProveedor.JSProperties["cp_HabilitaDetalleCasado"] = "1";
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedor();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedor();
                        }
                        o.ProveedorID = proveedorID;
                        //o.PersonaClave = txtRepresentanteClave.Text;
                        o.RFC = txtRepresentanteProveedorRFC.Text;
                        o.ApellidoPaterno = txtRepresentanteProveedorApellidoPaterno.Text;
                        o.ApellidoMaterno = txtRepresentanteProveedorApellidoMaterno.Text;
                        o.Nombre = txtRepresentanteProveedorNombres.Text;
                        o.SobreNombre = txtRepresentanteProveedorSobrenombre.Text;
                        o.Iniciales = txtRepresentanteProveedorIniciales.Text;
                        o.FechaNacimiento = txtRepresentanteProveedorFechaNacimiento.Date;
                        if (ddlRepresentanteProveedorSexoID.SelectedItem != null)
                        {
                            o.SexoID = CastHelper.CInt2(ddlRepresentanteProveedorSexoID.SelectedItem.Value);
                        }
                        if (ddlRepresentanteProveedorLugarNacimientoID.SelectedItem != null)
                        {
                            o.CiudadNacimientoID = CastHelper.CInt2(ddlRepresentanteProveedorLugarNacimientoID.SelectedItem.Value);
                        }
                        if (ddlRepresentanteProveedorEstadoCivilID.SelectedItem != null)
                        {
                            o.EstadoCivilID = CastHelper.CInt2(ddlRepresentanteProveedorEstadoCivilID.SelectedItem.Value);
                        }

                        o.CasadoCivil = chkRepresentanteProveedorCasadoCivil.Checked = o.CasadoCivil;
                        o.CasadoIglesia = chkRepresentanteProveedorCasadoIglesia.Checked;
                        o.FisicaMoral = "F";

                        Cosmos.Compras.Entidades.Persona oAux = Cosmos.Compras.Api.Client.Persona.Guardar(o.PersonaID, o.PersonaClave, o.FisicaMoral, o.NombreComercial, o.RazonSocial,
                            o.Nombre, o.ApellidoPaterno, o.ApellidoMaterno, o.RFC, o.CURP, o.SexoID, o.FechaNacimiento, o.CiudadNacimientoID, o.EstadoCivilID,
                            o.CasadoCivil, o.CasadoIglesia, o.Iniciales, o.SobreNombre);
                        Cosmos.Compras.Api.Client.RepresentanteProveedor.Guardar(id, o.ProveedorID, oAux.PersonaID);

                        cbpEditarRepresentanteProveedor.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedor.JSProperties["cp_refresh"] = 1;
                        break;

                }
            }
            catch (Exception ex)
            {
                cbpEditarRepresentanteProveedor.JSProperties["cp_show"] = 1;
                cbpEditarRepresentanteProveedor.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarRepresentanteProveedorDomicilio_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_refresh"] = "";
            cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_show"] = "";
            cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorDomicilioID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorDomicilioID"]);

                        txtRepresentanteProveedorDomicilioNombre.Text = "";
                        txtRepresentanteProveedorDomicilioCalle.Text = "";
                        txtRepresentanteProveedorDomicilioNumeroExterior.Text = "";
                        txtRepresentanteProveedorDomicilioNumeroInterior.Text = "";
                        txtRepresentanteProveedorDomicilioColonia.Text = "";
                        txtRepresentanteProveedorDomicilioCodigoPostal.Text = "";
                        txtRepresentanteProveedorDomicilioEntrecalles1.Text = "";
                        txtRepresentanteProveedorDomicilioEntrecalles2.Text = "";
                        ddlRepresentanteProveedorDomicilioCiudadID.SelectedIndex = -1;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorDomicilio.Consultar(id);
                            if (o != null)
                            {
                                txtRepresentanteProveedorDomicilioNombre.Text = o.Nombre;
                                txtRepresentanteProveedorDomicilioCalle.Text = o.Calle;
                                txtRepresentanteProveedorDomicilioNumeroExterior.Text = o.NumeroExterior;
                                txtRepresentanteProveedorDomicilioNumeroInterior.Text = o.NumeroInterior;
                                txtRepresentanteProveedorDomicilioColonia.Text = o.Colonia;
                                txtRepresentanteProveedorDomicilioCodigoPostal.Text = o.CodigoPostal.ToString();
                                txtRepresentanteProveedorDomicilioEntrecalles1.Text = o.EntreCalle1;
                                txtRepresentanteProveedorDomicilioEntrecalles2.Text = o.EntreCalle2;
                                ddlRepresentanteProveedorDomicilioCiudadID.SelectedItem = ddlRepresentanteProveedorDomicilioCiudadID.Items.FindByValue(o.CiudadID);
                            }
                        }
                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_show"] = 1;
                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorDomicilioID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorDomicilio.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
                        }
                        o.Nombre = txtRepresentanteProveedorDomicilioNombre.Text;
                        o.Calle = txtRepresentanteProveedorDomicilioCalle.Text;
                        o.NumeroExterior = txtRepresentanteProveedorDomicilioNumeroExterior.Text;
                        o.NumeroInterior = txtRepresentanteProveedorDomicilioNumeroInterior.Text;
                        o.Colonia = txtRepresentanteProveedorDomicilioColonia.Text;
                        o.CodigoPostal = CastHelper.CInt2(txtRepresentanteProveedorDomicilioCodigoPostal.Text);
                        o.EntreCalle1 = txtRepresentanteProveedorDomicilioEntrecalles1.Text;
                        o.EntreCalle2 = txtRepresentanteProveedorDomicilioEntrecalles2.Text;
                        if (ddlRepresentanteProveedorDomicilioCiudadID.SelectedItem != null)
                        {
                            o.CiudadID = CastHelper.CInt2(ddlRepresentanteProveedorDomicilioCiudadID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Entidades.Domicilio oDom = Cosmos.Compras.Api.Client.Domicilio.Guardar(o.DomicilioID, o.Calle, o.NumeroExterior, o.NumeroInterior, o.EntreCalle1, o.EntreCalle2, o.CodigoPostal, o.Colonia, o.Coordenadas, o.CiudadID);
                        o.DomicilioID = oDom.DomicilioID;
                        Cosmos.Compras.Api.Client.RepresentanteProveedorDomicilio.Guardar( o.RepresentanteProveedorDomicilioID, proveedorID, o.DomicilioID, o.Nombre);

                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorDomicilioID"] = id;
                        Cosmos.Compras.Api.Client.RepresentanteProveedorDomicilio.Eliminar(id);

                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                cbpEditarRepresentanteProveedorDomicilio.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarRepresentanteProveedorTelefono_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_refresh"] = "";
            cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_show"] = "";
            cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorTelefonoID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorTelefonoID"]);

                        txtRepresentanteProveedorTelefonoNombre.Text = "";
                        txtRepresentanteProveedorTelefonoLadaPais.Text = "";
                        txtRepresentanteProveedorTelefonoNumeroTelefonico.Text = "";
                        ddlRepresentanteProveedorTelefonoTipoTelefonoID.SelectedIndex = -1;
                        chkRepresentanteProveedorTelefonoPredeterminado.Checked = false;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorTelefono.Consultar(id);
                            if (o != null)
                            {
                                txtRepresentanteProveedorTelefonoNombre.Text = o.Comentarios;
                                txtRepresentanteProveedorTelefonoLadaPais.Text = o.LadaPais;
                                txtRepresentanteProveedorTelefonoNumeroTelefonico.Text = o.NumeroTelefonico;
                                chkRepresentanteProveedorTelefonoPredeterminado.Checked = o.Predeterminado;
                                ddlRepresentanteProveedorTelefonoTipoTelefonoID.SelectedItem = ddlRepresentanteProveedorTelefonoTipoTelefonoID.Items.FindByValue(o.TipoTelefonoID);
                            }
                        }
                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_show"] = 1;
                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorTelefonoID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorTelefono.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
                        }
                        o.Comentarios = txtRepresentanteProveedorTelefonoNombre.Text;
                        o.LadaPais = txtRepresentanteProveedorTelefonoLadaPais.Text;
                        o.NumeroTelefonico = txtRepresentanteProveedorTelefonoNumeroTelefonico.Text;
                        o.Predeterminado = chkRepresentanteProveedorTelefonoPredeterminado.Checked;
                        if (ddlRepresentanteProveedorTelefonoTipoTelefonoID.SelectedItem != null)
                        {
                            o.TipoTelefonoID = CastHelper.CInt2(ddlRepresentanteProveedorTelefonoTipoTelefonoID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Entidades.Telefono oAux = Cosmos.Compras.Api.Client.Telefono.Guardar(o.TelefonoID, o.LadaPais, o.NumeroTelefonico, o.TipoTelefonoID);
                        o.TelefonoID = oAux.TelefonoID;
                        Cosmos.Compras.Api.Client.RepresentanteProveedorTelefono.Guardar(o.RepresentanteProveedorTelefonoID, proveedorID, oAux.TelefonoID, o.Extension, o.Predeterminado, o.Comentarios);

                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorTelefonoID"] = id;
                        Cosmos.Compras.Api.Client.ProveedorTelefono.Eliminar(id);

                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                cbpEditarRepresentanteProveedorTelefono.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void cbpEditarRepresentanteProveedorMail_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditarRepresentanteProveedorMail.JSProperties["cp_refresh"] = "";
            cbpEditarRepresentanteProveedorMail.JSProperties["cp_show"] = "";
            cbpEditarRepresentanteProveedorMail.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                int proveedorID = 0;
                Cosmos.Compras.Entidades.RepresentanteProveedorMail o;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorMailID"] = id;
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorMailID"]);

                        txtRepresentanteProveedorMailNombre.Text = "";
                        txtRepresentanteProveedorMail.Text = "";
                        ddlRepresentanteProveedorMailTipoMailID.SelectedIndex = -1;
                        chkRepresentanteProveedorMailPredeterminado.Checked = false;
                        if (id > 0)
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorMail.Consultar(id);
                            if (o != null)
                            {
                                txtRepresentanteProveedorMailNombre.Text = o.Comentarios;
                                txtRepresentanteProveedorMail.Text = o.Mail;
                                chkRepresentanteProveedorMailPredeterminado.Checked = o.Predeterminado;
                                ddlRepresentanteProveedorMailTipoMailID.SelectedItem = ddlRepresentanteProveedorMailTipoMailID.Items.FindByValue(o.TipoMailID);
                            }
                        }
                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_show"] = 1;
                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorMailID"]);
                        proveedorID = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                        if (id == 0)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
                        }
                        else
                        {
                            o = Cosmos.Compras.Api.Client.RepresentanteProveedorMail.Consultar(id);
                        }
                        if (o == null)
                        {
                            o = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
                        }

                        o.Comentarios = txtRepresentanteProveedorMailNombre.Text;
                        o.Mail = txtRepresentanteProveedorMail.Text;
                        o.Predeterminado = chkRepresentanteProveedorMailPredeterminado.Checked;
                        if (ddlRepresentanteProveedorMailTipoMailID.SelectedItem != null)
                        {
                            o.TipoMailID = CastHelper.CInt2(ddlRepresentanteProveedorMailTipoMailID.SelectedItem.Value);
                        }
                        Cosmos.Compras.Api.Client.RepresentanteProveedorMail.Guardar(o.RepresentanteProveedorMailID, proveedorID, o.Mail, o.TipoMailID, o.Predeterminado, o.Comentarios);

                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_refresh"] = 1;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        Session["Proveedor_Listado_RepresentanteProveedorMailID"] = id;
                        Cosmos.Compras.Api.Client.ProveedorMail.Eliminar(id);

                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_show"] = 0;
                        cbpEditarRepresentanteProveedorMail.JSProperties["cp_refresh"] = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                cbpEditarRepresentanteProveedorMail.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }


        protected void gridDomicilios_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.ProveedorDomicilio.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh) {
                id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridDomicilios.DataSource = proveedor.Domicilios;
                        gridDomicilios.DataBind();
                    }
                }
            }
        }
        protected void gridDomicilios_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridDomicilios.DataSource = proveedor.Domicilios;
                        gridDomicilios.DataBind();
                    }
                }
            }
        }

        protected void gridTelefonos_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.ProveedorTelefono.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridTelefonos.DataSource = proveedor.Telefonos;
                        gridTelefonos.DataBind();
                    }
                }
            }            
        }
        protected void gridTelefonos_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridTelefonos.DataSource = proveedor.Telefonos;
                        gridTelefonos.DataBind();
                    }
                }
            }
        }

        protected void gridMails_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.ProveedorMail.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridMails.DataSource = proveedor.Mails;
                        gridMails.DataBind();
                    }
                }
            }
        }
        protected void gridMails_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridMails.DataSource = proveedor.Mails;
                        gridMails.DataBind();
                    }
                }
            }
        }
        
        
        
        protected void gridRepresentantes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.ProveedorDomicilio.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridRepresentantes.DataSource = proveedor.Representantes;
                        gridRepresentantes.DataBind();
                    }
                }
            }
        }
        protected void gridRepresentantes_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_ProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.Proveedor proveedor = Cosmos.Compras.Api.Client.Proveedor.ConsultarCompleto(id);
                    if (proveedor != null)
                    {
                        gridRepresentantes.DataSource = proveedor.Representantes;
                        gridRepresentantes.DataBind();
                    }
                }
            }
        }

        protected void gridRepresentanteProveedorDomicilios_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }

                    Cosmos.Compras.Api.Client.RepresentanteProveedorDomicilio.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorDomicilios.DataSource = o.Domicilios;
                        gridRepresentanteProveedorDomicilios.DataBind();
                    }
                }
            }
        }
        protected void gridRepresentanteProveedorDomicilios_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorDomicilios.DataSource = o.Domicilios;
                        gridRepresentanteProveedorDomicilios.DataBind();
                    }
                }
            }
        }

        protected void gridRepresentanteProveedorTelefonos_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.RepresentanteProveedorTelefono.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorTelefonos.DataSource = o.Telefonos;
                        gridRepresentanteProveedorTelefonos.DataBind();
                    }
                }
            }
        }

        protected void gridRepresentanteProveedorTelefonos_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorTelefonos.DataSource = o.Telefonos;
                        gridRepresentanteProveedorTelefonos.DataBind();
                    }
                }
            }
        }

        protected void gridRepresentanteProveedorMails_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] datos = e.Parameters.Split('|');
            string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
            int id = 0;
            bool refresh = false;
            switch (accion)
            {
                case "REFRESH":
                    refresh = true;
                    break;
                case "ELIMINAR":
                    if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                    Cosmos.Compras.Api.Client.RepresentanteProveedorMail.Eliminar(id);
                    refresh = true;
                    break;
            }
            if (refresh)
            {
                id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorMails.DataSource = o.Mails;
                        gridRepresentanteProveedorMails.DataBind();
                    }
                }
            }
        }

        protected void gridRepresentanteProveedorMails_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                int id = CastHelper.CInt2(Session["Proveedor_Listado_RepresentanteProveedorID"]);
                if (id > 0)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = Cosmos.Compras.Api.Client.RepresentanteProveedor.ConsultarCompleto(id);
                    if (o != null)
                    {
                        gridRepresentanteProveedorMails.DataSource = o.Mails;
                        gridRepresentanteProveedorMails.DataBind();
                    }
                }
            }
        }

        

        

       
    }
}
