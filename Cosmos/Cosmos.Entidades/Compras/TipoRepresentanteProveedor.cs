
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class TipoRepresentanteProveedor
    {        
        public int TipoRepresentanteProveedorID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoRepresentanteProveedorID", "TipoRepresentanteProveedor");
                if(!nombreColumna.Equals("")){this.TipoRepresentanteProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "TipoRepresentanteProveedor");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "TipoRepresentanteProveedor");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
