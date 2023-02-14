using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Fecha_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Fecha_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Fecha_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int fechaID = CastHelper.CInt2(e.InsertValues[i].NewValues["FechaID"]);
                    DateTime valor = CastHelper.CDate2(e.InsertValues[i].NewValues["Valor"]);
                    int personaID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonaID"]);
                    int tipoFechaID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoFechaID"]);
                    string comentario = CastHelper.CStr2(e.InsertValues[i].NewValues["Comentario"]);
                    Cosmos.Compras.Api.Client.Fecha.Guardar(fechaID, valor, personaID, tipoFechaID, comentario);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int fechaID = CastHelper.CInt2(e.UpdateValues[i].Keys["FechaID"]);
                    DateTime valor = CastHelper.CDate2(e.UpdateValues[i].NewValues["Valor"]);
                    int personaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonaID"]);
                    int tipoFechaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoFechaID"]);
                    string comentario = CastHelper.CStr2(e.UpdateValues[i].NewValues["Comentario"]);
                    Cosmos.Compras.Api.Client.Fecha.Guardar(fechaID, valor, personaID, tipoFechaID, comentario);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int fechaID = CastHelper.CInt2(e.DeleteValues[i].Values["FechaID"]);
                    Cosmos.Compras.Api.Client.Fecha.Eliminar(fechaID);
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
