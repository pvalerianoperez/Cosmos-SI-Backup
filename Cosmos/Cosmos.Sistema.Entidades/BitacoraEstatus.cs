
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class BitacoraEstatus
    {        
        public int BitacoraEstatusID { get; set; }            
        public int TipoDocumentoID { get; set; }            
        public int DocumentoID { get; set; }            
        public int UsuarioID { get; set; }            
        public int SistemaEstatusDocumentoID { get; set; }            
        public int SistemaEstatusDocumentoIDAnterior { get; set; }            
        public DateTime FechaHora { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaBitacoraEstatus";
                
                //BitacoraEstatusID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BitacoraEstatusID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.BitacoraEstatusID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //DocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.DocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SistemaEstatusDocumentoIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusDocumentoIDAnterior", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusDocumentoIDAnterior =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //FechaHora
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaHora", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FechaHora =  CastHelper.CDate2(dr[nombreColumna]);}   
                
            }
        }
    }
}
