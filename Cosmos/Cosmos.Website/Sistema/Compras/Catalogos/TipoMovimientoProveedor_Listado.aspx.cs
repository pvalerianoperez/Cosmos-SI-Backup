using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class TipoMovimientoProveedor_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("TipoMovimientoProveedor_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("TipoMovimientoProveedor_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            } 
            //estos no se deben mostrar porque se manejaran desde el grid.
            ((SitioProtegido)this.Master).MenuAcciones().mnModificar.Visible = false;
            ((SitioProtegido)this.Master).MenuAcciones().mnEliminar.Visible = false;
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            if (((SitioProtegido)this.Master).PermisoAccion("AGREGAR"))
            {
                for (int i = 0; i < e.InsertValues.Count; i++)
                {
                    int tipoMovimientoProveedorID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoMovimientoProveedorID"]);
                    string tipoMovimientoProveedorClave = CastHelper.CStr2(e.InsertValues[i].NewValues["TipoMovimientoProveedorClave"]);
                    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                    int naturalezaID = CastHelper.CInt2(e.InsertValues[i].NewValues["NaturalezaID"]);
                    Cosmos.Compras.Api.Client.TipoMovimientoProveedor.Guardar(tipoMovimientoProveedorID, tipoMovimientoProveedorClave, nombre, nombreCorto, naturalezaID);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int tipoMovimientoProveedorID = CastHelper.CInt2(e.UpdateValues[i].Keys["TipoMovimientoProveedorID"]);
                    string tipoMovimientoProveedorClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["TipoMovimientoProveedorClave"]);
                    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                    int naturalezaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["NaturalezaID"]);
                    Cosmos.Compras.Api.Client.TipoMovimientoProveedor.Guardar(tipoMovimientoProveedorID, tipoMovimientoProveedorClave, nombre, nombreCorto, naturalezaID);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int tipoMovimientoProveedorID = CastHelper.CInt2(e.DeleteValues[i].Values["TipoMovimientoProveedorID"]);
                    Cosmos.Compras.Api.Client.TipoMovimientoProveedor.Eliminar(tipoMovimientoProveedorID);
                }
            }
            e.Handled = true;
            Grid.DataBind();

        }
        
        protected void Grid_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            switch (e.Text) {
                case "Nuevo":
                    e.Visible = ((SitioProtegido)this.Master).PermisoAccion("AGREGAR");
                    break;
                case "Eliminar":
                    if (e.VisibleIndex<0){
                        e.Visible = true; //eliminar siempre visible para nuevos renglones
                    }
                    else {
                        e.Visible = ((SitioProtegido)this.Master).PermisoAccion("ELIMINAR");
                    }
                    
                    break;
            }
        }
    }
}
