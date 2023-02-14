
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class PersonalTelefono:Telefono
    {        
        public int PersonalTelefonoID { get; set; }            
        public int PersonalID { get; set; }            
        public string Extension { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "PersonalTelefono";
                
                //PersonalTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalTelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalTelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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



                //LadaPais
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "LadaPais", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.LadaPais = CastHelper.CStr2(dr[nombreColumna]); }

                //NumeroTelefonico
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroTelefonico", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NumeroTelefonico = CastHelper.CStr2(dr[nombreColumna]); }

                //TipoTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoTelefonoID = CastHelper.CInt2(dr[nombreColumna]); }

                //EstatusTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusTelefonoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EstatusTelefonoID = CastHelper.CInt2(dr[nombreColumna]); }

            }
        }
    }
}
