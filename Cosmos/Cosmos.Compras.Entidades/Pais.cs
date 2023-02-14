
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Pais
    {        
        public int PaisID { get; set; }            
        public string PaisClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Pais";
                
                //PaisID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PaisID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PaisID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PaisClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PaisClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PaisClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
