


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using DevExpress.Web.ASPxTreeList;
using Newtonsoft.Json;
using Cosmos.Framework;

namespace Cosmos.Website.Sistema.Catalogos.Seguridad
{
    public partial class Perfil_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaPerfil_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaPerfil_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int perfilID = CastHelper.CInt2(e.InsertValues[i].NewValues["PerfilID"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Perfil.Guardar(perfilID, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int perfilID = CastHelper.CInt2(e.UpdateValues[i].Keys["PerfilID"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Perfil.Guardar(perfilID, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int perfilID = CastHelper.CInt2(e.DeleteValues[i].Values["PerfilID"]);
                Cosmos.Seguridad.Api.Client.Perfil.Eliminar(perfilID);
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
                        Session["Perfil_Listado_PerfilID"] = id;
                        tlOpciones.DataBind();
                        tlOpciones.UnselectAll();
                        List<Cosmos.Seguridad.Entidades.Opcion> lst = Cosmos.Seguridad.Api.Client.Opcion.ListadoPerfilID(id);
                        if (lst != null)
                        {

                            

                            foreach (Cosmos.Seguridad.Entidades.Opcion item in lst)
                            {
                                TreeListNodeIterator iterator = tlOpciones.CreateNodeIterator();
                                TreeListNode node;
                                while (true)
                                {
                                    node = iterator.GetNext();
                                    if (node == null) break;
                                    if (CastHelper.CInt2(node["OpcionID"]) == item.OpcionID)
                                    {
                                        node.Selected = true;
                                        break;
                                    }                                        
                                }
                            }
                        }
                        cbpEditar.JSProperties["cp_show"] = 1;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                        break;
                    case "GUARDAR":
                        id = CastHelper.CInt2(Session["Perfil_Listado_PerfilID"]);
                        Cosmos.Seguridad.Api.Client.Perfil.OpcionEliminar(id);
                        for (int i = 0; i < tlOpciones.GetSelectedNodes().Count; i++)
                        {
                            Cosmos.Seguridad.Api.Client.Perfil.OpcionGuardar(id, CastHelper.CInt2(tlOpciones.GetSelectedNodes()[i].GetValue("OpcionID")));                           
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

        protected void cbpEditarAcciones_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
           
            lstAcciones.DataBind();
            lstAcciones.UnselectAll();

            if (lstAcciones.Items.Count > 0) {
                int perfilID = CastHelper.CInt2(Session["Perfil_Listado_PerfilID"]);
                int opcionID = CastHelper.CInt2(Session["Perfil_Listado_OpcionID"]);
                List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> lst = Cosmos.Seguridad.Api.Client.PerfilOpcionAccion.ListadoPerfilIDOpcionID(perfilID, opcionID);
                foreach (Cosmos.Seguridad.Entidades.PerfilOpcionAccion item in lst)
                {
                    for (int i = 0; i < lstAcciones.Items.Count; i++)
                    {
                        if (CastHelper.CInt2(lstAcciones.Items[i].Value) == item.AccionID) {
                            lstAcciones.Items[i].Selected = true;
                            break;
                        }
                    }
                }
            }
            
            
        }

        protected void tlOpciones_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void tlOpciones_FocusedNodeChanged(object sender, EventArgs e)
        {            
            Session["Perfil_Listado_OpcionID"] = CastHelper.CInt2(((DevExpress.Web.ASPxTreeList.ASPxTreeList)sender).FocusedNode.GetValue("OpcionID"));            
        }

        protected void chkAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lstAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void cbAcciones_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            int opcionID = CastHelper.CInt2(Session["Perfil_Listado_OpcionID"]);
            int perfilID = CastHelper.CInt2(Session["Perfil_Listado_PerfilID"]);
            string[] acciones = e.Parameter.Split('|');

            //elimina todas las acciones
            Cosmos.Seguridad.Api.Client.PerfilOpcionAccion.EliminarPerfilOpcion(perfilID, opcionID);

            foreach (string s in acciones)
            {
                int accionID = CastHelper.CInt2(s);
                if (accionID > 0) {
                    Cosmos.Seguridad.Api.Client.PerfilOpcionAccion.Guardar(perfilID, opcionID, accionID);
                }
                
            }
        }
    }
}
