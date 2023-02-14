
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class PersonalTelefono
    {        
        public int PersonalTelefonoID { get; set; }            
        public int PersonalID { get; set; }            
        public string TelefonoID { get; set; }            
        public string Extension { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalTelefonoID", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.PersonalTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.PersonalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.TelefonoID Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Extension", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.Extension Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "PersonalTelefono");
                if(!nombreColumna.Equals("")){this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
