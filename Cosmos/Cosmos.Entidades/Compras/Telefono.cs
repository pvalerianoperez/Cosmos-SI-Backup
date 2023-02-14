
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class Telefono
    {        
        public int TelefonoID { get; set; }            
        public string LadaPais { get; set; }            
        public string NumeroTelefonico { get; set; }            
        public int TipoTelefonoID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "Telefono");
                if(!nombreColumna.Equals("")){this.TelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "LadaPais", "Telefono");
                if(!nombreColumna.Equals("")){this.LadaPais = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroTelefonico", "Telefono");
                if(!nombreColumna.Equals("")){this.NumeroTelefonico = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", "Telefono");
                if(!nombreColumna.Equals("")){this.TipoTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
