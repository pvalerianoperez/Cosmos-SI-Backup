


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
    public partial class EstatusPersonal_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("EstatusPersonal_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("EstatusPersonal_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int estatusPersonalID = CastHelper.CInt2(e.InsertValues[i].NewValues["EstatusPersonalID"]);
                string estatusPersonalClave = CastHelper.CStr2(e.InsertValues[i].NewValues["EstatusPersonalClave"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Compras.Api.Client.EstatusPersonal.Guardar(estatusPersonalID, estatusPersonalClave, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int estatusPersonalID = CastHelper.CInt2(e.UpdateValues[i].Keys["EstatusPersonalID"]);
                string estatusPersonalClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["EstatusPersonalClave"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Compras.Api.Client.EstatusPersonal.Guardar(estatusPersonalID, estatusPersonalClave, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int estatusPersonalID = CastHelper.CInt2(e.DeleteValues[i].Values["EstatusPersonalID"]);
                Cosmos.Compras.Api.Client.EstatusPersonal.Eliminar(estatusPersonalID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
