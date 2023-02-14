
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class PerfilOpcionAccion
    {        
        public int PerfilID { get; set; }            
        public int OpcionID { get; set; }            
        public int AccionID { get; set; }
        public bool Permiso { get; set; }
        public string Accion { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaPerfilOpcionAccion";
                
                //PerfilID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerfilID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PerfilID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //OpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.OpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AccionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AccionID =  CastHelper.CInt2(dr[nombreColumna]);}

                //Permiso
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Permiso", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Permiso = CastHelper.CBool2(dr[nombreColumna]); }

                //Accion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Accion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Accion = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
