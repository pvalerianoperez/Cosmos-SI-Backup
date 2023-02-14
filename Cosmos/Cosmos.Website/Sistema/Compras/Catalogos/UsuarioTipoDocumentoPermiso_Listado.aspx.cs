using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class UsuarioTipoDocumentoPermiso_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("UsuarioTipoDocumentoPermiso_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("UsuarioTipoDocumentoPermiso_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int usuarioTipoDocumentoPermisoID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioTipoDocumentoPermisoID"]);
                    int usuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoDocumentoID"]);
                    int centroCostoID = CastHelper.CInt2(e.InsertValues[i].NewValues["CentroCostoID"]);
                    int areaID = CastHelper.CInt2(e.InsertValues[i].NewValues["AreaID"]);
                    int empresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                    int almacenID = CastHelper.CInt2(e.InsertValues[i].NewValues["AlmacenID"]);
                    int sucursalID = CastHelper.CInt2(e.InsertValues[i].NewValues["SucursalID"]);
                    bool preautoriza = CastHelper.CBool2(e.InsertValues[i].NewValues["Preautoriza"]);
                    decimal preautorizarMonto = CastHelper.CDecimal2(e.InsertValues[i].NewValues["PreautorizarMonto"]);
                    bool autoriza = CastHelper.CBool2(e.InsertValues[i].NewValues["Autoriza"]);
                    decimal autorizarMonto = CastHelper.CDecimal2(e.InsertValues[i].NewValues["AutorizarMonto"]);
                    Cosmos.Compras.Api.Client.UsuarioTipoDocumentoPermiso.Guardar(usuarioTipoDocumentoPermisoID, usuarioID, tipoDocumentoID, centroCostoID, areaID, empresaID, almacenID, sucursalID, preautoriza, preautorizarMonto, autoriza, autorizarMonto);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int usuarioTipoDocumentoPermisoID = CastHelper.CInt2(e.UpdateValues[i].Keys["UsuarioTipoDocumentoPermisoID"]);
                    int usuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UsuarioID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoDocumentoID"]);
                    int centroCostoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["CentroCostoID"]);
                    int areaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AreaID"]);
                    int empresaID = Website.Recursos.Utilerias.AppGlobals.EmpresaID;
                    int almacenID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AlmacenID"]);
                    int sucursalID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SucursalID"]);
                    bool preautoriza = CastHelper.CBool2(e.UpdateValues[i].NewValues["Preautoriza"]);
                    decimal preautorizarMonto = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["PreautorizarMonto"]);
                    bool autoriza = CastHelper.CBool2(e.UpdateValues[i].NewValues["Autoriza"]);
                    decimal autorizarMonto = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["AutorizarMonto"]);
                    Cosmos.Compras.Api.Client.UsuarioTipoDocumentoPermiso.Guardar(usuarioTipoDocumentoPermisoID, usuarioID, tipoDocumentoID, centroCostoID, areaID, empresaID, almacenID, sucursalID, preautoriza, preautorizarMonto, autoriza, autorizarMonto);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int usuarioTipoDocumentoPermisoID = CastHelper.CInt2(e.DeleteValues[i].Values["UsuarioTipoDocumentoPermisoID"]);
                    Cosmos.Compras.Api.Client.UsuarioTipoDocumentoPermiso.Eliminar(usuarioTipoDocumentoPermisoID);
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
