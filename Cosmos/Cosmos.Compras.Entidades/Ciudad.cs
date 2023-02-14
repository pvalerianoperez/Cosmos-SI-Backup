
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Ciudad
    {        
        public int CiudadID { get; set; }            
        public string CiudadClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int MunicipioID { get; set; }
        public string NombreCompleto { get; set; }
        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Ciudad";
                
                //CiudadID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CiudadID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CiudadClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CiudadClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //MunicipioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MunicipioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MunicipioID =  CastHelper.CInt2(dr[nombreColumna]);}

                //NombreCompleto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCompleto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCompleto = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
