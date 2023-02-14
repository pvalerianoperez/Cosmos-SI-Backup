
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class Ciudad
    {        
        public int CiudadID { get; set; }            
        public string CiudadClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int MunicipioID { get; set; }
        public string NombreCompleto { get; set; }
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadID", "Ciudad");
                if(!nombreColumna.Equals("")){this.CiudadID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadClave", "Ciudad");
                if(!nombreColumna.Equals("")){this.CiudadClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Ciudad");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Ciudad");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioID", "Ciudad");
                if(!nombreColumna.Equals("")){this.MunicipioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCompleto", "Ciudad");
                if (!nombreColumna.Equals("")) { this.NombreCompleto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
    }
}
