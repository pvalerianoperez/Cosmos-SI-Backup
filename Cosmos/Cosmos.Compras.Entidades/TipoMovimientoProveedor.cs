
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class TipoMovimientoProveedor
    {        
        public int TipoMovimientoProveedorID { get; set; }            
        public string TipoMovimientoProveedorClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int NaturalezaID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "TipoMovimientoProveedor";
                
                //TipoMovimientoProveedorID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMovimientoProveedorID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMovimientoProveedorID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoMovimientoProveedorClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMovimientoProveedorClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoMovimientoProveedorClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NaturalezaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NaturalezaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NaturalezaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
