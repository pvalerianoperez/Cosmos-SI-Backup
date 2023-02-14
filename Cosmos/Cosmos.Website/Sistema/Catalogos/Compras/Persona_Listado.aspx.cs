


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
    public partial class Persona_Listado : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion =  Request["__EVENTTARGET"];
            switch (accion) {
                case "EXPORTAR_EXCEL":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WriteXlsxToResponse(string.Format("Persona_{0}.xlsx", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
                case "EXPORTAR_PDF":
                    ASPxGridViewExporter1.DataBind();
                    ASPxGridViewExporter1.WritePdfToResponse(string.Format("Persona_{0}.pdf", DateTime.Now.ToString("yyMMddHHmmss")), true);
                    break;
            }         
        }
      
        protected void Grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //insert
            for (int i = 0; i < e.InsertValues.Count; i++)
            {
                int personaID = CastHelper.CInt2(e.InsertValues[i].NewValues["PersonaID"]);
                string personaClave = CastHelper.CStr2(e.InsertValues[i].NewValues["PersonaClave"]);
                string fisicaMoral = CastHelper.CStr2(e.InsertValues[i].NewValues["FisicaMoral"]);
                string nombreComercial = CastHelper.CStr2(e.InsertValues[i].NewValues["NombreComercial"]);
                string razonSocial = CastHelper.CStr2(e.InsertValues[i].NewValues["RazonSocial"]);
                string nombre = CastHelper.CStr2(e.InsertValues[i].NewValues["Nombre"]);
                string apellidoPaterno = CastHelper.CStr2(e.InsertValues[i].NewValues["ApellidoPaterno"]);
                string apellidoMaterno = CastHelper.CStr2(e.InsertValues[i].NewValues["ApellidoMaterno"]);
                string rFC = CastHelper.CStr2(e.InsertValues[i].NewValues["RFC"]);
                string cURP = CastHelper.CStr2(e.InsertValues[i].NewValues["CURP"]);
                int sexoID = CastHelper.CInt2(e.InsertValues[i].NewValues["SexoID"]);
                DateTime fechaNacimiento =  CastHelper.CDate2(e.InsertValues[i].NewValues["FechaNacimiento"]);
                int ciudadNacimientoID = CastHelper.CInt2(e.InsertValues[i].NewValues["CiudadNacimientoID"]);
                int estadoCivilID = CastHelper.CInt2(e.InsertValues[i].NewValues["EstadoCivilID"]);
                bool casadoCivil = CastHelper.CBool2(e.InsertValues[i].NewValues["CasadoCivil"]);
                bool casadoIglesia = CastHelper.CBool2(e.InsertValues[i].NewValues["CasadoIglesia"]);
                string iniciales = CastHelper.CStr2(e.InsertValues[i].NewValues["Iniciales"]);
                string sobreNombre = CastHelper.CStr2(e.InsertValues[i].NewValues["SobreNombre"]);
                int altaUsuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["AltaUsuarioID"]);
                DateTime altaFecha =  CastHelper.CDate2(e.InsertValues[i].NewValues["AltaFecha"]);
                int modificacionUsuarioID = CastHelper.CInt2(e.InsertValues[i].NewValues["ModificacionUsuarioID"]);
                DateTime modificacionFecha =  CastHelper.CDate2(e.InsertValues[i].NewValues["ModificacionFecha"]);
                Cosmos.Compras.Api.Client.Persona.Guardar(personaID, personaClave, fisicaMoral, nombreComercial, razonSocial, nombre, apellidoPaterno, apellidoMaterno, rFC, cURP, sexoID, fechaNacimiento, ciudadNacimientoID, estadoCivilID, casadoCivil, casadoIglesia, iniciales, sobreNombre);
            }
            //update
            for (int i = 0; i < e.UpdateValues.Count; i++)
            {
                int personaID = CastHelper.CInt2(e.UpdateValues[i].NewValues["PersonaID"]);
                string personaClave = CastHelper.CStr2(e.UpdateValues[i].NewValues["PersonaClave"]);
                string fisicaMoral = CastHelper.CStr2(e.UpdateValues[i].NewValues["FisicaMoral"]);
                string nombreComercial = CastHelper.CStr2(e.UpdateValues[i].NewValues["NombreComercial"]);
                string razonSocial = CastHelper.CStr2(e.UpdateValues[i].NewValues["RazonSocial"]);
                string nombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["Nombre"]);
                string apellidoPaterno = CastHelper.CStr2(e.UpdateValues[i].NewValues["ApellidoPaterno"]);
                string apellidoMaterno = CastHelper.CStr2(e.UpdateValues[i].NewValues["ApellidoMaterno"]);
                string rFC = CastHelper.CStr2(e.UpdateValues[i].NewValues["RFC"]);
                string cURP = CastHelper.CStr2(e.UpdateValues[i].NewValues["CURP"]);
                int sexoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["SexoID"]);
                DateTime fechaNacimiento =  CastHelper.CDate2(e.UpdateValues[i].NewValues["FechaNacimiento"]);
                int ciudadNacimientoID = CastHelper.CInt2(e.UpdateValues[i].NewValues["CiudadNacimientoID"]);
                int estadoCivilID = CastHelper.CInt2(e.UpdateValues[i].NewValues["EstadoCivilID"]);
                bool casadoCivil = CastHelper.CBool2(e.UpdateValues[i].NewValues["CasadoCivil"]);
                bool casadoIglesia = CastHelper.CBool2(e.UpdateValues[i].NewValues["CasadoIglesia"]);
                string iniciales = CastHelper.CStr2(e.UpdateValues[i].NewValues["Iniciales"]);
                string sobreNombre = CastHelper.CStr2(e.UpdateValues[i].NewValues["SobreNombre"]);
                int altaUsuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["AltaUsuarioID"]);
                DateTime altaFecha =  CastHelper.CDate2(e.UpdateValues[i].NewValues["AltaFecha"]);
                int modificacionUsuarioID = CastHelper.CInt2(e.UpdateValues[i].NewValues["ModificacionUsuarioID"]);
                DateTime modificacionFecha =  CastHelper.CDate2(e.UpdateValues[i].NewValues["ModificacionFecha"]);
                Cosmos.Compras.Api.Client.Persona.Guardar(personaID, personaClave, fisicaMoral, nombreComercial, razonSocial, nombre, apellidoPaterno, apellidoMaterno, rFC, cURP, sexoID, fechaNacimiento, ciudadNacimientoID, estadoCivilID, casadoCivil, casadoIglesia, iniciales, sobreNombre);
            }
            //delete
            for (int i = 0; i < e.DeleteValues.Count; i++)
            {
                int personaID = CastHelper.CInt2(e.DeleteValues[i].Values["PersonaID"]);
                Cosmos.Compras.Api.Client.Persona.Eliminar(personaID);
            }
            e.Handled = true;
            Grid.DataBind();

        }
    }
}
