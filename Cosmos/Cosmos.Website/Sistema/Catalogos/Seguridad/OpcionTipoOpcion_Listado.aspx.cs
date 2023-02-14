


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

namespace Cosmos.Website.Sistema.Catalogos.Seguridad
{
    public partial class OpcionTipoOpcion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaOpcionTipoOpcion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaOpcionTipoOpcion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int opcionID = CastHelper.CInt2(e.InsertValues[i].NewValues["OpcionID"]);
                int tipoOpcionID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoOpcionID"]);
                Cosmos.Seguridad.Api.Client.OpcionTipoOpcion.Guardar(opcionID, tipoOpcionID);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int opcionID = CastHelper.CInt2(e.UpdateValues[i].NewValues["OpcionID"]);
                int tipoOpcionID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoOpcionID"]);
                Cosmos.Seguridad.Api.Client.OpcionTipoOpcion.Guardar(opcionID, tipoOpcionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
