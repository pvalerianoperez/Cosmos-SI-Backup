
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class EstatusTelefono
    {        
        public int EstatusTelefonoID { get; set; }            
        public string EstatusTelefonoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaEstatusTelefono";
                
                //EstatusTelefonoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusTelefonoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusTelefonoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstatusTelefonoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusTelefonoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusTelefonoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
