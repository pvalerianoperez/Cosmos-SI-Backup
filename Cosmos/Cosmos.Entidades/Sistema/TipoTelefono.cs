
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Sistema
{
    public class TipoTelefono
    {        
        public int TipoTelefonoID { get; set; }            
        public string TipoTelefonoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public bool Estatus { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", "SistemaTipoTelefono");
                if(!nombreColumna.Equals("")){this.TipoTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoClave", "SistemaTipoTelefono");
                if(!nombreColumna.Equals("")){this.TipoTelefonoClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaTipoTelefono");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "SistemaTipoTelefono");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", "SistemaTipoTelefono");
                if(!nombreColumna.Equals("")){this.Estatus = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
            }
        }
    }
}
