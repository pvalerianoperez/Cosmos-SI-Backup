
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class EstatusDocumento
    {        
        public int EstatusDocumentoID { get; set; }            
        public string EstatusDocumentoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int SistemaEstatusTipoDocumentoID { get; set; }            
        public bool Predeterminado { get; set; }
        public bool PredeterminadoSistema { get; set; }
        public bool Restringido { get; set; }
        public bool Monto { get; set; }
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "EstatusDocumento";
                
                //EstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstatusDocumentoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusDocumentoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusDocumentoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //SistemaEstatusTipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaEstatusTipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaEstatusTipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Predeterminado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Predeterminado =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //AltaUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AltaUsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AltaFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AltaFecha =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //ModificacionUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModificacionUsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ModificacionFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModificacionFecha =  CastHelper.CDate2(dr[nombreColumna]);}

                //PredeterminadoSistema
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PredeterminadoSistema", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PredeterminadoSistema = CastHelper.CBool2(dr[nombreColumna]); }

                //Restringido
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Restringido", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Restringido = CastHelper.CBool2(dr[nombreColumna]); }

                //Monto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Monto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Monto = CastHelper.CBool2(dr[nombreColumna]); }


            }
        }
    }
}
