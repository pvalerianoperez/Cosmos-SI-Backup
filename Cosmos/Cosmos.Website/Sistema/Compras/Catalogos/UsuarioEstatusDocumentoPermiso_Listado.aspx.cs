using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class UsuarioEstatusDocumentoPermiso_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("UsuarioEstatusDocumentoPermiso_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("UsuarioEstatusDocumentoPermiso_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int usuarioEstatusDocumentoPermisoID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioEstatusDocumentoPermisoID"]);
                    int usuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioID"]);
                    int estatusDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["EstatusDocumentoID"]);
                    int centroCostoID = CastHelper.CInt2(e.InsertValues[i].NewValues["CentroCostoID"]);
                    int areaID = CastHelper.CInt2(e.InsertValues[i].NewValues["AreaID"]);
                    int empresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                    int almacenID = CastHelper.CInt2(e.InsertValues[i].NewValues["AlmacenID"]);
                    int sucursalID = CastHelper.CInt2(e.InsertValues[i].NewValues["SucursalID"]);
                    decimal monto = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Monto"]);
                    Cosmos.Compras.Api.Client.UsuarioEstatusDocumentoPermiso.Guardar(usuarioEstatusDocumentoPermisoID, usuarioID, estatusDocumentoID, centroCostoID, areaID, empresaID, almacenID, sucursalID, monto);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int usuarioEstatusDocumentoPermisoID = CastHelper.CInt2(e.UpdateValues[i].Keys["UsuarioEstatusDocumentoPermisoID"]);
                    int usuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UsuarioID"]);
                    int estatusDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["EstatusDocumentoID"]);
                    int centroCostoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["CentroCostoID"]);
                    int areaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AreaID"]);
                    int empresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                    int almacenID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AlmacenID"]);
                    int sucursalID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SucursalID"]);
                    decimal monto = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Monto"]);
                    Cosmos.Compras.Api.Client.UsuarioEstatusDocumentoPermiso.Guardar(usuarioEstatusDocumentoPermisoID, usuarioID, estatusDocumentoID, centroCostoID, areaID, empresaID, almacenID, sucursalID, monto);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int usuarioEstatusDocumentoPermisoID = CastHelper.CInt2(e.DeleteValues[i].Values["UsuarioEstatusDocumentoPermisoID"]);
                    Cosmos.Compras.Api.Client.UsuarioEstatusDocumentoPermiso.Eliminar(usuarioEstatusDocumentoPermisoID);
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
