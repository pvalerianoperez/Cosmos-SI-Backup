
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Almacen
    {        
        public int AlmacenID { get; set; }            
        public string AlmacenClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int SucursalID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Almacen";
                
                //AlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AlmacenID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AlmacenClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AlmacenClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
