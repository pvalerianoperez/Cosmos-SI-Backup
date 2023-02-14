using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Puesto_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Puesto_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Puesto_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int puestoID = CastHelper.CInt2(e.InsertValues[i].NewValues["PuestoID"]);
                    string puestoClave = CastHelper.CStr2(e.InsertValues[i].NewValues["PuestoClave"]);
                    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                    decimal sueldo = CastHelper.CDecimal2(e.InsertValues[i].NewValues["Sueldo"]);
                    string baseNeto = CastHelper.CStr2(e.InsertValues[i].NewValues["BaseNeto"]);
                    string tipo = CastHelper.CStr2(e.InsertValues[i].NewValues["Tipo"]);
                    string objetivo = CastHelper.CStr2(e.InsertValues[i].NewValues["Objetivo"]);
                    string reqAcademicos = CastHelper.CStr2(e.InsertValues[i].NewValues["ReqAcademicos"]);
                    int tiempoDesempeno = CastHelper.CInt2(e.InsertValues[i].NewValues["TiempoDesempeno"]);
                    int empresaID = CastHelper.CInt2(Recursos.Utilerias.AppGlobals.EmpresaID);
                    Cosmos.Compras.Api.Client.Puesto.Guardar(puestoID, empresaID, puestoClave, nombre, nombreCorto, sueldo, baseNeto, tipo, objetivo, reqAcademicos, tiempoDesempeno);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int puestoID = CastHelper.CInt2(e.UpdateValues[i].Keys["PuestoID"]);
                    string puestoClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["PuestoClave"]);
                    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                    decimal sueldo = CastHelper.CDecimal2(e.UpdateValues[i].NewValues["Sueldo"]);
                    string baseNeto = CastHelper.CStr2(e.UpdateValues[i].NewValues["BaseNeto"]);
                    string tipo = CastHelper.CStr2(e.UpdateValues[i].NewValues["Tipo"]);
                    string objetivo = CastHelper.CStr2(e.UpdateValues[i].NewValues["Objetivo"]);
                    string reqAcademicos = CastHelper.CStr2(e.UpdateValues[i].NewValues["ReqAcademicos"]);
                    int tiempoDesempeno = CastHelper.CInt2(e.UpdateValues[i].NewValues["TiempoDesempeno"]);
                    int empresaID = CastHelper.CInt2(Recursos.Utilerias.AppGlobals.EmpresaID);
                    Cosmos.Compras.Api.Client.Puesto.Guardar(puestoID,empresaID, puestoClave, nombre, nombreCorto, sueldo, baseNeto, tipo, objetivo, reqAcademicos, tiempoDesempeno);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int puestoID = CastHelper.CInt2(e.DeleteValues[i].Values["PuestoID"]);
                    Cosmos.Compras.Api.Client.Puesto.Eliminar(puestoID);
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
    }
}
