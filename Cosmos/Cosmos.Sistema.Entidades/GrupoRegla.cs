
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class GrupoRegla
    {        
        public int SistemaGrupoReglaID { get; set; }            
        public int SistemaGrupoEstatusID { get; set; }            
        public int SistemaEstatusTipoDocumentoID { get; set; }            
        public bool Activo { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaGrupoRegla";
                
                //SistemaGrupoReglaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaGrupoReglaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaGrupoReglaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaGrupoEstatusID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaGrupoEstatusID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaGrupoEstatusID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusTipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusTipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusTipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activo =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
