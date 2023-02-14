using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class ConceptoEgreso_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("ConceptoEgreso_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("ConceptoEgreso_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
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
                    int conceptoEgresoID = CastHelper.CInt2(e.InsertValues[i].NewValues["ConceptoEgresoID"]);
                    string conceptoEgresoClave = CastHelper.CStr2(e.InsertValues[i].NewValues["ConceptoEgresoClave"]);
                    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                    string compraFactura = CastHelper.CStr2(e.InsertValues[i].NewValues["CompraFactura"]);
                    string desglosar = CastHelper.CStr2(e.InsertValues[i].NewValues["Desglosar"]);
                    int empresaID = CastHelper.CInt2(Recursos.Utilerias.AppGlobals.EmpresaID);
                    Cosmos.Compras.Api.Client.ConceptoEgreso.Guardar(conceptoEgresoID, conceptoEgresoClave, nombre, nombreCorto, compraFactura, desglosar, empresaID);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int conceptoEgresoID = CastHelper.CInt2(e.UpdateValues[i].Keys["ConceptoEgresoID"]);
                    string conceptoEgresoClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["ConceptoEgresoClave"]);
                    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                    string compraFactura = CastHelper.CStr2(e.UpdateValues[i].NewValues["CompraFactura"]);
                    string desglosar = CastHelper.CStr2(e.UpdateValues[i].NewValues["Desglosar"]);
                    int empresaID = CastHelper.CInt2(Recursos.Utilerias.AppGlobals.EmpresaID);
                    Cosmos.Compras.Api.Client.ConceptoEgreso.Guardar(conceptoEgresoID, conceptoEgresoClave, nombre, nombreCorto, compraFactura, desglosar, empresaID);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int conceptoEgresoID = CastHelper.CInt2(e.DeleteValues[i].Values["ConceptoEgresoID"]);
                    Cosmos.Compras.Api.Client.ConceptoEgreso.Eliminar(conceptoEgresoID);
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
