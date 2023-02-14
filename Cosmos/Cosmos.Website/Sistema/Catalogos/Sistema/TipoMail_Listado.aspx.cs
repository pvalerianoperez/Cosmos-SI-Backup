


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
    public partial class TipoMail_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaTipoMail_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaTipoMail_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int tipoMailID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoMailID"]);
                string tipoMailClave = CastHelper.CStr2(e.InsertValues[i].NewValues["TipoMailClave"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                bool estatus = CastHelper.CBool2(e.InsertValues[i].NewValues["Estatus"]);
                Cosmos.Sistema.Api.Client.TipoMail.Guardar(tipoMailID, tipoMailClave, nombre, nombreCorto, estatus);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int tipoMailID = CastHelper.CInt2(e.UpdateValues[i].NewValues["TipoMailID"]);
                string tipoMailClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["TipoMailClave"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                bool estatus = CastHelper.CBool2(e.UpdateValues[i].NewValues["Estatus"]);
                Cosmos.Sistema.Api.Client.TipoMail.Guardar(tipoMailID, tipoMailClave, nombre, nombreCorto, estatus);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int tipoMailID = CastHelper.CInt2(e.DeleteValues[i].Values["TipoMailID"]);
                Cosmos.Sistema.Api.Client.TipoMail.Eliminar(tipoMailID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
