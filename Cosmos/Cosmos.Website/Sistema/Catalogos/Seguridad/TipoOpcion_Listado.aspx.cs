


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
    public partial class TipoOpcion_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaTipoOpcion_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaTipoOpcion_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int tipoOpcionID = CastHelper.CInt2(e.InsertValues[i].NewValues["TipoOpcionID"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.TipoOpcion.Guardar(tipoOpcionID, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int tipoOpcionID = CastHelper.CInt2(e.UpdateValues[i].Keys["TipoOpcionID"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.TipoOpcion.Guardar(tipoOpcionID, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int tipoOpcionID = CastHelper.CInt2(e.DeleteValues[i].Values["TipoOpcionID"]);
                Cosmos.Seguridad.Api.Client.TipoOpcion.Eliminar(tipoOpcionID);
            }
            e.Handled = true;
            Grid.DataBind();

        }

        protected void cbpEditar_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpEditar.JSProperties["cp_refresh"] = "";
            cbpEditar.JSProperties["cp_show"] = "";
            cbpEditar.JSProperties["cp_errorMessage"] = "";

            try
            {
                string[] p = e.Parameter.Split('|');
                int id = 0;
                if (p.Length > 1) { id = CastHelper.CInt2(p[1]); }
                switch (p[0])
                {                    
                    case "EDITAR":
                        Session["TipoOpcion_Listado_TipoOpcionID"] = id;
                        chkAcciones.DataBind();
                        chkAcciones.UnselectAll();
                        List<Cosmos.Seguridad.Entidades.Accion> lst =  Cosmos.Seguridad.Api.Client.Accion.ListadoTipoOpcionID(id);
                        if (lst != null) {
                            foreach (Cosmos.Seguridad.Entidades.Accion item in lst)
                            {
                                for (int i = 0; i < chkAcciones.Items.Count; i++)
                                {
                                    if (chkAcciones.Items[i].Value.ToString() == item.AccionID.ToString()) {
                                        chkAcciones.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["TipoOpcion_Listado_TipoOpcionID"]);
                        Cosmos.Seguridad.Api.Client.TipoOpcion.AccionEliminar(id);
                        for (int i = 0; i < chkAcciones.Items.Count; i++)
                        {
                            if (chkAcciones.Items[i].Selected) {
                                Cosmos.Seguridad.Api.Client.TipoOpcion.AccionGuardar(id, CastHelper.CInt2(chkAcciones.Items[i].Value));
                            }
                        }
                        cbpEditar.JSProperties["cp_show"] = 0;
                        cbpEditar.JSProperties["cp_refresh"] = 1;
                        break;

                }
            }
            catch (Exception ex)
            {
                cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
            }
        }

        protected void Grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "refresh") {
                Grid.DataBind();
            }
        }
    }
}
