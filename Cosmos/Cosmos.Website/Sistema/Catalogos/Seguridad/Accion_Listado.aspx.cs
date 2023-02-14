


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
    public partial class Accion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaAccion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaAccion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int accionID = CastHelper.CInt2(e.InsertValues[i].NewValues["AccionID"]);
                string accionClave = CastHelper.CStr2(e.InsertValues[i].NewValues["AccionClave"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Accion.Guardar(accionID, accionClave, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int accionID = CastHelper.CInt2(e.UpdateValues[i].Keys["AccionID"]);
                string accionClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["AccionClave"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Accion.Guardar(accionID, accionClave, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int accionID = CastHelper.CInt2(e.DeleteValues[i].Values["AccionID"]);
                Cosmos.Seguridad.Api.Client.Accion.Eliminar(accionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
