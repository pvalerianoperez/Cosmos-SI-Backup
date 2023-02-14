
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Telefono
    {        
        public int TelefonoID { get; set; }            
        public string LadaPais { get; set; }            
        public string NumeroTelefonico { get; set; }            
        public int TipoTelefonoID { get; set; }
        public int EstatusTelefonoID { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Telefono";
                
                //TelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //LadaPais
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "LadaPais", prefijoTabla);
                if(!nombreColumna.Equals("")){this.LadaPais =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NumeroTelefonico
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroTelefonico", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NumeroTelefonico =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //TipoTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoTelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}

                //EstatusTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusTelefonoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EstatusTelefonoID = CastHelper.CInt2(dr[nombreColumna]); }
            }
        }
    }
}
