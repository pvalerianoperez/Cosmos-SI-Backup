
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
{
    public class OpcionTipoOpcion
    {        
        public int OpcionID { get; set; }            
        public int TipoOpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", "SistemaOpcionTipoOpcion");
                if(!nombreColumna.Equals("")){this.OpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoOpcionID", "SistemaOpcionTipoOpcion");
                if(!nombreColumna.Equals("")){this.TipoOpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
