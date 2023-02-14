
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class Configuracion
    {        
        public int ConfiguracionID { get; set; }            
        public string Nombre { get; set; }            
        public int MaximoIntentosLogin { get; set; }            
        public bool Activa { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaConfiguracion";
                
                //ConfiguracionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConfiguracionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ConfiguracionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //MaximoIntentosLogin
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MaximoIntentosLogin", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MaximoIntentosLogin =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Activa
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activa", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activa =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
