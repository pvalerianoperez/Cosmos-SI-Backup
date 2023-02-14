
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Estado
    {        
        public int EstadoID { get; set; }            
        public string EstadoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int PaisID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Estado";
                
                //EstadoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstadoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstadoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstadoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //PaisID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PaisID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PaisID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
