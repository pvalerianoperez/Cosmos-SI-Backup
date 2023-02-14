
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class OpcionTipoOpcion
    {        
        public int OpcionID { get; set; }            
        public int TipoOpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaOpcionTipoOpcion";
                
                //OpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.OpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoOpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoOpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoOpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
