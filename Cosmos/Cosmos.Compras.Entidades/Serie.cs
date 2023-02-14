
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Serie
    {        
        public int SerieID { get; set; }            
        public int TipoDocumentoID { get; set; }            
        public string SerieClave { get; set; }            
        public int FolioInicial { get; set; }            
        public int FolioFinal { get; set; }            
        public int UltimoFolio { get; set; }            
        public bool Estatus { get; set; }            
        public bool Predeterminado { get; set; }
        public int SucursalID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Serie";
                
                //SerieID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SerieID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SerieID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SerieClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SerieClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SerieClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //FolioInicial
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FolioInicial", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FolioInicial =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //FolioFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FolioFinal", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FolioFinal =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UltimoFolio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoFolio", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimoFolio =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Estatus
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Estatus =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Predeterminado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Predeterminado =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //SucursalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SucursalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
                
            }
        }
    }
}
