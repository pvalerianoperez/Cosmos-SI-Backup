
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class TipoDocumento
    {        
        public int TipoDocumentoID { get; set; }            
        public string TipoDocumentoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public bool Estatus { get; set; }            
        public int ModuloID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaTipoDocumento";
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoDocumentoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Estatus
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Estatus =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
