
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class Accion
    {        
        public int AccionID { get; set; }            
        public string AccionClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaAccion";
                
                //AccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AccionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AccionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AccionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AccionClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AccionClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
