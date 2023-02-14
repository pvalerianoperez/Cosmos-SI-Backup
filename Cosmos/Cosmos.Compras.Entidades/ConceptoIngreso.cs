
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ConceptoIngreso
    {        
        public int ConceptoIngresoID { get; set; }
        public int EmpresaID { get; set; }
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ConceptoIngreso";
                
                //ConceptoIngresoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConceptoIngresoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ConceptoIngresoID =  CastHelper.CInt2(dr[nombreColumna]);}

                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EmpresaID = CastHelper.CInt2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
