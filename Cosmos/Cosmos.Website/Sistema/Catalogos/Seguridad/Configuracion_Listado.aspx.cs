


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
    public partial class Configuracion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaConfiguracion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaConfiguracion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int configuracionID = CastHelper.CInt2(e.InsertValues[i].NewValues["ConfiguracionID"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                int maximoIntentosLogin = CastHelper.CInt2(e.InsertValues[i].NewValues["MaximoIntentosLogin"]);
                bool activa = CastHelper.CBool2(e.InsertValues[i].NewValues["Activa"]);
                Cosmos.Seguridad.Api.Client.Configuracion.Guardar(configuracionID, nombre, maximoIntentosLogin, activa);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int configuracionID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ConfiguracionID"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                int maximoIntentosLogin = CastHelper.CInt2(e.UpdateValues[i].NewValues["MaximoIntentosLogin"]);
                bool activa = CastHelper.CBool2(e.UpdateValues[i].NewValues["Activa"]);
                Cosmos.Seguridad.Api.Client.Configuracion.Guardar(configuracionID, nombre, maximoIntentosLogin, activa);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int configuracionID = CastHelper.CInt2(e.DeleteValues[i].Values["ConfiguracionID"]);
                Cosmos.Seguridad.Api.Client.Configuracion.Eliminar(configuracionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
