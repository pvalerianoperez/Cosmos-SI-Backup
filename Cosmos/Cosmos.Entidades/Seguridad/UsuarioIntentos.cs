
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
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
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", "SistemaUsuarioIntentos");
                if(!nombreColumna.Equals("")){this.UsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", "SistemaUsuarioIntentos");
                if(!nombreColumna.Equals("")){this.Fecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "IP", "SistemaUsuarioIntentos");
                if(!nombreColumna.Equals("")){this.IP Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Contrasena", "SistemaUsuarioIntentos");
                if(!nombreColumna.Equals("")){this.Contrasena = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
