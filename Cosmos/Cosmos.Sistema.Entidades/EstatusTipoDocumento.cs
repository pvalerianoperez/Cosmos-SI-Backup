
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class EstatusTipoDocumento
    {        
        public int SistemaEstatusTipoDocumentoID { get; set; }            
        public int SistemaEstatusDocumentoID { get; set; }            
        public int TipoDocumentoID { get; set; }            
        public bool Predeterminado { get; set; }            
        public bool Restringido { get; set; }            
        public bool Monto { get; set; }
        public string Nombre { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaEstatusTipoDocumento";
                
                //SistemaEstatusTipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusTipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusTipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Predeterminado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Predeterminado =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Restringido
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Restringido", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Restringido =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Monto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Monto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Monto =  CastHelper.CBool2(dr[nombreColumna]);}

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
