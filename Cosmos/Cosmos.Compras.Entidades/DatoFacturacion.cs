
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class DatoFacturacion
    {        
        public int DatoFacturacionID { get; set; }            
        public int PersonaID { get; set; }            
        public string RFC { get; set; }            
        public int DomicilioID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "DatoFacturacion";
                
                //DatoFacturacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DatoFacturacionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.DatoFacturacionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //RFC
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RFC", prefijoTabla);
                if(!nombreColumna.Equals("")){this.RFC =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //DomicilioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.DomicilioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
