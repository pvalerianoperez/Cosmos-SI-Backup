using Cosmos.Framework;
using Cosmos.Website.Recursos.Utilerias;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Personal_Listado : System.Web.UI.Page
    {
       
        public Cosmos.Compras.Entidades.Personal Personal { 
            get { return (Cosmos.Compras.Entidades.Personal)Session["Personal_Listado_Personal"]; } 
            set { Session["Personal_Listado_Personal"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request["__EVENTTARGET"];
            switch (accion)
            {
                case "EXPORTAR_EXCEL":
                    gvPersonal.DataBind();
                    //gvPersonal.WriteXlsxToResponse(string.Format("Personal_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    gvPersonal.DataBind();
                    //t.WritePdfToResponse(string.Format("Producto_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }
            if (!IsPostBack && !IsCallback) {
                Personal = null;
            }
            CargaPersonalGrids();
           
        }


        protected void CargaPersonalGrids() {
            CargaPersonalMails();
            CargaPersonalDomicilios();
            CargaPersonalTelefonos();
            CargaPersonalContactos();
        }
        protected void CargaPersonalMails() {
            if (Personal != null)
            {
                gvPersonalMail.DataSource = Personal.Mails;
                gvPersonalMail.DataBind();
            }
            else
            {
                gvPersonalMail.DataSource = null;
                gvPersonalMail.DataBind();
            }
        }
        protected void CargaPersonalDomicilios(){
            if (Personal != null)
            {
                gvPersonalDomicilios.DataSource = Personal.Domicilios;
                gvPersonalDomicilios.DataBind();
            }
            else
            {
                gvPersonalDomicilios.DataSource = null;
                gvPersonalDomicilios.DataBind();
            }
        }
        protected void CargaPersonalTelefonos()
        {
            if (Personal != null)
            {
                gvPersonalTelefonos.DataSource = Personal.Telefonos;
                gvPersonalTelefonos.DataBind();
            }
            else
            {
                gvPersonalTelefonos.DataSource = null;
                gvPersonalTelefonos.DataBind();
            }
        }
        protected void CargaPersonalContactos()
        {
        }

        protected void cbpPersonal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpPersonal.JSProperties["cp_refresh"] = "";
            cbpPersonal.JSProperties["cp_show"] = "";
            cbpPersonal.JSProperties["cp_errorMessage"] = "";
            cbpPersonal.JSProperties["cp_HabilitaDetalleCasado"] = "";
            Cosmos.Compras.Entidades.Personal entidad;
            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                switch (accion)
                {
                    case "ELIMINAR":
                        if (datos.Length > 1)
                        {
                            //PersonalID = CastHelper.CInt2(datos[1]);
                            if(Personal!=null)
                            {
                                try
                                {
                                    Cosmos.Compras.Api.Client.Personal.Eliminar(Personal.PersonalID);
                                    cbpPersonal.JSProperties["cp_show"] = 0;
                                    cbpPersonal.JSProperties["cp_refresh"] = 1;
                                }
                                catch (Exception ex)
                                {
                                    cbpPersonal.JSProperties["cp_show"] = 0;
                                    cbpPersonal.JSProperties["cp_refresh"] = 0;
                                    cbpPersonal.JSProperties["cp_errorMessage"] = ex.Message;
                                }
                                Personal = null;
                            }
                        }                        
                        break;
                    case "EDITAR":                        
                        if (datos.Length > 1)
                        {
                            Personal = Cosmos.Compras.Api.Client.Personal.Consultar(CastHelper.CInt2(datos[1])); 
                            btnEditarOK.Visible = ((Recursos.MasterPages.SitioProtegido)Page.Master).PermisoAccion("AGREGAR");
                            if (Personal != null)
                            {
                                if (Personal.PersonalID > 0)
                                {                                                                       
                                    hfPersonal.Add("PersonalID", Personal.PersonalID);
                                    hfPersonal.Add("PersonaID", Personal.PersonaID);
                                    txtRFC.Text = Personal.RFC;
                                    Funciones.SetControlValue(ref txtRFC, Personal.RFC);
                                    Funciones.SetControlValue(ref txtCURP, Personal.CURP);
                                    Funciones.SetControlValue(ref txtNombres, Personal.Nombre);
                                    Funciones.SetControlValue(ref txtApellidoPaterno, Personal.ApellidoPaterno);
                                    Funciones.SetControlValue(ref txtApellidoMaterno, Personal.ApellidoMaterno);
                                    Funciones.SetControlValue(ref txtSobrenombre, Personal.SobreNombre);
                                    Funciones.SetControlValue(ref txtIniciales, Personal.Iniciales);
                                    Funciones.SetControlValue(ref ddlSexo, Personal.SexoID);
                                    Funciones.SetControlValue(ref dtFechaNacimiento, Personal.FechaNacimiento);
                                    Funciones.SetControlValue(ref ddlCiudadNacimiento, Personal.CiudadNacimientoID);
                                    Funciones.SetControlValue(ref ddlEstadoCivil, Personal.EstadoCivilID);
                                    Funciones.SetControlValue(ref chkCasadoCivil, Personal.CasadoCivil);
                                    Funciones.SetControlValue(ref chkCasadoIglesia, Personal.CasadoIglesia);
                                    Funciones.SetControlValue(ref ddlEstatus, Personal.EstatusPersonalID);
                                    //Funciones.SetControlValue(ref ddlEmpresa, Personal.EmpresaID);
                                    Funciones.SetControlValue(ref ddlArea, Personal.AreaID);
                                    Funciones.SetControlValue(ref ddlPuesto, Personal.PuestoID);
                                    Funciones.SetControlValue(ref ddlHorarioPersonal, Personal.HorarioPersonalID);
                                    Funciones.SetControlValue(ref ddlJefeInmediato, Personal.ReportaAPersonalID);
                                    Funciones.SetControlValue(ref ddlCentroCosto, Personal.CentroCostoID);
                                    Funciones.SetControlValue(ref txtClaveEmpleado, Personal.PersonalClave);
                                    CargaPersonalGrids();
                                    btnEditarOK.Visible = ((Recursos.MasterPages.SitioProtegido)Page.Master).PermisoAccion("MODIFICAR");
                                    
                                }
                            }
                            //Funciones.SetControlValue(ref ddlEmpresa, Website.Recursos.Utilerias.AppGlobals.EmpresaID);
                            cbpPersonal.JSProperties["cp_show"] = 1;
                            cbpPersonal.JSProperties["cp_refresh"] = 0;
                            cbpPersonal.JSProperties["cp_HabilitaDetalleCasado"] = 1;
                        }
                        else {
                            cbpPersonal.JSProperties["cp_show"] = 1;
                            cbpPersonal.JSProperties["cp_refresh"] = 0;
                            cbpPersonal.JSProperties["cp_HabilitaDetalleCasado"] = 1;
                        }
                        
                        break;
                    case "GUARDAR":
                        if (Personal != null)
                        {
                            Personal.PersonaID = CastHelper.CInt2(Funciones.GetControlValue(hfPersonal, "PersonaID"));
                            Personal.RFC = Funciones.GetControlValue(txtRFC);
                            Personal.CURP = Funciones.GetControlValue(txtCURP);
                            Personal.Nombre = Funciones.GetControlValue(txtNombres);
                            Personal.ApellidoPaterno = Funciones.GetControlValue(txtApellidoPaterno);
                            Personal.ApellidoMaterno = Funciones.GetControlValue(txtApellidoMaterno);
                            Personal.SobreNombre = Funciones.GetControlValue(txtSobrenombre);
                            Personal.Iniciales = Funciones.GetControlValue(txtIniciales);
                            Personal.SexoID = Funciones.GetControlValue(ddlSexo);
                            Personal.EstadoCivilID = Funciones.GetControlValue(ddlEstadoCivil);
                            Personal.FechaNacimiento = Funciones.GetControlValue(dtFechaNacimiento);
                            Personal.CasadoCivil = Funciones.GetControlValue(chkCasadoCivil);
                            Personal.CasadoIglesia = Funciones.GetControlValue(chkCasadoIglesia);
                            Personal.CiudadNacimientoID = Funciones.GetControlValue(ddlCiudadNacimiento);
                            Personal.EstatusPersonalID = Funciones.GetControlValue(ddlEstatus);
                            Personal.EmpresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                            Personal.AreaID = Funciones.GetControlValue(ddlArea);
                            Personal.PuestoID = Funciones.GetControlValue(ddlPuesto);
                            Personal.HorarioPersonalID = Funciones.GetControlValue(ddlHorarioPersonal);
                            Personal.ReportaAPersonalID = Funciones.GetControlValue(ddlJefeInmediato);
                            Personal.CentroCostoID = Funciones.GetControlValue(ddlCentroCosto);
                            Personal.PersonalClave = Funciones.GetControlValue(txtClaveEmpleado);
                            Personal = Cosmos.Compras.Api.Client.Personal.Guardar(Personal);
                        }
                            
                        cbpPersonal.JSProperties["cp_show"] = 0;
                        cbpPersonal.JSProperties["cp_refresh"] = 1;
                        break;

                }
            }
            catch (Exception ex)
            {
                cbpPersonal.JSProperties["cp_show"] = 1;
                cbpPersonal.JSProperties["cp_errorMessage"] = ex.Message;

            }
        }

        protected void gvPersonal_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
            }
        }

        protected void gvPersonalMail_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            
            if (Personal != null)
            {
                if (Personal.Mails == null) { Personal.Mails = new List<Cosmos.Compras.Entidades.PersonalMail>(); }
                Cosmos.Compras.Entidades.PersonalMail o;
                //insert
                for (int i = 0; i < e.InsertValues.Count; i++)
                {                    
                    o = new Cosmos.Compras.Entidades.PersonalMail();
                    o.PersonalID = Personal.PersonalID;
                    o.PersonalMailID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonalMailID"]);
                    o.TipoMailID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoMailID"]);
                    o.Predeterminado = CastHelper.CBool2(e.InsertValues[i].NewValues["Predeterminado"]);
                    o.Comentarios = CastHelper.CStr2(e.InsertValues[i].NewValues["Comentarios"]);
                    o.Email = CastHelper.CStr2(e.InsertValues[i].NewValues["Email"]);
                    Personal.Mails.Add(o);
                }
                //update
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    o = Personal.Mails.Where(x => x.PersonalMailID == CastHelper.CInt2(e.UpdateValues[i].Keys["PersonalMailID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Mails.Remove(o);
                    }
                    else
                    {
                        o = new Cosmos.Compras.Entidades.PersonalMail();
                        o.PersonalID = Personal.PersonalID;
                        o.PersonalMailID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonalMailID"]);
                    }
                    o.TipoMailID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoMailID"]);
                    o.Predeterminado = CastHelper.CBool2(e.UpdateValues[i].NewValues["Predeterminado"]);
                    o.Comentarios = CastHelper.CStr2(e.UpdateValues[i].NewValues["Comentarios"]);
                    o.Email = CastHelper.CStr2(e.UpdateValues[i].NewValues["Email"]);
                    Personal.Mails.Add(o);

                }
                //delete
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    o = Personal.Mails.Where(x => x.PersonalMailID == CastHelper.CInt2(e.DeleteValues[i].Keys["PersonalMailID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Mails.Remove(o);
                    }
                }
            }
            e.Handled = true;
            CargaPersonalMails();
           
        }

        protected void gvPersonalTelefonos_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            if (Personal != null)
            {
                if (Personal.Telefonos == null) { Personal.Telefonos = new List<Cosmos.Compras.Entidades.PersonalTelefono>(); }
                Cosmos.Compras.Entidades.PersonalTelefono o;
                //insert
                for (int i = 0; i < e.InsertValues.Count; i++)
                {
                    o = new Cosmos.Compras.Entidades.PersonalTelefono();
                    o.PersonalID = Personal.PersonalID;
                    o.PersonalTelefonoID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonalMailID"]);
                    o.Extension = CastHelper.CStr2(e.InsertValues[i].NewValues["Extension"]);
                    o.Predeterminado = CastHelper.CBool2(e.InsertValues[i].NewValues["Predeterminado"]);
                    o.Comentarios = CastHelper.CStr2(e.InsertValues[i].NewValues["Comentarios"]);
                    o.LadaPais = CastHelper.CStr2(e.InsertValues[i].NewValues["LadaPais"]);
                    o.NumeroTelefonico = CastHelper.CStr2(e.InsertValues[i].NewValues["NumeroTelefonico"]);
                    o.TipoTelefonoID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoTelefonoID"]);
                    o.EstatusTelefonoID = CastHelper.CInt2(e.InsertValues[i].NewValues["EstatusTelefonoID"]);
                    Personal.Telefonos.Add(o);
                }
                //update
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    o = Personal.Telefonos.Where(x => x.PersonalTelefonoID == CastHelper.CInt2(e.UpdateValues[i].Keys["PersonalTelefonoID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Telefonos.Remove(o);
                    }
                    else
                    {
                        o = new Cosmos.Compras.Entidades.PersonalTelefono();
                        o.PersonalID = Personal.PersonalID;
                        o.PersonalTelefonoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonalTelefonoID"]);
                    }
                    o.Extension = CastHelper.CStr2(e.UpdateValues[i].NewValues["Extension"]);
                    o.Predeterminado = CastHelper.CBool2(e.UpdateValues[i].NewValues["Predeterminado"]);
                    o.Comentarios = CastHelper.CStr2(e.UpdateValues[i].NewValues["Comentarios"]);
                    o.LadaPais = CastHelper.CStr2(e.UpdateValues[i].NewValues["LadaPais"]);
                    o.NumeroTelefonico = CastHelper.CStr2(e.UpdateValues[i].NewValues["NumeroTelefonico"]);
                    o.TipoTelefonoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoTelefonoID"]);
                    o.EstatusTelefonoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["EstatusTelefonoID"]);
                    Personal.Telefonos.Add(o);

                }
                //delete
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    o = Personal.Telefonos.Where(x => x.PersonalTelefonoID == CastHelper.CInt2(e.DeleteValues[i].Keys["PersonalTelefonoID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Telefonos.Remove(o);
                    }
                }
            }
            e.Handled = true;
            CargaPersonalTelefonos();

        }

        protected void gvPersonalDomicilios_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            if (Personal.Domicilios == null) { Personal.Domicilios = new List<Cosmos.Compras.Entidades.PersonalDomicilio>(); }
            Cosmos.Compras.Entidades.PersonalDomicilio o;
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                if (Personal != null)
                {
                    o = new Cosmos.Compras.Entidades.PersonalDomicilio();
                    o.PersonalID = Personal.PersonalID;
                    o.PersonalDomicilioID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonalDomicilioID"]);
                    o.DomicilioID = CastHelper.CInt2(e.InsertValues[i].NewValues["DomicilioID"]);
                    o.Calle = CastHelper.CStr2(e.InsertValues[i].NewValues["Calle"]);
                    o.NumeroExterior = CastHelper.CStr2(e.InsertValues[i].NewValues["NumeroExterior"]);
                    o.NumeroInterior = CastHelper.CStr2(e.InsertValues[i].NewValues["NumeroInterior"]);
                    o.EntreCalle1 = CastHelper.CStr2(e.InsertValues[i].NewValues["EntreCalle1"]);
                    o.EntreCalle2 = CastHelper.CStr2(e.InsertValues[i].NewValues["EntreCalle2"]);
                    o.CodigoPostal = CastHelper.CInt2(e.InsertValues[i].NewValues["CodigoPostal"]);
                    o.Colonia = CastHelper.CStr2(e.InsertValues[i].NewValues["Colonia"]);
                    o.CiudadID = CastHelper.CInt2(e.InsertValues[i].NewValues["CiudadID"]);
                    Personal.Domicilios.Add(o);
                }
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                if (Personal != null)
                {
                    o = Personal.Domicilios.Where(x => x.PersonalDomicilioID == CastHelper.CInt2(e.UpdateValues[i].Keys["PersonalDomicilioID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Domicilios.Remove(o);
                    }
                    else
                    {
                        o = new Cosmos.Compras.Entidades.PersonalDomicilio();
                        o.PersonalID = Personal.PersonalID;
                        o.PersonalDomicilioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonalDomicilioID"]);
                        o.DomicilioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["DomicilioID"]);
                    }
                    o.Calle = CastHelper.CStr2(e.UpdateValues[i].NewValues["Calle"]);
                    o.NumeroExterior = CastHelper.CStr2(e.UpdateValues[i].NewValues["NumeroExterior"]);
                    o.NumeroInterior = CastHelper.CStr2(e.UpdateValues[i].NewValues["NumeroInterior"]);
                    o.EntreCalle1 = CastHelper.CStr2(e.UpdateValues[i].NewValues["EntreCalle1"]);
                    o.EntreCalle2 = CastHelper.CStr2(e.UpdateValues[i].NewValues["EntreCalle2"]);
                    o.CodigoPostal = CastHelper.CInt2(e.UpdateValues[i].NewValues["CodigoPostal"]);
                    o.Colonia = CastHelper.CStr2(e.UpdateValues[i].NewValues["Colonia"]);
                    o.CiudadID = CastHelper.CInt2(e.UpdateValues[i].NewValues["CiudadID"]);
                    Personal.Domicilios.Add(o);
                }

            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                if (Personal != null)
                {
                    o = Personal.Domicilios.Where(x => x.PersonalDomicilioID == CastHelper.CInt2(e.DeleteValues[i].Keys["PersonalDomicilioID"])).FirstOrDefault();
                    if (o != null)
                    {
                        Personal.Domicilios.Remove(o);
                    }
                }
            }
            e.Handled = true;
            CargaPersonalDomicilios();

        }

        protected void gvPersonalDomicilios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Personal != null){
                Cosmos.Compras.Entidades.PersonalDomicilio o;
                int id = CastHelper.CInt2(e.Keys["PersonalDomicilioID"]);
                o = Personal.Domicilios.Where(x => x.PersonalDomicilioID == id ).FirstOrDefault();
                if (o != null)
                {
                    Personal.Domicilios.Remove(o);
                }
                else
                {
                    o = new Cosmos.Compras.Entidades.PersonalDomicilio();
                    o.PersonalID = Personal.PersonalID;
                    o.PersonalDomicilioID = id;
                    o.DomicilioID = CastHelper.CInt2(e.NewValues["DomicilioID"]);
                }
                o.Calle = CastHelper.CStr2(e.NewValues["Calle"]);
                o.NumeroExterior = CastHelper.CStr2(e.NewValues["NumeroExterior"]);
                o.NumeroInterior = CastHelper.CStr2(e.NewValues["NumeroInterior"]);
                o.EntreCalle1 = CastHelper.CStr2(e.NewValues["EntreCalle1"]);
                o.EntreCalle2 = CastHelper.CStr2(e.NewValues["EntreCalle2"]);
                o.CodigoPostal = CastHelper.CInt2(e.NewValues["CodigoPostal"]);
                o.Colonia = CastHelper.CStr2(e.NewValues["Colonia"]);
                o.CiudadID = CastHelper.CInt2(e.NewValues["CiudadID"]);
                Personal.Domicilios.Add(o);
            }
            e.Cancel = true;
            gvPersonalDomicilios.CancelEdit();
            CargaPersonalDomicilios();
        }

        protected void gvPersonalDomicilios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            if (Personal != null)
            {
                Cosmos.Compras.Entidades.PersonalDomicilio o;
                int id = CastHelper.CInt2(e.Keys["PersonalDomicilioID"]);
                o = Personal.Domicilios.Where(x => x.PersonalDomicilioID == id).FirstOrDefault();
                if (o != null)
                {
                    Personal.Domicilios.Remove(o);
                }                
            }
            e.Cancel = true;
            gvPersonalDomicilios.CancelEdit();
            CargaPersonalDomicilios();
        }

        protected void gvPersonalDomicilios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (Personal != null)
            {
                Cosmos.Compras.Entidades.PersonalDomicilio o;
                int id = -1;
                o = Personal.Domicilios.Where(x => x.PersonalDomicilioID == id).FirstOrDefault();
                if (o != null)
                {
                    Personal.Domicilios.Remove(o);
                }
                else
                {
                    o = new Cosmos.Compras.Entidades.PersonalDomicilio();
                    o.PersonalID = Personal.PersonalID;
                    o.PersonalDomicilioID = new Random().Next(1, 9999) * -1;
                    o.DomicilioID = CastHelper.CInt2(e.NewValues["DomicilioID"]);
                }
                o.Calle = CastHelper.CStr2(e.NewValues["Calle"]);
                o.NumeroExterior = CastHelper.CStr2(e.NewValues["NumeroExterior"]);
                o.NumeroInterior = CastHelper.CStr2(e.NewValues["NumeroInterior"]);
                o.EntreCalle1 = CastHelper.CStr2(e.NewValues["EntreCalle1"]);
                o.EntreCalle2 = CastHelper.CStr2(e.NewValues["EntreCalle2"]);
                o.CodigoPostal = CastHelper.CInt2(e.NewValues["CodigoPostal"]);
                o.Colonia = CastHelper.CStr2(e.NewValues["Colonia"]);
                o.CiudadID = CastHelper.CInt2(e.NewValues["CiudadID"]);
                Personal.Domicilios.Add(o);
            }
            e.Cancel = true;
            gvPersonalDomicilios.CancelEdit();
            CargaPersonalDomicilios();

        }
    }
}