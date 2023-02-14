using System;
using Cosmos.Framework;
using Cosmos.Website.Recursos.MasterPages;

namespace Cosmos.Website.Sistema.Compras.Catalogos
{
    public partial class Municipio_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Municipio_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Municipio_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            } 
            //estos no se deben mostrar porque se manejaran desde el grid.
            ((SitioProtegido)this.Master).MenuAcciones().mnModificar.Visible = false;
            ((SitioProtegido)this.Master).MenuAcciones().mnEliminar.Visible = false;

            int estadoID = CastHelper.CInt2(Request["EstadoID"]);
            if (estadoID > 0)
            {
                Grid.FilterExpression = (string.Format("[EstadoID] = '{0}'", estadoID.ToString()));
            }
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            if (((SitioProtegido)this.Master).PermisoAccion("AGREGAR"))
            {
                for (int i = 0; i < e.InsertValues.Count; i++)
                {
                    int municipioID = CastHelper.CInt2(e.InsertValues[i].NewValues["MunicipioID"]);
                    string municipioClave = CastHelper.CStr2(e.InsertValues[i].NewValues["MunicipioClave"]);
                    string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreCorto"]);
                    int estadoID = CastHelper.CInt2(Request["EstadoID"]);
                    Cosmos.Compras.Api.Client.Municipio.Guardar(municipioID, municipioClave, nombre, nombreCorto, estadoID);
                }
            }
            //update
            if (((SitioProtegido)this.Master).PermisoAccion("MODIFICAR"))
            {
                for (int i = 0; i < e.UpdateValues.Count; i++)
                {
                    int municipioID = CastHelper.CInt2(e.UpdateValues[i].Keys["MunicipioID"]);
                    string municipioClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["MunicipioClave"]);
                    string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                    string nombreCorto = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreCorto"]);
                    int estadoID = CastHelper.CInt2(Request["EstadoID"]);
                    Cosmos.Compras.Api.Client.Municipio.Guardar(municipioID, municipioClave, nombre, nombreCorto, estadoID);
                }
            }
            //delete
            if (((SitioProtegido)this.Master).PermisoAccion("ELIMINAR"))
            {
                for (int i = 0; i < e.DeleteValues.Count; i++)
                {
                    int municipioID = CastHelper.CInt2(e.DeleteValues[i].Values["MunicipioID"]);
                    Cosmos.Compras.Api.Client.Municipio.Eliminar(municipioID);
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
