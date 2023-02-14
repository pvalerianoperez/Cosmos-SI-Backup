
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ContactoPersonalTelefono
    {        
        public int ContactoPersonalTelefonoID { get; set; }            
        public int ContactoPersonalID { get; set; }            
        public int TelefonoID { get; set; }            
        public string Extension { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ContactoPersonalTelefono";
                
                //ContactoPersonalTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalTelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ContactoPersonalTelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ContactoPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ContactoPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Extension
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Extension", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Extension =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Predeterminado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Predeterminado =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Comentarios
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Comentarios =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
