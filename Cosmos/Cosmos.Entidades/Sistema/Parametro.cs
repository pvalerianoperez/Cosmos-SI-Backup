
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Sistema
{
    public class Parametro
    {        
        public bool ClientesCompartidos { get; set; }            
        public bool ProveedoresCompartidos { get; set; }            
        public bool ProductosCompartidos { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ClientesCompartidos", "SistemaParametro");
                if(!nombreColumna.Equals("")){this.ClientesCompartidos = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedoresCompartidos", "SistemaParametro");
                if(!nombreColumna.Equals("")){this.ProveedoresCompartidos = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductosCompartidos", "SistemaParametro");
                if(!nombreColumna.Equals("")){this.ProductosCompartidos = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
            }
        }
    }
}
