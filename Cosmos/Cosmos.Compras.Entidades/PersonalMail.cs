
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class PersonalMail
    {        
        public int PersonalMailID { get; set; }            
        public int PersonalID { get; set; }            
        public string Email { get; set; }            
        public int TipoMailID { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "PersonalMail";
                
                //PersonalMailID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalMailID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalMailID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Email
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Email", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Email =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //TipoMail
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMailID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMailID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
