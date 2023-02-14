
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class FamiliaProducto
    {        
        public int FamiliaProductoID { get; set; }            
        public int PadreID { get; set; }            
        public string FamiliaClave { get; set; }            
        public string FamiliaClavePadre { get; set; }            
        public string Nombre { get; set; }
        public string NombreCompleto { get; set; }

        public string NombreCorto { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "FamiliaProducto";
                
                //FamiliaProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FamiliaProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FamiliaProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PadreID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PadreID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PadreID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //FamiliaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FamiliaClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FamiliaClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //FamiliaClavePadre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FamiliaClavePadre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FamiliaClavePadre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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

                //NombreCompleto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCompleto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCompleto = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
    }
}
