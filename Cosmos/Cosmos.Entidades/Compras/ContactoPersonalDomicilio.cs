
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class ContactoPersonalDomicilio
    {        
        public int ContactoPersonalDomicilioID { get; set; }            
        public int ContactoPersonalID { get; set; }            
        public int DomicilioID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalDomicilioID", "ContactoPersonalDomicilio");
                if(!nombreColumna.Equals("")){this.ContactoPersonalDomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalID", "ContactoPersonalDomicilio");
                if(!nombreColumna.Equals("")){this.ContactoPersonalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "ContactoPersonalDomicilio");
                if(!nombreColumna.Equals("")){this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
