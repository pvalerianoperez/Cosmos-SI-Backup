
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class Parametro
    {        
        public int SistemaParametroID { get; set; }            
        public string Nombre { get; set; }            
        public int ModuloID { get; set; }            
        public string Valor { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaParametro";
                
                //SistemaParametroID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaParametroID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaParametroID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Valor
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Valor", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Valor =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
