using Cosmos.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Sistema.Compras.Capturas
{
    public partial class OrdenesCompra : System.Web.UI.Page
    {
        public List<Cosmos.Compras.Entidades.OrdenCompraDetalle> OCDetalleDS
        {
            get
            {
                if (Session["OrdenesCompra_OCDetalleDS"] == null) { Session["OrdenesCompra_OCDetalleDS"] = new List<Cosmos.Compras.Entidades.OrdenCompraDetalle>(); }
                return (List<Cosmos.Compras.Entidades.OrdenCompraDetalle>)Session["OrdenesCompra_OCDetalleDS"];
            }
            set
            {
                Session["OrdenesCompra_OCDetalleDS"] = value;
            }
        }
        public int OCEncabezadoID { get { return CastHelper.CInt2(Session["OrdenesCompra_OCEncabezadoID"]); } set { Session["OrdenesCompra_OCEncabezadoID"] = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.OCDetalleDS = null;
                dtFechaInicial.Date = System.DateTime.Today.AddMonths(-1);
                dtFechaFinal.Date = System.DateTime.Today;
                chkMostrarActivos.Checked = true;
                chkMostrarPendientes.Checked = true;
            }
            gvOCDetalle.DataSource = this.OCDetalleDS;
            gvOCDetalle.DataBind();
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
                Cosmos.Compras.Entidades.OrdenCompraEncabezado enc;
                Cosmos.Compras.Entidades.OrdenCompraDetalle det;
                switch (accion)
                {
                    case "EDITAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        this.OCEncabezadoID = id;

                        enc = null;
                        this.OCDetalleDS = null;
                        gvOCDetalle.DataSource = this.OCDetalleDS;
                        gvOCDetalle.DataBind();

                        //limpia encabezado
                        
                        txtFolio.Text = "";
                        txtFecha.Date = System.DateTime.Today;
                        txtReferencia.Text = "";
                        ddlSolicitante.SelectedIndex = -1;
                        ddlSucursal.SelectedIndex = -1;
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
                        txtDetalleCantidad.Text = "";
                        ddlDetalleProducto.Value = null;
                        ddlDetalleUnidad.SelectedIndex = -1;
                        txtCosto.Text = "";
                        txtFechaCompromiso.Text = "";

                        if (this.OCEncabezadoID > 0)
                        {
                            //this.OCDetalleDS = Cosmos.Compras.Api.Client.OCDetalle.ListadoOCEncabezadoID(this.OCEncabezadoID);
                            //gvOCDetalle.DataSource = this.OCDetalleDS;
                            //gvOCDetalle.DataBind();
                            enc = Cosmos.Compras.Api.Client.OrdenCompraEncabezado.Consultar(this.OCEncabezadoID);
                            if (enc != null)
                            {
                                
                                txtFecha.Date = enc.Fecha;
                                txtReferencia.Text = enc.Referencia;
                                txtFolio.Text = enc.Folio.ToString();
                                ddlSolicitante.SelectedItem = ddlSolicitante.Items.FindByValue(enc.PersonalID);
                                ddlSucursal.SelectedItem = ddlSucursal.Items.FindByValue(enc.SucursalID);
                                ddlSerie.DataBind();
                                ddlSerie.SelectedItem = ddlSerie.Items.FindByValue(enc.SerieID);
                                ddlProveedor.SelectedItem = ddlProveedor.Items.FindByValue(enc.ProveedorID);
                                txtConcepto.Text = enc.Concepto;
                                ddlEstatus.SelectedItem = ddlEstatus.Items.FindByValue(enc.EstatusDocumentoID);
                                chkAutorizada.Checked = enc.Autorizada;
                                chkPreAutorizada.Checked = enc.PreAutorizada;
                                //lblUsuarioAutorizo.Text = "";
                                //lblUsuarioPreAutorizo.Text = "";
                                //lblFechaPreAutorizacion.Text = "";
                                //lblFechaAutorizacion.Text = "";
                                this.OCDetalleDS = enc.Detalles;

                            }

                        }
                        gvOCDetalle.DataSource = this.OCDetalleDS;
                        gvOCDetalle.DataBind();
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                        break;
                    case "ELIMINAR":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        this.OCEncabezadoID = id;
                        if (this.OCEncabezadoID > 0)
                        {
                            try
                            {
                                Cosmos.Compras.Api.Client.OrdenCompraEncabezado.Eliminar(this.OCEncabezadoID);
                                cbpEditar.JSProperties["cp_show"] = 0;
                                cbpEditar.JSProperties["cp_refresh"] = 1;
                                cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                                cbpEditar.JSProperties["cp_errorMessage"] = "";
                            }
                            catch (Exception ex)
                            {                                
                                cbpEditar.JSProperties["cp_show"] = 0;
                                cbpEditar.JSProperties["cp_refresh"] = 0;
                                cbpEditar.JSProperties["cp_refreshDetalle"] = 0;
                                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
                            }

                        }

                        break;
                    case "DETALLE":
                        Cosmos.Compras.Entidades.OrdenCompraDetalle rd = new Cosmos.Compras.Entidades.OrdenCompraDetalle();
                        rd.Cantidad = CastHelper.CDbl2(txtDetalleCantidad.Value);
                        rd.ProductoID = CastHelper.CInt2(ddlDetalleProducto.Value);
                        if (ddlDetalleUnidad.SelectedItem != null) { rd.UnidadID = CastHelper.CInt2(ddlDetalleUnidad.SelectedItem.Value); }
                        rd.OrdenCompraEncabezadoID = this.OCEncabezadoID;
                        if (this.OCDetalleDS == null) { this.OCDetalleDS = new List<Cosmos.Compras.Entidades.OrdenCompraDetalle>(); }
                        rd.FechaCompromiso = txtFechaCompromiso.Date;
                        rd.Costo = CastHelper.CDbl2(txtCosto.Value);

                        rd.RenglonID = this.OCDetalleDS.Count + 1;
                        this.OCDetalleDS.Add(rd);

                        //limpia los datos de la edicion
                        txtDetalleCantidad.Text = "";
                        ddlDetalleProducto.Value = null;
                        ddlDetalleUnidad.SelectedIndex = -1;
                        txtFechaCompromiso.Text = "";
                        txtCosto.Text = "";
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;
                        break;
                    case "EDITAR_DETALLE":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        det = this.OCDetalleDS.Single(s => s.RenglonID == id);
                        //carga los datos de la edicion
                        txtDetalleCantidad.Value = det.Cantidad;
                        ddlDetalleProducto.Value = det.ProductoID;
                        ddlDetalleUnidad.SelectedItem = ddlDetalleUnidad.Items.FindByValue(det.UnidadID);
                        txtFechaCompromiso.Value = det.FechaCompromiso;
                        txtCosto.Value = det.Costo;
                        //quita el renglon
                        this.OCDetalleDS.RemoveAll(x => x.RenglonID == id);
                        //actualiza la numeracion de los renglones
                        for (int i = 0; i < this.OCDetalleDS.Count; i++)
                        {
                            this.OCDetalleDS[i].RenglonID = i + 1;
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;
                        break;
                    case "ELIMINAR_DETALLE":
                        if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                        //quita el renglon
                        this.OCDetalleDS.RemoveAll(x => x.RenglonID == id);
                        //actualiza la numeracion de los renglones
                        for (int i = 0; i < this.OCDetalleDS.Count; i++)
                        {
                            this.OCDetalleDS[i].RenglonID = i + 1;
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        cbpEditar.JSProperties["cp_refreshDetalle"] = 1;
                        break;
                    case "GUARDAR":
                        if (this.OCDetalleDS.Count > 0)
                        {
                            //if (datos.Length > 1) { id = CastHelper.CInt2(datos[1]); }
                            //this.OCEncabezadoID = id;
                            enc = Cosmos.Compras.Api.Client.OrdenCompraEncabezado.Consultar(this.OCEncabezadoID);
                            if (ddlSerie.SelectedItem != null) { enc.SerieID = CastHelper.CInt2(ddlSerie.SelectedItem.Value); } else { if (ddlSerie.Value != null){ enc.SerieID = CastHelper.CInt2(ddlSerie.Value); } }
                            enc.Fecha = CastHelper.CDate2(txtFecha.Value);
                            enc.Referencia = txtReferencia.Text;
                            if (ddlSolicitante.SelectedItem != null) { enc.PersonalID = CastHelper.CInt2(ddlSolicitante.SelectedItem.Value); }
                            if (ddlSucursal.SelectedItem != null) { enc.SucursalID = CastHelper.CInt2(ddlSucursal.SelectedItem.Value); }
                            enc.Concepto = txtConcepto.Text;
                            if (ddlEstatus.SelectedItem != null) { enc.EstatusDocumentoID = CastHelper.CInt2(ddlEstatus.SelectedItem.Value); }
                            if (ddlProveedor.SelectedItem != null) { enc.ProveedorID = CastHelper.CInt2(ddlProveedor.SelectedItem.Value); }
                            //explosion
                            enc.PreAutorizada = chkPreAutorizada.Checked;
                            enc.Autorizada = chkAutorizada.Checked;
                            enc.Detalles = this.OCDetalleDS;
                            Cosmos.Compras.Api.Client.OrdenCompraEncabezado.Guardar(enc);

                        }
                        else
                        {
                            throw new Exception("Debe capturar el detalle de la orden de compra.");
                        }

                        //cbpEditar.JSProperties["cp_show"] = 0;
                        //cbpEditar.JSProperties["cp_refresh"] = 1;
                        break;

                }
            }
            catch (Exception ex)
            {
                cbpEditar.JSProperties["cp_show"] = 1;
                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void gvOCDetalle_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            switch (e.Parameters)
            {
                case "refresh":
                    gvOCDetalle.DataSource = this.OCDetalleDS;
                    gvOCDetalle.DataBind();
                    break;
            }
        }

        protected void Grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh")
            {

                DataTable dt = Cosmos.Compras.Api.Client.OrdenCompraEncabezado.ListadoFiltros(new Api.Entidades.ConsultaDocumentos()
                {
                    FechaInicial = dtFechaInicial.Date,
                    FechaFinal = dtFechaFinal.Date,
                    EmpresaID = Recursos.Utilerias.AppGlobals.EmpresaID,
                    SucursalID = 0,
                    TipoDocumentoID = new int[] { 3 },
                    IncluirPendientes = chkMostrarPendientes.Checked,
                    IncluirTerminados = chkMostrarActivos.Checked
                });
                Grid.DataSource = dt;
                Grid.DataBind();
            }
        }

        protected void ddlSerie_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "refresh") {
                ddlSerie.DataBind();
            }
        }
    }
}