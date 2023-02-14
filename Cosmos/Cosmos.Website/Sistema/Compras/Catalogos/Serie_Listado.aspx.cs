using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Serie_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Serie_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Serie_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int serieID = CastHelper.CInt2(e.InsertValues[i].NewValues["SerieID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoDocumentoID"]);
                    string serieClave = CastHelper.CStr2(e.InsertValues[i].NewValues["SerieClave"]);
                    int folioInicial = CastHelper.CInt2(e.InsertValues[i].NewValues["FolioInicial"]);
                    int folioFinal = CastHelper.CInt2(e.InsertValues[i].NewValues["FolioFinal"]);
                    int ultimoFolio = CastHelper.CInt2(e.InsertValues[i].NewValues["UltimoFolio"]);
                    bool estatus = CastHelper.CBool2(e.InsertValues[i].NewValues["Estatus"]);
                    bool predeterminado = CastHelper.CBool2(e.InsertValues[i].NewValues["Predeterminado"]);
                    int sucursalID = CastHelper.CInt2(e.InsertValues[i].NewValues["SucursalID"]);
                    Cosmos.Compras.Api.Client.Serie.Guardar(serieID, tipoDocumentoID, serieClave, folioInicial, folioFinal, ultimoFolio, estatus, predeterminado, sucursalID);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int serieID = CastHelper.CInt2(e.UpdateValues[i].Keys["SerieID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoDocumentoID"]);
                    string serieClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["SerieClave"]);
                    int folioInicial = CastHelper.CInt2(e.UpdateValues[i].NewValues["FolioInicial"]);
                    int folioFinal = CastHelper.CInt2(e.UpdateValues[i].NewValues["FolioFinal"]);
                    int ultimoFolio = CastHelper.CInt2(e.UpdateValues[i].NewValues["UltimoFolio"]);
                    bool estatus = CastHelper.CBool2(e.UpdateValues[i].NewValues["Estatus"]);
                    bool predeterminado = CastHelper.CBool2(e.UpdateValues[i].NewValues["Predeterminado"]);
                    int sucursalID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SucursalID"]);
                    Cosmos.Compras.Api.Client.Serie.Guardar(serieID, tipoDocumentoID, serieClave, folioInicial, folioFinal, ultimoFolio, estatus, predeterminado, sucursalID);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int serieID = CastHelper.CInt2(e.DeleteValues[i].Values["SerieID"]);
                    Cosmos.Compras.Api.Client.Serie.Eliminar(serieID);
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
