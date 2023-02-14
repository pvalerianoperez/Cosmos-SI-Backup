
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class PersonalTipoContacto
    {        
        public int PersonalTipoContactoID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public bool Conyuge { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaPersonalTipoContacto";
                
                //PersonalTipoContactoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalTipoContactoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalTipoContactoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Conyuge
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Conyuge", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Conyuge =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
