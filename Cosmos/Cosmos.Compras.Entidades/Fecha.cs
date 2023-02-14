
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Fecha
    {        
        public int FechaID { get; set; }            
        public DateTime Valor { get; set; }            
        public int PersonaID { get; set; }            
        public int TipoFechaID { get; set; }            
        public string Comentario { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Fecha";
                
                //FechaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FechaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Valor
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Valor", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Valor =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //PersonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoFechaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoFechaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoFechaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Comentario
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentario", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Comentario =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
