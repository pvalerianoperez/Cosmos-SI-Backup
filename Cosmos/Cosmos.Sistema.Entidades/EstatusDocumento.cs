
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class EstatusDocumento
    {        
        public int SistemaEstatusDocumentoID { get; set; }            
        public string SistemaEstatusDocumentoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaEstatusDocumento";
                
                //SistemaEstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusDocumentoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusDocumentoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusDocumentoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
