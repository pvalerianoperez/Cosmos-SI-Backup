
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
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
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConfiguracionID", "SistemaConfiguracion");
                if(!nombreColumna.Equals("")){this.ConfiguracionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaConfiguracion");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MaximoIntentosLogin", "SistemaConfiguracion");
                if(!nombreColumna.Equals("")){this.MaximoIntentosLogin = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activa", "SistemaConfiguracion");
                if(!nombreColumna.Equals("")){this.Activa = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
            }
        }
    }
}
