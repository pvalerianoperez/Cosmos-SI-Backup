
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Producto
    {        
        public int ProductoID { get; set; }            
        public int MarcaID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int UnidadID { get; set; }            
        public int ClaseProductoID { get; set; }            
        public int TipoProductoID { get; set; }            
        public int NivelProductoID { get; set; }            
        public int MetodoCosteoID { get; set; }            
        public bool ManejaLotes { get; set; }            
        public bool ManejaSeries { get; set; }            
        public Decimal Reorden { get; set; }            
        public int FamiliaProductoID { get; set; }            
        public int EstatusProductoID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }    
        
        public List<ProductoEmpresa> Empresas { get; set; }
        public List<ProductoAlmacen> Almacenes { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Producto";
                
                //ProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //MarcaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MarcaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MarcaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //UnidadID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UnidadID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UnidadID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ClaseProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ClaseProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ClaseProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //NivelProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NivelProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //MetodoCosteoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MetodoCosteoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.MetodoCosteoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ManejaLotes
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ManejaLotes", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ManejaLotes =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //ManejaSeries
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ManejaSeries", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ManejaSeries =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Reorden
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Reorden", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Reorden =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //FamiliaProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FamiliaProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.FamiliaProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstatusProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
