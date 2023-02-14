
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class Municipio
    {        
        public int MunicipioID { get; set; }            
        public string MunicipioClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int EstadoID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioID", "Municipio");
                if(!nombreColumna.Equals("")){this.MunicipioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioClave", "Municipio");
                if(!nombreColumna.Equals("")){this.MunicipioClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Municipio");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Municipio");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoID", "Municipio");
                if(!nombreColumna.Equals("")){this.EstadoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
