


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using Newtonsoft.Json;
using Cosmos.Framework;

namespace Cosmos.Website.Sistema.Catalogos.Compras
{
    public partial class Producto_Listado : System.Web.UI.Page
    {
        //public List<Cosmos.Compras.Entidades.ProductoEmpresa> EmpresaDS
        //{
        //    get
        //    {
        //        if (Session["Producto_Listado_EmpresaDS"] == null) { Session["Producto_Listado_EmpresaDS"] = new List<Cosmos.Compras.Entidades.ProductoEmpresa>(); }
        //        return (List<Cosmos.Compras.Entidades.ProductoEmpresa>)Session["Producto_Listado_EmpresaDS"];
        //    }
        //    set
        //    {
        //        Session["Producto_Listado_EmpresaDS"] = value;
        //    }
        //}

    

        public int FamiliaProductoID { get { return CastHelper.CInt2(Session["Producto_Listado_FamiliaProductoID"]); } set { Session["Producto_Listado_FamiliaProductoID"] = value; } }
        //public int ProductoID { get { return CastHelper.CInt2(Session["Producto_Listado_ProductoID"]); } set { Session["Producto_Listado_ProductoID"] = value; } }
        public Cosmos.Compras.Entidades.Producto Producto { get { return (Cosmos.Compras.Entidades.Producto)Session["Producto_Listado_Producto"]; } set { Session["Producto_Listado_Producto"] = value; } }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    gvExportarProductos.DataBind();
                    gvExportarProductos.WriteXlsxToResponse(string.Format("Producto_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    gvExportarProductos.DataBind();
                    gvExportarProductos.WritePdfToResponse(string.Format("Producto_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }
            
            List<Cosmos.Compras.Entidades.FamiliaProducto> lst = Cosmos.Compras.Api.Client.FamiliaProducto.Listado();
            lst.Add(new Cosmos.Compras.Entidades.FamiliaProducto() { Nombre = "Todas", FamiliaProductoID = 0 });
            tvFamiliaProducto.DataSource = lst;
            tvFamiliaProducto.DataBind();
            if (Producto != null)
            {
                gvProductoAlmacen.DataSource = Producto.Almacenes;
                gvProductoAlmacen.DataBind();
            }
            else {
                gvProductoAlmacen.DataSource = null;
                gvProductoAlmacen.DataBind();
            }
            
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            ////insert
            //for (int i = 0; i < e.InsertValues.Count; i++)
            //{
            //    int productoID = CastHelper.CInt2(e.InsertValues[i].NewValues["ProductoID"]);
            //    int marcaID = CastHelper.CInt2(e.InsertValues[i].NewValues["MarcaID"]);
            //    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
            //    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
            //    int unidadID = CastHelper.CInt2(e.InsertValues[i].NewValues["UnidadID"]);
            //    int claseProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["ClaseProductoID"]);
            //    int tipoProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoProductoID"]);
            //    int nivelProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["NivelProductoID"]);
            //    int metodoCosteoID = CastHelper.CInt2(e.InsertValues[i].NewValues["MetodoCosteoID"]);
            //    bool manejaLotes = CastHelper.CBool2(e.InsertValues[i].NewValues["ManejaLotes"]);
            //    bool manejaSeries = CastHelper.CBool2(e.InsertValues[i].NewValues["ManejaSeries"]);
            //    decimal reorden = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Reorden"]);
            //    int familiaProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["FamiliaProductoID"]);
            //    int estatusProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["EstatusProductoID"]);
            //    Cosmos.Compras.Api.Client.Producto.Guardar(productoID, marcaID, nombre, nombreCorto, unidadID, claseProductoID, tipoProductoID, nivelProductoID, metodoCosteoID, manejaLotes, manejaSeries, reorden, familiaProductoID, estatusProductoID);
            //}
            ////update
            //for (int i = 0; i < e.UpdateValues.Count; i++)
            //{
            //    int productoID = CastHelper.CInt2(e.UpdateValues[i].Keys["ProductoID"]);
            //    int marcaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["MarcaID"]);
            //    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
            //    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
            //    int unidadID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UnidadID"]);
            //    int claseProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ClaseProductoID"]);
            //    int tipoProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoProductoID"]);
            //    int nivelProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["NivelProductoID"]);
            //    int metodoCosteoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["MetodoCosteoID"]);
            //    bool manejaLotes = CastHelper.CBool2(e.UpdateValues[i].NewValues["ManejaLotes"]);
            //    bool manejaSeries = CastHelper.CBool2(e.UpdateValues[i].NewValues["ManejaSeries"]);
            //    decimal reorden = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Reorden"]);
            //    int familiaProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["FamiliaProductoID"]);
            //    int estatusProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["EstatusProductoID"]);
            //    Cosmos.Compras.Api.Client.Producto.Guardar(productoID, marcaID, nombre, nombreCorto, unidadID, claseProductoID, tipoProductoID, nivelProductoID, metodoCosteoID, manejaLotes, manejaSeries, reorden, familiaProductoID, estatusProductoID);
            //}
            ////delete
            //for (int i = 0; i < e.DeleteValues.Count; i++)
            //{
            //    int productoID = CastHelper.CInt2(e.DeleteValues[i].Values["ProductoID"]);
            //    Cosmos.Compras.Api.Client.Producto.Eliminar(productoID);
            //}
            //e.Handled = true;
            //gvProductos.DataBind();

        }

        protected void cbpEditarFamiliaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] parametros = e.Parameter.Split('|');
            Cosmos.Compras.Entidades.FamiliaProducto o;
            cbpEditarFamiliaProducto.JSProperties["cp_refresh"] = "";
            cbpEditarFamiliaProducto.JSProperties["cp_errorMessage"] = "";
            
            try
            {
                if (parametros.Length > 0)
                {
                    switch (parametros[0])
                    {
                        case "EDITAR":
                            FamiliaProductoID = CastHelper.CInt2(parametros[1]);
                            o = Cosmos.Compras.Api.Client.FamiliaProducto.Consultar(FamiliaProductoID);
                            txtNombre.Text = o.Nombre;
                            txtNombreCorto.Text = o.NombreCorto;
                            txtClave.Text = o.FamiliaClave;
                            btnEliminarFamilia.Enabled = (FamiliaProductoID > 0);
                            btnGuardarFamilia.Enabled = btnEliminarFamilia.Enabled;
                            btnAgregarSubFamilia.Enabled = btnEliminarFamilia.Enabled;
                            break;
                        case "GUARDAR":
                            o = Cosmos.Compras.Api.Client.FamiliaProducto.Consultar(FamiliaProductoID);
                            o.Nombre = txtNombre.Text;
                            o.NombreCorto = txtNombreCorto.Text;
                            o.FamiliaClave = txtClave.Text;
                            o = Cosmos.Compras.Api.Client.FamiliaProducto.Guardar(FamiliaProductoID, o.PadreID, o.FamiliaClave, o.FamiliaClavePadre, o.Nombre, o.NombreCorto);
                            btnEliminarFamilia.Enabled = (FamiliaProductoID > 0);
                            btnGuardarFamilia.Enabled = btnEliminarFamilia.Enabled;
                            btnAgregarSubFamilia.Enabled = btnEliminarFamilia.Enabled;
                            cbpEditarFamiliaProducto.JSProperties["cp_refresh"] = "1";
                            break;
                        case "ELIMINAR":
                            Cosmos.Compras.Api.Client.FamiliaProducto.Eliminar(FamiliaProductoID);
                            txtNombre.Text = "";
                            txtNombreCorto.Text = "";
                            txtClave.Text = "";
                            FamiliaProductoID = 0;
                            cbpEditarFamiliaProducto.JSProperties["cp_refresh"] = "1";
                            break;
                        
                    }
                }
            }
            catch (Exception ex) {
                cbpEditarFamiliaProducto.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void tvFamiliaProducto_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {
            tvFamiliaProducto.DataBind();
            DevExpress.Web.ASPxTreeList.TreeListNode n = tvFamiliaProducto.FindNodeByKeyValue(FamiliaProductoID.ToString());
            if (n != null) {
                n.Selected = true;
            }            
        }

        protected void cbpEditarSubFamiliaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] parametros = e.Parameter.Split('|');
            Cosmos.Compras.Entidades.FamiliaProducto o;
            cbpEditarSubFamiliaProducto.JSProperties["cp_refresh"] = "";
            cbpEditarSubFamiliaProducto.JSProperties["cp_errorMessage"] = "";
            cbpEditarSubFamiliaProducto.JSProperties["cp_show"] = "";

            try
            {
                if (parametros.Length > 0)
                {
                    switch (parametros[0])
                    {
                        case "GUARDAR":
                            o = new Cosmos.Compras.Entidades.FamiliaProducto();
                            o.Nombre = txtSubFamiliaNombre.Text;
                            o.NombreCorto = txtSubFamiliaNombreCorto.Text;
                            o.FamiliaClave = txtSubFamiliaClave.Text;
                            o.PadreID = FamiliaProductoID;
                            o = Cosmos.Compras.Api.Client.FamiliaProducto.Guardar(0, o.PadreID, o.FamiliaClave, o.FamiliaClavePadre, o.Nombre, o.NombreCorto);
                            cbpEditarSubFamiliaProducto.JSProperties["cp_refresh"] = "1";
                            cbpEditarSubFamiliaProducto.JSProperties["cp_show"] = "0";
                            break;                       
                    }
                }
            }
            catch (Exception ex)
            {
                cbpEditarSubFamiliaProducto.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void gvProducto_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh") {
                gvProducto.DataBind();
            }
        }

        protected void cbpEditarProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] parametros = e.Parameter.Split('|');
            string accion = "";
            string valor = "";
            //Producto = null;
            int id = -1;
            Cosmos.Compras.Entidades.ProductoEmpresa pe = null;
            cbpEditarProducto.JSProperties["cp_refresh"] = "";
            cbpEditarProducto.JSProperties["cp_errorMessage"] = "";
            cbpEditarProducto.JSProperties["cp_show"] = "";
            cbpEditarProducto.JSProperties["cp_refreshAlmacenes"] = "";
            
