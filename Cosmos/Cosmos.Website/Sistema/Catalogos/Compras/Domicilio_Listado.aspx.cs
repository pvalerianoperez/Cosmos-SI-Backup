


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
    public partial class Domicilio_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Domicilio_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Domicilio_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int domicilioID = CastHelper.CInt2(e.InsertValues[i].NewValues["DomicilioID"]);
                string calle = CastHelper.CStr2(e.InsertValues[i].NewValues["Calle"]);
                string numeroExterior = CastHelper.CStr2(e.InsertValues[i].NewValues["NumeroExterior"]);
                string numeroInterior = CastHelper.CStr2(e.InsertValues[i].NewValues["NumeroInterior"]);
                string entreCalle1 = CastHelper.CStr2(e.InsertValues[i].NewValues["EntreCalle1"]);
                string entreCalle2 = CastHelper.CStr2(e.InsertValues[i].NewValues["EntreCalle2"]);
                int codigoPostal = CastHelper.CInt2(e.InsertValues[i].NewValues["CodigoPostal"]);
                string colonia = CastHelper.CStr2(e.InsertValues[i].NewValues["Colonia"]);
                string coordenadas = CastHelper.CStr2(e.InsertValues[i].NewValues["Coordenadas"]);
                int ciudadID = CastHelper.CInt2(e.InsertValues[i].NewValues["CiudadID"]);
                Cosmos.Compras.Api.Client.Domicilio.Guardar(domicilioID, calle, numeroExterior, numeroInterior, entreCalle1, entreCalle2, codigoPostal, colonia, coordenadas, ciudadID);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int domicilioID = CastHelper.CInt2(e.UpdateValues[i].Keys["DomicilioID"]);
                string calle = CastHelper.CStr2(e.UpdateValues[i].NewValues["Calle"]);
                string numeroExterior = CastHelper.CStr2(e.UpdateValues[i].NewValues["NumeroExterior"]);
                string numeroInterior = CastHelper.CStr2(e.UpdateValues[i].NewValues["NumeroInterior"]);
                string entreCalle1 = CastHelper.CStr2(e.UpdateValues[i].NewValues["EntreCalle1"]);
                string entreCalle2 = CastHelper.CStr2(e.UpdateValues[i].NewValues["EntreCalle2"]);
                int codigoPostal = CastHelper.CInt2(e.UpdateValues[i].NewValues["CodigoPostal"]);
                string colonia = CastHelper.CStr2(e.UpdateValues[i].NewValues["Colonia"]);
                string coordenadas = CastHelper.CStr2(e.UpdateValues[i].NewValues["Coordenadas"]);
                int ciudadID = CastHelper.CInt2(e.UpdateValues[i].NewValues["CiudadID"]);
                Cosmos.Compras.Api.Client.Domicilio.Guardar(domicilioID, calle, numeroExterior, numeroInterior, entreCalle1, entreCalle2, codigoPostal, colonia, coordenadas, ciudadID);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int domicilioID = CastHelper.CInt2(e.DeleteValues[i].Values["DomicilioID"]);
                Cosmos.Compras.Api.Client.Domicilio.Eliminar(domicilioID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
