
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Sistema
{
    public class NivelProducto
    {        
        public int NivelProductoID { get; set; }            
        public string NivelProductoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelProductoID", "SistemaNivelProducto");
                if(!nombreColumna.Equals("")){this.NivelProductoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelProductoClave", "SistemaNivelProducto");
                if(!nombreColumna.Equals("")){this.NivelProductoClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaNivelProducto");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "SistemaNivelProducto");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
