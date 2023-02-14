using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;
using DevExpress.Web.ASPxTreeList;

namespace Cosmos.Website.Sistema.Seguridad.Catalogos
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
            //estos no se deben mostrar porque se manejaran desde el grid.
            ((SitioProtegido)this.Master).MenuAcciones().mnModificar.Visible = false;
            ((SitioProtegido)this.Master).MenuAcciones().mnEliminar.Visible = false;
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            if (((SitioProtegido)this.Master).PermisoAccion("AGREGAR"))
            {
                for (int i = 0; i < e.InsertValues.Count; i++)
                {
                    int perfilID = CastHelper.CInt2(e.InsertValues[i].NewValues["PerfilID"]);
                    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                    Cosmos.Seguridad.Api.Client.Perfil.Guardar(perfilID, nombre, nombreCorto);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int perfilID = CastHelper.CInt2(e.UpdateValues[i].Keys["PerfilID"]);
                    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                    Cosmos.Seguridad.Api.Client.Perfil.Guardar(perfilID, nombre, nombreCorto);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int perfilID = CastHelper.CInt2(e.DeleteValues[i].Values["PerfilID"]);
                    Cosmos.Seguridad.Api.Client.Perfil.Eliminar(perfilID);
                }
            }
            e.Handled = true;
            Grid.DataBind();

        }
        
        protected void Grid_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            switch (e.Text) {
                case "Nuevo":
                    e.Visible = ((SitioProtegido)this.Master).PermisoAccion("AGREGAR");
                    break;
                case "Eliminar":
                    if (e.VisibleIndex<0){
                        e.Visible = true; //eliminar siempre visible para nuevos renglones
                    }
                    else {
                        e.Visible = ((SitioProtegido)this.Master).PermisoAccion("ELIMINAR");
                    }
                    
                    break;
            }
        }

        public int PerfilID { get { return CastHelper.CInt2(Session["Perfil_Listado_PerfilID"]); } set { Session["Perfil_Listado_PerfilID"] = value; } }
        public int OpcionID { get { return CastHelper.CInt2(Session["Perfil_Listado_OpcionID"]); } set { Session["Perfil_Listado_OpcionID"] = value; } }
        public String Accion { get { return CastHelper.CStr2(Session["Perfil_Listado_Accion"]); } set { Session["Perfil_Listado_Accion"] = value; } }
        protected void tlOpciones_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {
            PerfilID = CastHelper.CInt2(e.Argument);
            tlOpciones.DataBind();
        }

        protected void tlOpciones_DataBound(object sender, EventArgs e)
        {
            ASPxTreeList list = sender as ASPxTreeList;            
            SeleccionaNodos(list.Nodes[0]);
        }

        void SeleccionaNodos(TreeListNode startNode)
        {
            if (startNode == null) return;
            TreeListNodeIterator iterator = new TreeListNodeIterator(startNode);

            while (iterator.Current != null)
            {
                iterator.Current.Selected = CastHelper.CBool2(iterator.Current.GetValue("Permiso"));
                iterator.GetNext();
            }

            //TreeListNodeIterator iterator = treeList.CreateNodeIterator();
            //TreeListNode node;
            //while (true)
            //{
            //    node = iterator.GetNext();
            //    if (node == null) break;
            //    switch (cmbMode.SelectedIndex)
            //    {
            //        case 1:
            //            node.AllowSelect = !node.HasChildren;
            //            break;
            //        case 2:
            //            node.AllowSelect = node.HasChildren;
            //            break;
            //        case 3:
            //            node.AllowSelect = node.Level > 2;
            //            break;
            //    }
            //}

        }

        protected void tlOpciones_SelectionChanged(object sender, EventArgs e)
        {
            Cosmos.Seguridad.Api.Client.Perfil.OpcionEliminar(this.PerfilID);
            ASPxTreeList list = sender as ASPxTreeList;
            foreach ( TreeListNode n in list.GetSelectedNodes())
            {
                int opcionID = CastHelper.CInt2(n.GetValue("OpcionID"));
                if (opcionID < 1000) {
                    Cosmos.Seguridad.Api.Client.Perfil.OpcionGuardar(this.PerfilID, opcionID );
                }                                   
            }            
        }

        protected void cbpAcciones_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cbpAcciones.JSProperties["cp_refresh"] = "";
            cbpAcciones.JSProperties["cp_show"] = "";
            cbpAcciones.JSProperties["cp_errorMessage"] = "";
            try
            {
                string[] datos = e.Parameter.Split('|');
                Accion = CastHelper.CStr2(datos[0]).Trim().ToUpper();
                switch (Accion)
                {
                    case "REFRESCAR":
                        OpcionID = CastHelper.CInt2(datos[1]);
                        
                        chkAcciones.DataBind();
                        cbpAcciones.JSProperties["cp_refresh"] = "";
                        cbpAcciones.JSProperties["cp_show"] = "1";
                        cbpAcciones.JSProperties["cp_errorMessage"] = "";
                        break;
                    case "GUARDAR":
                        Cosmos.Seguridad.Api.Client.PerfilOpcionAccion.EliminarPerfilOpcion(PerfilID, OpcionID);
                        chkAcciones.DataBind();
                        for (int i = 0; i < chkAcciones.Items.Count; i++)
                        {
                            if (chkAcciones.Items[i].Selected) {
                                int accionID = CastHelper.CInt2(chkAcciones.Items[i].Value);
                                Cosmos.Seguridad.Api.Client.PerfilOpcionAccion.Guardar(PerfilID, OpcionID, accionID);
                            }
                        }
                        cbpAcciones.JSProperties["cp_refresh"] = "";
                        cbpAcciones.JSProperties["cp_show"] = "0";
                        cbpAcciones.JSProperties["cp_errorMessage"] = "";
                        break;
                }
            }
            catch(Exception ex) {
                cbpAcciones.JSProperties["cp_refresh"] = "";
                cbpAcciones.JSProperties["cp_show"] = "0";
                cbpAcciones.JSProperties["cp_errorMessage"] = ex.Message;
            }
           
        }

        protected void chkAcciones_DataBound(object sender, EventArgs e)
        {
            if (Accion == "REFRESCAR") {
                for (int i = 0; i < chkAcciones.Items.Count; i++)
                {
                    chkAcciones.Items[i].Selected = CastHelper.CBool2(chkAcciones.Items[i].GetFieldValue("Permiso"));
                }
            }            
        }
    }
}
