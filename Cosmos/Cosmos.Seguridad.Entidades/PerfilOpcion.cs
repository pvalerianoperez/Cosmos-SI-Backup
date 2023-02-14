
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class PerfilOpcion
    {        
        public int PerfilID { get; set; }            
        public int OpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaPerfilOpcion";
                
                //PerfilID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerfilID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PerfilID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //OpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.OpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
