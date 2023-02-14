


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
    public partial class Opcion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaOpcion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaOpcion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int opcionID = CastHelper.CInt2(e.InsertValues[i].NewValues["OpcionID"]);
                int moduloID = CastHelper.CInt2(e.InsertValues[i].NewValues["ModuloID"]);
                int padreID = CastHelper.CInt2(e.InsertValues[i].NewValues["PadreID"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                string recursoWebsite = CastHelper.CStr2(e.InsertValues[i].NewValues["RecursoWebsite"]);
                bool activo = CastHelper.CBool2(e.InsertValues[i].NewValues["Activo"]);
                bool protegido = CastHelper.CBool2(e.InsertValues[i].NewValues["Protegido"]);
                bool popup = CastHelper.CBool2(e.InsertValues[i].NewValues["Popup"]);
                bool visibleMenu = CastHelper.CBool2(e.InsertValues[i].NewValues["VisibleMenu"]);
                string icono = CastHelper.CStr2(e.InsertValues[i].NewValues["Icono"]);
                int orden = CastHelper.CInt2(e.InsertValues[i].NewValues["Orden"]);
                Cosmos.Seguridad.Api.Client.Opcion.Guardar(opcionID, moduloID, padreID, nombre, nombreCorto, recursoWebsite, activo, protegido, popup, visibleMenu, icono, orden);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int opcionID = CastHelper.CInt2(e.UpdateValues[i].NewValues["OpcionID"]);
                int moduloID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ModuloID"]);
                int padreID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PadreID"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                string recursoWebsite = CastHelper.CStr2(e.UpdateValues[i].NewValues["RecursoWebsite"]);
                bool activo = CastHelper.CBool2(e.UpdateValues[i].NewValues["Activo"]);
                bool protegido = CastHelper.CBool2(e.UpdateValues[i].NewValues["Protegido"]);
                bool popup = CastHelper.CBool2(e.UpdateValues[i].NewValues["Popup"]);
                bool visibleMenu = CastHelper.CBool2(e.UpdateValues[i].NewValues["VisibleMenu"]);
                string icono = CastHelper.CStr2(e.UpdateValues[i].NewValues["Icono"]);
                int orden = CastHelper.CInt2(e.UpdateValues[i].NewValues["Orden"]);
                Cosmos.Seguridad.Api.Client.Opcion.Guardar(opcionID, moduloID, padreID, nombre, nombreCorto, recursoWebsite, activo, protegido, popup, visibleMenu, icono, orden);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int opcionID = CastHelper.CInt2(e.DeleteValues[i].Values["OpcionID"]);
                Cosmos.Seguridad.Api.Client.Opcion.Eliminar(opcionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
