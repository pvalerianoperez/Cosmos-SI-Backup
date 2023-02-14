
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
{
    public class PerfilOpcion
    {        
        public int PerfilID { get; set; }            
        public int OpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerfilID", "SistemaPerfilOpcion");
                if(!nombreColumna.Equals("")){this.PerfilID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", "SistemaPerfilOpcion");
                if(!nombreColumna.Equals("")){this.OpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
