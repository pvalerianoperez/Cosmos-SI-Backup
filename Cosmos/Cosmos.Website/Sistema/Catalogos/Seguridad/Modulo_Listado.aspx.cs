


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cosmos.Api.Entidades;
using Cosmos.Website.Recursos.Utilerias;
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using Newtonsoft.Json;
using Cosmos.Framework;

namespace Cosmos.Website.Sistema.Catalogos.Seguridad
{
    public partial class Modulo_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("SistemaModulo_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("SistemaModulo_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int moduloID = CastHelper.CInt2(e.InsertValues[i].NewValues["ModuloID"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Modulo.Guardar(moduloID, nombre, nombreCorto);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int moduloID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ModuloID"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                Cosmos.Seguridad.Api.Client.Modulo.Guardar(moduloID, nombre, nombreCorto);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int moduloID = CastHelper.CInt2(e.DeleteValues[i].Values["ModuloID"]);
                Cosmos.Seguridad.Api.Client.Modulo.Eliminar(moduloID);
            }
            e.Handled = true;
            Grid.DataBind();

        }

        protected void ASPxTreeList1_Init(object sender, EventArgs e)
        {
            ASPxTreeList tl =( sender as ASPxTreeList);
            GridViewBaseRowTemplateContainer container = tl.NamingContainer as GridViewBaseRowTemplateContainer;
            Session["Modulo_Listado_ModuloID"] = CastHelper.CInt2(container.KeyValue);
            tl.DataBind();
        }


        protected void cbpEditar_Callback(object sender, CallbackEventArgsBase e)
        {
            cbpEditar.JSProperties["cp_refresh"] = "";
            cbpEditar.JSProperties["cp_show"] = "";
            cbpEditar.JSProperties["cp_errorMessage"] = "";
            
            string[] p = e.Parameter.Split('|');
            int opcionID = 0;
            if (p.Length > 1) { opcionID = CastHelper.CInt2(p[1]); }            
            switch (p[0]) {
                case "NUEVO":
                    hfOpcionID.Value =  "0";
                    Session["Modulo_Listado_OpcionID"] = opcionID;
                    flEditar.DataBind();
                    txtNombre.Text = "";
                    txtNombreCorto.Text = "";
                    txtRecursoWebsite.Text = "";
                    txtPadreID.Text = "";
                    imgIcono.ImageUrl = "~/Recursos/Imagenes/Menu/Opciones/No-Icon.png";
                    Cosmos.Seguridad.Entidades.Opcion op = Cosmos.Seguridad.Api.Client.Opcion.Consultar(CastHelper.CInt2(p[1]));
                    if (op != null) {
                        txtPadreID.Text = op.PadreID.ToString();
                    }
                    cbpEditar.JSProperties["cp_show"] = 1;
                    cbpEditar.JSProperties["cp_refresh"] = 0;
                    break;
                case "EDITAR":
                    hfOpcionID.Value = opcionID.ToString(); //CInt2(p[1]).ToString();
                    Session["Modulo_Listado_OpcionID"] = opcionID;
                    flEditar.DataBind();
                    cbpEditar.JSProperties["cp_show"] = 1;
                    cbpEditar.JSProperties["cp_refresh"] = 0;
                    imgIcono.ImageUrl = "~/Recursos/Imagenes/Menu/Opciones/No-Icon.png";
                    if (opcionID > 0) {
                        string iconoURL = string.Format("~/Recursos/Imagenes/Menu/Opciones/{0}.png", opcionID.ToString());
                        if (!File.Exists(MapPath(iconoURL))) {
                            iconoURL = "~/Recursos/Imagenes/Menu/Opciones/No-Icon.png";
                        }
                        imgIcono.ImageUrl = iconoURL;
                    }
                    break;
                case "ELIMINAR":
                    Session["Modulo_Listado_OpcionID"] = opcionID;
                    try
                    {                        
                        if (opcionID > 0)
                        {
                            Cosmos.Seguridad.Api.Client.Opcion.TipoOpcionEliminar(opcionID);
                            Cosmos.Seguridad.Api.Client.Opcion.Eliminar(opcionID);
                            string iconoURL = string.Format("~/Recursos/Imagenes/Menu/Opciones/{0}.png", opcionID.ToString());
                            if (File.Exists(MapPath(iconoURL)))
                            {
                                File.Delete(MapPath(iconoURL));
                            }
                        }
                        cbpEditar.JSProperties["cp_show"] = 0;
                        cbpEditar.JSProperties["cp_refresh"] = 1;
                    }
                    catch (Exception ex) {
                        cbpEditar.JSProperties["cp_errorMessage"] = ex.Message;
                        cbpEditar.JSProperties["cp_show"] = 0;
                        cbpEditar.JSProperties["cp_refresh"] = 0;
                    }                        
                    break;
                case "GUARDAR":
                    opcionID = CastHelper.CInt2(hfOpcionID.Value);
                    Session["Modulo_Listado_OpcionID"] = opcionID;
                    Cosmos.Seguridad.Entidades.Opcion resultado = Cosmos.Seguridad.Api.Client.Opcion.Guardar(opcionID, CastHelper.CInt2(Session["Modulo_Listado_ModuloID"]), CastHelper.CInt2(txtPadreID.Text),
                        txtNombre.Text, txtNombreCorto.Text, txtRecursoWebsite.Text,
                        chkActivo.Checked, chkProtegido.Checked, chkPopup.Checked, chkVisibleMenu.Checked, "", 0);

                    Cosmos.Seguridad.Api.Client.Opcion.TipoOpcionEliminar(resultado.OpcionID);

                    for (int i = 0; i < lstTipoOpcion.Items.Count; i++)
                    {
                        if (lstTipoOpcion.Items[i].Selected)
                        {
                            Cosmos.Seguridad.Api.Client.Opcion.TipoOpcionGuardar(resultado.OpcionID, CastHelper.CInt2(lstTipoOpcion.Items[i].Value));
                        }
                    }
                    
                    cbpEditar.JSProperties["cp_show"] = 0;
                    cbpEditar.JSProperties["cp_refresh"] = 1;
                    break;
                case "ICONO":
                    break;
            }                                
            
            
        }

        protected void tvRecursos_DataBound(object sender, EventArgs e)
        {
            tvRecursos.ExpandToDepth(2);
        }

        protected void tlOpciones_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
        {
            if (e.Argument == "refresh") {
                ((ASPxTreeList)sender).DataBind();
            }
            
        }

        protected void lstTipoOpcion_DataBound(object sender, EventArgs e)
        {
            if (lstTipoOpcion.Items.Count > 0) {
                List<Cosmos.Seguridad.Entidades.TipoOpcion> lst = Cosmos.Seguridad.Api.Client.Opcion.TipoOpcionListado(CastHelper.CInt2(hfOpcionID.Value));
                for (int i = 0; i < lstTipoOpcion.Items.Count; i++)
                {
                    List<Cosmos.Seguridad.Entidades.TipoOpcion> results = lst.Where(o => o.TipoOpcionID == CastHelper.CInt2(lstTipoOpcion.Items[i].Value)).ToList();
                    lstTipoOpcion.Items[i].Selected = results.Count>0;
                }
            }
            
            
            
        }

        const string UploadDirectory = "~/UploadControl/UploadImages/";
        protected void uploadIcono_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string opcionID = CastHelper.CInt2(Session["Modulo_Listado_OpcionID"]).ToString();

            string resultFileName = string.Format("{0}.{1}", opcionID, "png"); //resultExtension); //Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = string.Format("~/Recursos/Imagenes/Menu/Opciones/{0}", resultFileName); //UploadDirectory + resultFileName;
            string resultFilePath =  MapPath(resultFileUrl);
            e.UploadedFile.SaveAs(resultFilePath);

            //UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);

            string name = e.UploadedFile.FileName;
            string url = ResolveClientUrl(string.Format("{0}?id={1}",resultFileUrl, Guid.NewGuid().ToString()));
            long sizeInKilobytes = e.UploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";
            e.CallbackData = name + "|" + url + "|" + sizeText;
        }
    }
}
