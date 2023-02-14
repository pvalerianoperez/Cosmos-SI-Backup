
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
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
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalTelefonoID", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.ContactoPersonalTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalID", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.ContactoPersonalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.TelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Extension", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.Extension Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "ContactoPersonalTelefono");
                if(!nombreColumna.Equals("")){this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
