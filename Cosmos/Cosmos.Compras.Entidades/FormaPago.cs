
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class FormaPago
    {        
        public int FormaPagoID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "FormaPago";
                
                //FormaPagoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FormaPagoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FormaPagoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
