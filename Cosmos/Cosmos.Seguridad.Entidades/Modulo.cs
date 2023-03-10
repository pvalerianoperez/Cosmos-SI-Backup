
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class Modulo
    {        
        public int ModuloID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaModulo";
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
