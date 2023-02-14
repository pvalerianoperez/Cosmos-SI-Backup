


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
    public partial class DatoFacturacion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("DatoFacturacion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("DatoFacturacion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int datoFacturacionID = CastHelper.CInt2(e.InsertValues[i].NewValues["DatoFacturacionID"]);
                int personaID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonaID"]);
                string rFC = CastHelper.CStr2(e.InsertValues[i].NewValues["RFC"]);
                int domicilioID = CastHelper.CInt2(e.InsertValues[i].NewValues["DomicilioID"]);
                Cosmos.Compras.Api.Client.DatoFacturacion.Guardar(datoFacturacionID, personaID, rFC, domicilioID);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int datoFacturacionID = CastHelper.CInt2(e.UpdateValues[i].Keys["DatoFacturacionID"]);
                int personaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonaID"]);
                string rFC = CastHelper.CStr2(e.UpdateValues[i].NewValues["RFC"]);
                int domicilioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["DomicilioID"]);
                Cosmos.Compras.Api.Client.DatoFacturacion.Guardar(datoFacturacionID, personaID, rFC, domicilioID);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int datoFacturacionID = CastHelper.CInt2(e.DeleteValues[i].Values["DatoFacturacionID"]);
                Cosmos.Compras.Api.Client.DatoFacturacion.Eliminar(datoFacturacionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
