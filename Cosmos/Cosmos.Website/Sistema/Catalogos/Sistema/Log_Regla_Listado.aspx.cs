


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

namespace Cosmos.Website.Sistema.Catalogos.Sistema
{
    public partial class Log_Regla_Listado : System.Web.UI.Page
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
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int sistemaLogReglaID = CastHelper.CInt2(e.InsertValues[i].NewValues["SistemaLogReglaID"]);
                int userID = CastHelper.CInt2(e.InsertValues[i].NewValues["UserID"]);
                string tablaNombre = CastHelper.CStr2(e.InsertValues[i].NewValues["TablaNombre"]);
                Boolean c = CastHelper.CBool2(e.InsertValues[i].NewValues["C"]);
                Boolean r = CastHelper.CBool2(e.InsertValues[i].NewValues["R"]);
                Boolean u = CastHelper.CBool2(e.InsertValues[i].NewValues["U"]);
                Boolean d = CastHelper.CBool2(e.InsertValues[i].NewValues["D"]);
                Cosmos.Sistema.Api.Client.LogRegla.Guardar(sistemaLogReglaID, userID, tablaNombre, c, r, u, d);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int sistemaLogReglaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SistemaLogReglaID"]);
                int userID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ClaseProductoClave"]);
                string tablaNombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                Boolean c = CastHelper.CBool2(e.InsertValues[i].NewValues["C"]);
                Boolean r = CastHelper.CBool2(e.InsertValues[i].NewValues["R"]);
                Boolean u = CastHelper.CBool2(e.InsertValues[i].NewValues["U"]);
                Boolean d = CastHelper.CBool2(e.InsertValues[i].NewValues["D"]);
                Cosmos.Sistema.Api.Client.LogRegla.Guardar(sistemaLogReglaID, userID, tablaNombre, c, r, u, d);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int sistemaLogReglaID = CastHelper.CInt2(e.DeleteValues[i].Values["SistemaLogReglaID"]);
                Cosmos.Sistema.Api.Client.LogRegla.Eliminar(sistemaLogReglaID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
