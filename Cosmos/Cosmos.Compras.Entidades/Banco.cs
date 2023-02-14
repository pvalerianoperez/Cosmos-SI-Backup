
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Banco
    {        
        public int BancoID { get; set; }            
        public string BancoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public string UsuarioAlta { get; set; }            
        public DateTime FechaAlta { get; set; }            
        public string UsuarioModificacion { get; set; }            
        public DateTime FechaModificacion { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Banco";
                
                //BancoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BancoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.BancoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //BancoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BancoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.BancoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //UsuarioAlta
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioAlta", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioAlta =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //FechaAlta
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaAlta", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FechaAlta =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //UsuarioModificacion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioModificacion", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioModificacion =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //FechaModificacion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaModificacion", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FechaModificacion =  CastHelper.CDate2(dr[nombreColumna]);}   
                
            }
        }
    }
}
