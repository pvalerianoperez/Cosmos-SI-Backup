using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cosmos.Entidades;
using Cosmos.Entidades.Api;
using Cosmos.Website.Recursos.Utilerias;
using Newtonsoft.Json;
using static N400.Framework.CastHelper;

namespace Cosmos.Website.Sistema.Catalogos
{
    public partial class FormaPago_Listado : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaGrid();            
        }

        protected void CargaGrid() {
            RespuestaBase respuesta = ApiClient.Compras.FormaPago.Listado();
            if (respuesta.Exitoso)
            {
                List<Entidades.Compras.FormaPago> datos = JsonConvert.DeserializeObject<List<Entidades.Compras.FormaPago>>(JsonConvert.SerializeObject(respuesta.Datos));
                ASPxGridView1.DataSource = datos;
                ASPxGridView1.DataBind();
            }
        }

        protected void ASPxGridView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int id = CInt2(e.InsertValues[i].NewValues[0]);
                string nombre = CStr2(e.InsertValues[i].NewValues[2]);
                string nombreCorto = CStr2(e.InsertValues[i].NewValues[1]);
                ApiClient.Compras.FormaPago.Guardar(id, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int id = CInt2(e.UpdateValues[i].NewValues[0]);
                string nombre = CStr2(e.UpdateValues[i].NewValues[2]);
                string nombreCorto = CStr2(e.UpdateValues[i].NewValues[1]);
                ApiClient.Compras.FormaPago.Guardar(id, nombre, nombreCorto);
            }

            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int id = CInt2(e.DeleteValues[i].Values[0]);                
                ApiClient.Compras.FormaPago.Eliminar(id);
            }

            e.Handled = true;
            CargaGrid();

        }
    }
}