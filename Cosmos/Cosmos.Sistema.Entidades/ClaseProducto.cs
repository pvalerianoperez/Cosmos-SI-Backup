
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class ClaseProducto
    {        
        public int ClaseProductoID { get; set; }            
        public string ClaseProductoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaClaseProducto";
                
                //ClaseProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ClaseProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ClaseProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ClaseProductoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ClaseProductoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ClaseProductoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
