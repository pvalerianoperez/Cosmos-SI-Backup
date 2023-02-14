
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class PersonalDomicilio
    {        
        public int PersonalDomicilioID { get; set; }            
        public int PersonalID { get; set; }            
        public int DomicilioID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalDomicilioID", "PersonalDomicilio");
                if(!nombreColumna.Equals("")){this.PersonalDomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", "PersonalDomicilio");
                if(!nombreColumna.Equals("")){this.PersonalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "PersonalDomicilio");
                if(!nombreColumna.Equals("")){this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
