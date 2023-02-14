
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class TipoMail
    {        
        public int TipoMailID { get; set; }            
        public string TipoMailClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public bool Estatus { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaTipoMail";
                
                //TipoMailID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMailID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMailID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoMailClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMailClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMailClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Estatus
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Estatus =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
