using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Sistema.Catalogos
{
    public partial class BitacoraEstatus_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaBitacoraEstatus_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaBitacoraEstatus_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int bitacoraEstatusID = CastHelper.CInt2(e.InsertValues[i].NewValues["BitacoraEstatusID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoDocumentoID"]);
                    int documentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["DocumentoID"]);
                    int usuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["UsuarioID"]);
                    int sistemaEstatusDocumentoID = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaEstatusDocumentoID"]);
                    int sistemaEstatusDocumentoIDAnterior = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaEstatusDocumentoIDAnterior"]);
                    DateTime fechaHora = CastHelper.CDate2(e.InsertValues[i].NewValues["FechaHora"]);
                    Cosmos.Sistema.Api.Client.BitacoraEstatus.Guardar(bitacoraEstatusID, tipoDocumentoID, documentoID, usuarioID, sistemaEstatusDocumentoID, sistemaEstatusDocumentoIDAnterior, fechaHora);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int bitacoraEstatusID = CastHelper.CInt2(e.UpdateValues[i].Keys["BitacoraEstatusID"]);
                    int tipoDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoDocumentoID"]);
                    int documentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["DocumentoID"]);
                    int usuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UsuarioID"]);
                    int sistemaEstatusDocumentoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SistemaEstatusDocumentoID"]);
                    int sistemaEstatusDocumentoIDAnterior = CastHelper.CInt2(e.UpdateValues[i].NewValues["SistemaEstatusDocumentoIDAnterior"]);
                    DateTime fechaHora = CastHelper.CDate2(e.UpdateValues[i].NewValues["FechaHora"]);
                    Cosmos.Sistema.Api.Client.BitacoraEstatus.Guardar(bitacoraEstatusID, tipoDocumentoID, documentoID, usuarioID, sistemaEstatusDocumentoID, sistemaEstatusDocumentoIDAnterior, fechaHora);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int bitacoraEstatusID = CastHelper.CInt2(e.DeleteValues[i].Values["BitacoraEstatusID"]);
                    Cosmos.Sistema.Api.Client.BitacoraEstatus.Eliminar(bitacoraEstatusID);
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
