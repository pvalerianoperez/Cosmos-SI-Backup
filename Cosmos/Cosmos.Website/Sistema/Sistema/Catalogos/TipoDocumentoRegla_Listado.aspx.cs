using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Sistema.Catalogos
{
    public partial class TipoDocumentoRegla_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaTipoDocumentoRegla_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaTipoDocumentoRegla_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int tipoDocumentoReglaID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoDocumentoReglaID"]);
                    int sistemaEstatusTipoDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaEstatusTipoDocumentoID"]);
                    int sistemaEstatusTipoDocumentoIDPermite = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaEstatusTipoDocumentoIDPermite"]);
                    Cosmos.Sistema.Api.Client.TipoDocumentoRegla.Guardar(tipoDocumentoReglaID, sistemaEstatusTipoDocumentoID, sistemaEstatusTipoDocumentoIDPermite);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int tipoDocumentoReglaID = CastHelper.CInt2(e.UpdateValues[i].Keys["TipoDocumentoReglaID"]);
                    int sistemaEstatusTipoDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SistemaEstatusTipoDocumentoID"]);
                    int sistemaEstatusTipoDocumentoIDPermite = CastHelper.CInt2(e.UpdateValues[i].NewValues["SistemaEstatusTipoDocumentoIDPermite"]);
                    Cosmos.Sistema.Api.Client.TipoDocumentoRegla.Guardar(tipoDocumentoReglaID, sistemaEstatusTipoDocumentoID, sistemaEstatusTipoDocumentoIDPermite);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int tipoDocumentoReglaID = CastHelper.CInt2(e.DeleteValues[i].Values["TipoDocumentoReglaID"]);
                    Cosmos.Sistema.Api.Client.TipoDocumentoRegla.Eliminar(tipoDocumentoReglaID);
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
