
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class UsuarioIntentos
    {        
        public int UsuarioID { get; set; }            
        public DateTime Fecha { get; set; }            
        public string IP { get; set; }            
        public string Contrasena { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaUsuarioIntentos";
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Fecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Fecha =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //IP
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "IP", prefijoTabla);
                if(!nombreColumna.Equals("")){this.IP =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Contrasena
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Contrasena", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Contrasena =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
