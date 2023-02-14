using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Sistema.Catalogos
{
    public partial class LogRegla_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaLogRegla_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaLogRegla_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int sistemaLogReglaID = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaLogReglaID"]);
                    int userID = CastHelper.CInt2(e.InsertValues[i].NewValues["UserID"]);
                    string tablaNombre = CastHelper.CStr2(e.InsertValues[i].NewValues["TablaNombre"]);
                    bool c = CastHelper.CBool2(e.InsertValues[i].NewValues["C"]);
                    bool r = CastHelper.CBool2(e.InsertValues[i].NewValues["R"]);
                    bool u = CastHelper.CBool2(e.InsertValues[i].NewValues["U"]);
                    bool d = CastHelper.CBool2(e.InsertValues[i].NewValues["D"]);
                    Cosmos.Sistema.Api.Client.LogRegla.Guardar(sistemaLogReglaID, userID, tablaNombre, c, r, u, d);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int sistemaLogReglaID = CastHelper.CInt2(e.UpdateValues[i].Keys["SistemaLogReglaID"]);
                    int userID = CastHelper.CInt2(e.UpdateValues[i].NewValues["UserID"]);
                    string tablaNombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["TablaNombre"]);
                    bool c = CastHelper.CBool2(e.UpdateValues[i].NewValues["C"]);
                    bool r = CastHelper.CBool2(e.UpdateValues[i].NewValues["R"]);
                    bool u = CastHelper.CBool2(e.UpdateValues[i].NewValues["U"]);
                    bool d = CastHelper.CBool2(e.UpdateValues[i].NewValues["D"]);
                    Cosmos.Sistema.Api.Client.LogRegla.Guardar(sistemaLogReglaID, userID, tablaNombre, c, r, u, d);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int sistemaLogReglaID = CastHelper.CInt2(e.DeleteValues[i].Values["SistemaLogReglaID"]);
                    Cosmos.Sistema.Api.Client.LogRegla.Eliminar(sistemaLogReglaID);
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
