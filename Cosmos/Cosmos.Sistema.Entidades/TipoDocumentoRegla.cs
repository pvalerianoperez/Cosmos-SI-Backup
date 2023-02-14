
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class TipoDocumentoRegla
    {        
        public int TipoDocumentoReglaID { get; set; }            
        public int SistemaEstatusTipoDocumentoID { get; set; }            
        public int SistemaEstatusTipoDocumentoIDPermite { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaTipoDocumentoRegla";
                
                //TipoDocumentoReglaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoReglaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoReglaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusTipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusTipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusTipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusTipoDocumentoIDPermite
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusTipoDocumentoIDPermite", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusTipoDocumentoIDPermite =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
