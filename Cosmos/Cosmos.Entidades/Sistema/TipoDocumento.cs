
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Sistema
{
    public class TipoDocumento
    {        
        public int TipoDocumentoID { get; set; }            
        public string TipoDocumentoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public bool Estatus { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", "SistemaTipoDocumento");
                if(!nombreColumna.Equals("")){this.TipoDocumentoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoClave", "SistemaTipoDocumento");
                if(!nombreColumna.Equals("")){this.TipoDocumentoClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaTipoDocumento");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "SistemaTipoDocumento");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", "SistemaTipoDocumento");
                if(!nombreColumna.Equals("")){this.Estatus = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
            }
        }
    }
}
