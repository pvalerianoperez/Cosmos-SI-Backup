


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
    public partial class FamiliaProducto_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("FamiliaProducto_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("FamiliaProducto_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            ////insert
            //for (int i = 0; i < e.InsertValues.Count; i++)
            //{
            //    int familiaProductoID = CastHelper.CInt2(e.InsertValues[i].NewValues["FamiliaProductoID"]);
            //    string familiaClave = CastHelper.CStr2(e.InsertValues[i].NewValues["FamiliaClave"]);
            //    string familiaClavePadre = CastHelper.CStr2(e.InsertValues[i].NewValues["FamiliaClavePadre"]);
            //    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
            //    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
            //    Cosmos.Compras.Api.Client.FamiliaProducto.Guardar(familiaProductoID, familiaClave, familiaClavePadre, nombre, nombreCorto);
            //}
            ////update
            //for (int i = 0; i < e.UpdateValues.Count; i++)
            //{
            //    int familiaProductoID = CastHelper.CInt2(e.UpdateValues[i].Keys["FamiliaProductoID"]);
            //    string familiaClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["FamiliaClave"]);
            //    string familiaClavePadre = CastHelper.CStr2(e.UpdateValues[i].NewValues["FamiliaClavePadre"]);
            //    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
            //    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
            //    Cosmos.Compras.Api.Client.FamiliaProducto.Guardar(familiaProductoID, familiaClave, familiaClavePadre, nombre, nombreCorto);
            //}
            ////delete
            //for (int i = 0; i < e.DeleteValues.Count; i++)
            //{
            //    int familiaProductoID = CastHelper.CInt2(e.DeleteValues[i].Values["FamiliaProductoID"]);
            //    Cosmos.Compras.Api.Client.FamiliaProducto.Eliminar(familiaProductoID);
            //}
            //e.Handled = true;
            //Grid.DataBind();

        }
    }
}
