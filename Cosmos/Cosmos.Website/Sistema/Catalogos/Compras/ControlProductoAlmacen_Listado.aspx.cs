


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
    public partial class ControlProductoAlmacen_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("ControlProductoAlmacen_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("ControlProductoAlmacen_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int controlProductoAlmacenID = CastHelper.CInt2(e.InsertValues[i].NewValues["ControlProductoAlmacenID"]);
                int productoID = CastHelper.CInt2(e.InsertValues[i].NewValues["ProductoID"]);
                int almacenID = CastHelper.CInt2(e.InsertValues[i].NewValues["AlmacenID"]);
                decimal maximo = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Maximo"]);
                decimal minimo = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Minimo"]);
                decimal reorden = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Reorden"]);
                decimal costoPromedio = CastHelper.CDecimal2(e.InsertValues[i].NewValues["CostoPromedio"]);
                decimal ultimoCosto = CastHelper.CDecimal2(e.InsertValues[i].NewValues["UltimoCosto"]);
                Cosmos.Compras.Api.Client.ControlProductoAlmacen.Guardar(controlProductoAlmacenID, productoID, almacenID, maximo, minimo, reorden, costoPromedio, ultimoCosto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int controlProductoAlmacenID = CastHelper.CInt2(e.UpdateValues[i].Keys["ControlProductoAlmacenID"]);
                int productoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ProductoID"]);
                int almacenID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AlmacenID"]);
                decimal maximo = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Maximo"]);
                decimal minimo = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Minimo"]);
                decimal reorden = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Reorden"]);
                decimal costoPromedio = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["CostoPromedio"]);
                decimal ultimoCosto = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["UltimoCosto"]);
                Cosmos.Compras.Api.Client.ControlProductoAlmacen.Guardar(controlProductoAlmacenID, productoID, almacenID, maximo, minimo, reorden, costoPromedio, ultimoCosto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int controlProductoAlmacenID = CastHelper.CInt2(e.DeleteValues[i].Values["ControlProductoAlmacenID"]);
                Cosmos.Compras.Api.Client.ControlProductoAlmacen.Eliminar(controlProductoAlmacenID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
