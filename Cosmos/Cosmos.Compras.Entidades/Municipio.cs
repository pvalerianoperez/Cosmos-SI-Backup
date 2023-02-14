
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
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
                String nombreColumna="";
                String prefijoTabla = "Municipio";
                
                //MunicipioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MunicipioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //MunicipioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MunicipioClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //EstadoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstadoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