            try
            {
                if (parametros.Length > 0) { accion = parametros[0]; }
                if (parametros.Length > 1) { valor = parametros[1]; }
                if (parametros.Length > 0)
                {
                    switch (accion)
                    {
                        case "EDITAR":
                            int productoID = CastHelper.CInt2(valor);
                            if (productoID > 0){
                                this.Producto = Cosmos.Compras.Api.Client.Producto.Consultar(productoID);
                            }
                            else {
                                this.Producto = new Cosmos.Compras.Entidades.Producto();
                            }
                            
                            
                            Funciones.SetControlValue(ref txtProductoNombre, Producto.Nombre);
                            Funciones.SetControlValue(ref txtProductoNombreCorto, Producto.NombreCorto);
                            Funciones.SetControlValue(ref ddlUnidadID, Producto.UnidadID);
                            Funciones.SetControlValue(ref ddlClaseID, Producto.ClaseProductoID);
                            Funciones.SetControlValue(ref ddlTipoProductoID, Producto.TipoProductoID); 
                            Funciones.SetControlValue(ref ddlNivelProductoID, Producto.NivelProductoID);
                            Funciones.SetControlValue(ref ddlMetodoCosteoID, Producto.MetodoCosteoID);

                            if (Producto.ProductoID == 0 && FamiliaProductoID > 0)
                            {
                                //cuando es nuevo y se tiene seleccionada una familia, por default elige la familia actual
                                Funciones.SetControlValue(ref ddlFamiliaProducto, FamiliaProductoID);
                            }
                            else {
                                //cuando es una edicion, por default selecciona la familia que tiene el producto
                                Funciones.SetControlValue(ref ddlFamiliaProducto, Producto.FamiliaProductoID);
                            }
                            
                            Funciones.SetControlValue(ref chkManejaLotes, Producto.ManejaLotes);
                            Funciones.SetControlValue(ref chkManejaSeries, Producto.ManejaSeries);
                            Funciones.SetControlValue(ref ddlEstatusProductoID, Producto.EstatusProductoID);
                            Funciones.SetControlValue(ref ddlMarcaID, Producto.MarcaID);

                            //clave del producto
                            pe = Producto.Empresas.Find(x => x.EmpresaID == Website.Recursos.Utilerias.AppGlobals.EmpresaID);
                            if (pe != null) {
                                Funciones.SetControlValue(ref txtProductoClave, pe.ProductoClave);
                            }

                            cbpEditarProducto.JSProperties["cp_refreshAlmacenes"] = "1";
                            cbpEditarProducto.JSProperties["cp_refresh"] = "0";
                            cbpEditarProducto.JSProperties["cp_show"] = "1";
                            break;
                        case "GUARDAR":
                            if (Producto != null) {
                                Producto.Nombre = Funciones.GetControlValue(txtProductoNombre);
                                Producto.NombreCorto = Funciones.GetControlValue(txtProductoNombreCorto);
                                Producto.UnidadID = Funciones.GetControlValue(ddlUnidadID);
                                Producto.ClaseProductoID = Funciones.GetControlValue(ddlClaseID);
                                Producto.TipoProductoID = Funciones.GetControlValue(ddlTipoProductoID);
                                Producto.NivelProductoID = Funciones.GetControlValue(ddlNivelProductoID);
                                Producto.MetodoCosteoID = Funciones.GetControlValue(ddlMetodoCosteoID);
                                Producto.FamiliaProductoID = Funciones.GetControlValue(ddlFamiliaProducto);
                                Producto.ManejaLotes = Funciones.GetControlValue(chkManejaLotes);
                                Producto.ManejaSeries = Funciones.GetControlValue(chkManejaSeries);
                                Producto.EstatusProductoID = Funciones.GetControlValue(ddlEstatusProductoID);
                                Producto.MarcaID = Funciones.GetControlValue(ddlMarcaID);

                                //guarda el codigo del producto
                                if (Producto.Empresas == null) { Producto.Empresas = new List<Cosmos.Compras.Entidades.ProductoEmpresa>(); }
                                if (Producto.Empresas.Find(x => x.EmpresaID == Website.Recursos.Utilerias.AppGlobals.EmpresaID) == null)
                                {
                                    pe = new Cosmos.Compras.Entidades.ProductoEmpresa();
                                    pe.EmpresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                                    pe.ProductoID = Producto.ProductoID;
                                    pe.ProductoClave = Funciones.GetControlValue(txtProductoClave);
                                    Producto.Empresas.Add(pe);
                                }
                                else
                                {
                                    Producto.Empresas.Find(x => x.EmpresaID == Website.Recursos.Utilerias.AppGlobals.EmpresaID).ProductoClave = Funciones.GetControlValue(txtProductoClave);
                                }
                                Cosmos.Compras.Api.Client.Producto.Guardar(Producto);
                                Producto = null;
                                cbpEditarProducto.JSProperties["cp_refreshAlmacenes"] = "1";
                                cbpEditarProducto.JSProperties["cp_refresh"] = "1";
                                cbpEditarProducto.JSProperties["cp_show"] = "0";
                                
                            }
                            break;
                        //o = Cosmos.Compras.Api.Client.Producto.Consultar(ProductoID);
                        //if (ddlMarcaID.SelectedItem != null) { o.MarcaID = CastHelper.CInt2(ddlMarcaID.SelectedItem.Value); }
                        //o.Nombre = txtProductoNombre.Text;
                        //o.NombreCorto = txtProductoNombreCorto.Text;
                        //if (ddlUnidadID.SelectedItem != null) { o.UnidadID = CastHelper.CInt2(ddlUnidadID.SelectedItem.Value); }
                        //if (ddlClaseID.SelectedItem != null) { o.ClaseProductoID = CastHelper.CInt2(ddlClaseID.SelectedItem.Value); }
                        //if (ddlTipoProductoID.SelectedItem != null) { o.TipoProductoID = CastHelper.CInt2(ddlTipoProductoID.SelectedItem.Value); }
                        //if (ddlNivelProductoID.SelectedItem != null) { o.NivelProductoID = CastHelper.CInt2(ddlNivelProductoID.SelectedItem.Value); }
                        //if (ddlMetodoCosteoID.SelectedItem != null) { o.MetodoCosteoID = CastHelper.CInt2(ddlMetodoCosteoID.SelectedItem.Value); }                            
                        //o.ManejaLotes = chkManejaLotes.Checked;
                        //if (o.Empresas.Find(x => x.EmpresaID == Website.Recursos.Utilerias.AppGlobals.EmpresaID) == null) {
                        //    Cosmos.Compras.Entidades.ProductoEmpresa pe = new Cosmos.Compras.Entidades.ProductoEmpresa();
                        //    pe.EmpresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                        //    pe.ProductoID = o.ProductoID;
                        //    pe.ProductoClave = txtProductoClave.Text;
                        //    o.Empresas.Add(pe);
                        //}
                        //else {
                        //    o.Empresas.Find(x => x.EmpresaID == Website.Recursos.Utilerias.AppGlobals.EmpresaID).ProductoClave = txtProductoClave.Text;
                        //}
                        //o.ManejaSeries = chkManejaSeries.Checked;                            
                        //if (ddlFamiliaProducto.SelectedItem != null) { o.FamiliaProductoID = CastHelper.CInt2(ddlFamiliaProducto.SelectedItem.Value); }
                        ////o.FamiliaProductoID = FamiliaProductoID;
                        //if (ddlEstatusProductoID.SelectedItem != null) { o.EstatusProductoID = CastHelper.CInt2(ddlEstatusProductoID.SelectedItem.Value); }                           
                        //o.Empresas = this.EmpresaDS;
                        //o = Cosmos.Compras.Api.Client.Producto.Guardar(o);

                        case "DETALLE_EMPRESA":
                            ////quita el renglon
                            //int empresaID = CastHelper.CInt2(ddlEmpresa.Value);
                            //if (empresaID > 0) {
                            //    foreach (Cosmos.Compras.Entidades.ProductoEmpresa pe in this.EmpresaDS)
                            //    {
                            //        if (pe.EmpresaID == empresaID) {
                            //            throw new Exception("Ya existe una clave para el producto en la empresa.");
                            //        }
                            //    }
                            //}                            
                            //det = new Cosmos.Compras.Entidades.ProductoEmpresa();
                            //det.ProductoClave = CastHelper.CStr2(txtProductoClave.Text);
                            //det.EmpresaID = CastHelper.CInt2(ddlEmpresa.Value);
                            //det.ProductoID = this.ProductoID;
                            //det.ProductoEmpresaID = new Random().Next(1000) * -1;
                            //this.EmpresaDS.Add(det);
                            ////limpia los datos de la edicion
                            //txtProductoClave.Text = "";
                            //ddlEmpresa.SelectedIndex = -1;
                            cbpEditarProducto.JSProperties["cp_show"] = 1;
                            cbpEditarProducto.JSProperties["cp_refresh"] = 0;
                            cbpEditarProducto.JSProperties["cp_refreshEmpresa"] = 1;

                            break;
                        case "EDITAR_EMPRESA":
                            //if (parametros.Length > 1) { id = CastHelper.CInt2(parametros[1]); }
                            //det = this.EmpresaDS.Single(s => s.ProductoEmpresaID == id);
                            ////carga los datos de la edicion
                            //ddlEmpresa.SelectedItem = ddlEmpresa.Items.FindByValue(det.EmpresaID);
                            //txtProductoClave.Text = det.ProductoClave;
                            ////quita el renglon
                            //this.EmpresaDS.RemoveAll(x => x.ProductoEmpresaID == id);
                            cbpEditarProducto.JSProperties["cp_show"] = 1;
                            cbpEditarProducto.JSProperties["cp_refresh"] = 0;
                            cbpEditarProducto.JSProperties["cp_refreshEmpresa"] = 1;
                            break;
                        case "ELIMINAR_EMPRESA":
                            //if (parametros.Length > 1) { id = CastHelper.CInt2(parametros[1]); }
                            ////quita el renglon
                            //this.EmpresaDS.RemoveAll(x => x.ProductoEmpresaID == id);                            
                            cbpEditarProducto.JSProperties["cp_show"] = 1;
                            cbpEditarProducto.JSProperties["cp_refresh"] = 0;
                            cbpEditarProducto.JSProperties["cp_refreshEmpresa"] = 1;
                            break;
                        case "ELIMINAR":
                            //ProductoID = CastHelper.CInt2(valor);
                            //Cosmos.Compras.Api.Client.Producto.Eliminar(ProductoID);
                            //ProductoID = 0;
                            cbpEditarProducto.JSProperties["cp_refresh"] = "1";                            
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                cbpEditarProducto.JSProperties["cp_errorMessage"] = ex.Message;
                cbpEditarProducto.JSProperties["cp_show"] = "1";
                if (accion == "ELIMINAR") {
                    cbpEditarProducto.JSProperties["cp_show"] = "0";
                }                
            }
        }

        protected void gvProductoAlmacen_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                if (Producto != null) {                                        
                    if (Producto.Almacenes == null) { Producto.Almacenes = new List<Cosmos.Compras.Entidades.ProductoAlmacen>(); }
                    Cosmos.Compras.Entidades.ProductoAlmacen pa = new Cosmos.Compras.Entidades.ProductoAlmacen();
                    pa.AlmacenID = CastHelper.CInt2(e.InsertValues[i].NewValues["AlmacenID"]); 
                    pa.ProductoID = this.Producto.ProductoID;
                    pa.Maximo = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Maximo"]);
                    pa.Minimo = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Minimo"]);
                    pa.Reorden = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Reorden"]);
                    Producto.Almacenes.Add(pa);
                }
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                if (Producto != null)
                {
                    if (Producto.Almacenes == null) { Producto.Almacenes = new List<Cosmos.Compras.Entidades.ProductoAlmacen>(); }
                    Cosmos.Compras.Entidades.ProductoAlmacen pa = Producto.Almacenes.Where(x => x.AlmacenID == CastHelper.CInt2(e.UpdateValues[i].Keys["AlmacenID"])).FirstOrDefault();
                    if (pa != null)
                    {
                        Producto.Almacenes.Remove(pa);
                    }
                    else {
                        pa = new Cosmos.Compras.Entidades.ProductoAlmacen();
                        pa.ProductoID = Producto.ProductoID;
                        pa.AlmacenID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AlmacenID"]); 
                    }
                    pa.Maximo = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Maximo"]);
                    pa.Minimo = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Minimo"]);
                    pa.Reorden = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Reorden"]);
                    Producto.Almacenes.Add(pa);
                }

            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                if (Producto != null) {
                    Cosmos.Compras.Entidades.ProductoAlmacen pa = Producto.Almacenes.Where(x => x.AlmacenID == CastHelper.CInt2(e.DeleteValues[i].Keys["AlmacenID"])).FirstOrDefault();
                    if (pa != null)
                    {
                        Producto.Almacenes.Remove(pa);
                    }
                }
            }
            e.Handled = true;

            gvProductoAlmacen.DataSource = null;
            if (Producto != null) {
                if (Producto.Almacenes != null) {
                    gvProductoAlmacen.DataSource = Producto.Almacenes;
                }
            }
            
            gvProductoAlmacen.DataBind();
        }

        protected void gvProductoAlmacen_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh") {
                if (Producto != null)
                {
                    gvProductoAlmacen.DataSource = Producto.Almacenes;
                }
                else {
                    gvProductoAlmacen.DataSource = null;
                }
                gvProductoAlmacen.DataBind();
            }
        }
    }
}
