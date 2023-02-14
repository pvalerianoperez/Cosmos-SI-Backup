
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ContactoPersonalMail
    {        
        public int ContactoPersonalMailID { get; set; }            
        public int ContactoPersonalID { get; set; }            
        public string Email { get; set; }            
        public int TipoMail { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ContactoPersonalMail";
                
                //ContactoPersonalMailID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalMailID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ContactoPersonalMailID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ContactoPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ContactoPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Email
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Email", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Email =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //TipoMail
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMail", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMail =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
