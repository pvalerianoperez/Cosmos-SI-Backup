using Cosmos.Framework;
using Cosmos.Website.Recursos.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Sistema.Compras.Capturas
{
    public partial class Requisiciones : System.Web.UI.Page
    {
        public List<Cosmos.Compras.Entidades.RequisicionDetalle> RequisicionDetalleDS {
            get {
                if (Session["Requisiciones_RequisicionDetalleDS"] == null) { Session["Requisiciones_RequisicionDetalleDS"] = new List<Cosmos.Compras.Entidades.RequisicionDetalle>(); }
                return (List<Cosmos.Compras.Entidades.RequisicionDetalle>)Session["Requisiciones_RequisicionDetalleDS"];
            }
            set {
                Session["Requisiciones_RequisicionDetalleDS"] = value;
            }
        }
        public int RequisicionEncabezadoID { get { return CastHelper.CInt2(Session["Requisiciones_RequisicionEncabezadoID"]); } set { Session["Requisiciones_RequisicionEncabezadoID"] = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.RequisicionDetalleDS = null;
                dtFechaInicial.Date = System.DateTime.Today.AddMonths(-1);
                dtFechaFinal.Date = System.DateTime.Today;
                chkMostrarActivos.Checked = true;
                chkMostrarPendientes.Checked = true;
            }
            gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
            gvRequisicionDetalle.DataBind();
        }

        protected void cbpEditar_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditar.JSProperties["cp_refresh"] = "";
            cbpEditar.JSProperties["cp_show"] = "";
            cbpEditar.JSProperties["cp_errorMessage"] = "";
            try
            {
                string[] datos = e.Parameter.Split('|');
                string accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                int id = 0;
                Cosmos.Compras.Entidades.RequisicionEncabezado enc;
                Cosmos.Compras.Entidades.RequisicionDetalle det;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        this.RequisicionEncabezadoID = id;

                        enc = null;
                        this.RequisicionDetalleDS = null;
                        gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
                        gvRequisicionDetalle.DataBind();

                        //limpia encabezado
                        txtMovimiento.Text = "";
                        txtFecha.Date = System.DateTime.Today;
                        txtReferencia.Text = "";
                        ddlSolicitante.SelectedIndex = -1;
                        ddlSucursal.SelectedIndex = -1;
                        ddlCentroCosto.SelectedIndex = -1;
                        ddlArea.SelectedIndex = -1;
                        txtConcepto.Text = "";
                        ddlEstatus.SelectedIndex = -1;
                        chkAutorizada.Checked = false;
                        chkPreAutorizada.Checked = false;
                        lblUsuarioAutorizo.Text = "";
                        lblUsuarioPreAutorizo.Text = "";
                        lblFechaPreAutorizacion.Text = "";
                        lblFechaAutorizacion.Text = "";
                        ddlSerie.DataBind();
                        ddlSerie.SelectedIndex = -1;
                        //limpia detalle
                        ddlDetalleAlmacen.SelectedIndex = -1;
                        txtDetalleCantidad.Text = "";
                        ddlDetalleConceptoEgreso.SelectedIndex = -1;
                        ddlDetalleCuentaContable.SelectedIndex = -1;
                        txtDetalleDescripcion.Text = "";
                        ddlDetalleProducto.Value = null;
                        ddlDetalleUnidad.SelectedIndex = -1;
                        

                        if (this.RequisicionEncabezadoID > 0)
                        {
                            //this.RequisicionDetalleDS = Cosmos.Compras.Api.Client.RequisicionDetalle.ListadoRequisicionEncabezadoID(this.RequisicionEncabezadoID);
                            //gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
                            //gvRequisicionDetalle.DataBind();
                            enc = Cosmos.Compras.Api.Client.RequisicionEncabezado.Consultar(this.RequisicionEncabezadoID);
                            if (enc != null)
                            {
                                txtFecha.Date = enc.Fecha;
                                txtReferencia.Text = enc.Referencia;
                                txtMovimiento.Text = enc.Folio.ToString();
                                ddlSolicitante.SelectedItem = ddlSolicitante.Items.FindByValue(enc.PersonalID);
                                ddlSucursal.SelectedItem = ddlSucursal.Items.FindByValue(enc.SucursalID);
                                ddlSerie.DataBind();
                                ddlSerie.SelectedItem = ddlSerie.Items.FindByValue(enc.SerieID);
                                ddlCentroCosto.SelectedItem = ddlCentroCosto.Items.FindByValue(enc.CentroCostoID);
                                ddlArea.SelectedItem = ddlArea.Items.FindByValue(enc.AreaID);
                                txtConcepto.Text = enc.Concepto;
                                ddlEstatus.SelectedItem = ddlEstatus.Items.FindByValue(enc.EstatusDocumentoID);
                                chkAutorizada.Checked = enc.Autorizada;
                                chkPreAutorizada.Checked = enc.PreAutorizada;
                                //lblUsuarioAutorizo.Text = "";
                                //lblUsuarioPreAutorizo.Text = "";
                                //lblFechaPreAutorizacion.Text = "";
                                //lblFechaAutorizacion.Text = "";
                                this.RequisicionDetalleDS = enc.Detalles;
                                
                            }
                            
                        }
                        gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
                        gvRequisicionDetalle.DataBind();
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        this.RequisicionEncabezadoID = id;
                        if (this.RequisicionEncabezadoID > 0)
                        {
                            try
                            {
                                Cosmos.Compras.Api.Client.RequisicionEncabezado.Eliminar(this.RequisicionEncabezadoID);
                                cbpEditar.JSProperties["cp_show"] = 0;
                                cbpEditar.JSProperties["cp_refresh"] = 1;
                                cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                                cbpEditar.JSProperties["cp_errorMessage"] = "";
                            }
                            catch (Exception ex) {
                                gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
                                gvRequisicionDetalle.DataBind();
                                cbpEditar.JSProperties["cp_show"] = 0;
                                cbpEditar.JSProperties["cp_refresh"] = 0;
                                cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
                            }                                                        
                            
                        }
                        
                        break;
                    case "DETALLE":
                        Cosmos.Compras.Entidades.RequisicionDetalle rd = new Cosmos.Compras.Entidades.RequisicionDetalle();
                        if (ddlDetalleAlmacen.SelectedItem != null) { rd.AlmacenID = CastHelper.CInt2(ddlDetalleAlmacen.SelectedItem.Value); }
                        rd.Cantidad = CastHelper.CDbl2(txtDetalleCantidad.Value);
                        if (ddlDetalleConceptoEgreso.SelectedItem != null) { rd.ConceptoEgresoID = CastHelper.CInt2(ddlDetalleConceptoEgreso.SelectedItem.Value); }
                        if (ddlDetalleCuentaContable.SelectedItem != null) { rd.CuentaContableID = CastHelper.CInt2(ddlDetalleCuentaContable.SelectedItem.Value); }
                        rd.DescripcioAdicional = CastHelper.CStr2(txtDetalleDescripcion.Text);
                        rd.ProductoID = CastHelper.CInt2( ddlDetalleProducto.Value);
                        if (ddlDetalleUnidad.SelectedItem != null) { rd.UnidadID = CastHelper.CInt2(ddlDetalleUnidad.SelectedItem.Value); }
                        rd.RequisicionEncabezadoID = this.RequisicionEncabezadoID;
                        if (this.RequisicionDetalleDS == null) { this.RequisicionDetalleDS = new List<Cosmos.Compras.Entidades.RequisicionDetalle>(); }
                        rd.Renglon = this.RequisicionDetalleDS.Count + 1;
                        this.RequisicionDetalleDS.Add(rd);

                        //limpia los datos de la edicion
                        ddlDetalleAlmacen.SelectedIndex = -1;
                        txtDetalleCantidad.Text = "";
                        ddlDetalleConceptoEgreso.SelectedIndex = -1;
                        ddlDetalleCuentaContable.SelectedIndex = -1;
                        txtDetalleDescripcion.Text = "";
                        ddlDetalleProducto.Value = null;
                        ddlDetalleUnidad.SelectedIndex = -1;

                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;                        
                        break;
                    case "EDITAR_DETALLE":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        det = this.RequisicionDetalleDS.Single(s => s.Renglon == id);
                        //carga los datos de la edicion
                        ddlDetalleAlmacen.SelectedItem = ddlDetalleAlmacen.Items.FindByValue(det.AlmacenID);
                        txtDetalleCantidad.Value = det.Cantidad;
                        ddlDetalleConceptoEgreso.SelectedItem = ddlDetalleAlmacen.Items.FindByValue(det.AlmacenID);
                        ddlDetalleCuentaContable.SelectedItem = ddlDetalleCuentaContable.Items.FindByValue(det.CuentaContableID);
                        txtDetalleDescripcion.Text =det.DescripcioAdicional;
                        ddlDetalleProducto.Value = det.ProductoID;
                        ddlDetalleUnidad.SelectedItem = ddlDetalleUnidad.Items.FindByValue(det.UnidadID);
                        //quita el renglon
                        this.RequisicionDetalleDS.RemoveAll(x => x.Renglon == id);
                        //actualiza la numeracion de los renglones
                        for (int i = 0; i < this.RequisicionDetalleDS.Count; i++)
                        {
                            this.RequisicionDetalleDS[i].Renglon = i + 1;
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;
                        break;
                    case "ELIMINAR_DETALLE":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        //quita el renglon
                        this.RequisicionDetalleDS.RemoveAll(x => x.Renglon == id);
                        //actualiza la numeracion de los renglones
                        for (int i = 0; i < this.RequisicionDetalleDS.Count; i++)
                        {
                            this.RequisicionDetalleDS[i].Renglon = i + 1;
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;
                        break;
                    case "GUARDAR":
                        if (this.RequisicionDetalleDS.Count > 0)
                        {
                            //if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                            //this.RequisicionEncabezadoID = id;
                            enc = Cosmos.Compras.Api.Client.RequisicionEncabezado.Consultar(this.RequisicionEncabezadoID);
                            if (ddlSerie.SelectedItem != null) { enc.SerieID = CastHelper.CInt2(ddlSerie.SelectedItem.Value); } else { if (ddlSerie.Value != null) { enc.SerieID = CastHelper.CInt2(ddlSerie.Value); } }
                            enc.Fecha = CastHelper.CDate2(txtFecha.Value);
                            enc.Referencia = Funciones.GetControlValue(txtReferencia);
                            enc.Concepto = Funciones.GetControlValue(txtConcepto);
                            enc.PersonalID = Funciones.GetControlValue(ddlSolicitante);
                            enc.SucursalID = Funciones.GetControlValue(ddlSucursal);
                            enc.CentroCostoID = Funciones.GetControlValue(ddlCentroCosto);
                            enc.AreaID = Funciones.GetControlValue(ddlArea);
                            enc.EstatusDocumentoID = Funciones.GetControlValue(ddlEstatus);
                            //explosion
                            enc.PreAutorizada = chkPreAutorizada.Checked;
                            enc.Autorizada = chkAutorizada.Checked;
                            enc.Detalles = this.RequisicionDetalleDS;
                            Cosmos.Compras.Api.Client.RequisicionEncabezado.Guardar(enc);
                            cbpEditar.JSProperties["cp_show"] = 0;
                            cbpEditar.JSProperties["cp_refresh"] = 1;
                        }
                        else {
                            throw new Exception("Debe capturar el detalle de la requisición.");
                        }                        
                        break;

                }
            }
            catch (Exception ex)
            {
                cbpEditar.JSProperties["cp_show"] = 1;
                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void gvRequisicionDetalle_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            switch (e.Parameters) {
                case "refresh":
                    gvRequisicionDetalle.DataSource = this.RequisicionDetalleDS;
                    gvRequisicionDetalle.DataBind();
                    break;
            }
        }

        protected void Grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh") {
                Grid.DataSource = Cosmos.Compras.Api.Client.RequisicionEncabezado.ListadoFiltros(new Api.Entidades.ConsultaDocumentos()
                {
                    FechaInicial = dtFechaInicial.Date,
                    FechaFinal = dtFechaFinal.Date,
                    EmpresaID = Recursos.Utilerias.AppGlobals.EmpresaID,
                    SucursalID = 0,
                    TipoDocumentoID = new int[] { 1 },
                    IncluirPendientes = chkMostrarPendientes.Checked,
                    IncluirTerminados = chkMostrarActivos.Checked
                });
                Grid.DataBind();
            }            
        }

        protected void ddlSerie_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "refresh")
            {
                ddlSerie.DataBind();
            }
        }
    }
}