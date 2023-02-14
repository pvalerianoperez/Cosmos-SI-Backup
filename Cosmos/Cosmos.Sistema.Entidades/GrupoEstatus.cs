
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class GrupoEstatus
    {        
        public int SistemaGrupoEstatusID { get; set; }            
        public int SistemaGrupoID { get; set; }            
        public string Nombre { get; set; }            
        public int TipoDocumentoID { get; set; }            
        public string Color { get; set; }            
        public bool Activo { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaGrupoEstatus";
                
                //SistemaGrupoEstatusID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaGrupoEstatusID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaGrupoEstatusID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaGrupoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaGrupoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaGrupoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Color
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Color", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Color =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activo =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
