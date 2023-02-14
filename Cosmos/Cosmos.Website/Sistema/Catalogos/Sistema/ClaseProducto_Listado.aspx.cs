


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
    public partial class ClaseProducto_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaClaseProducto_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaClaseProducto_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int claseProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["ClaseProductoID"]);
                string claseProductoClave = CastHelper.CStr2(e.InsertValues[i].NewValues["ClaseProductoClave"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Sistema.Api.Client.ClaseProducto.Guardar(claseProductoID, claseProductoClave, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int claseProductoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ClaseProductoID"]);
                string claseProductoClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["ClaseProductoClave"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Sistema.Api.Client.ClaseProducto.Guardar(claseProductoID, claseProductoClave, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int claseProductoID = CastHelper.CInt2(e.DeleteValues[i].Values["ClaseProductoID"]);
                Cosmos.Sistema.Api.Client.ClaseProducto.Eliminar(claseProductoID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
