
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class ControlProductoAlmacen
    {        
        public int ControlProductoAlmacenID { get; set; }            
        public int ProductoID { get; set; }            
        public int AlmacenID { get; set; }            
        public Decimal Maximo { get; set; }            
        public Decimal Minimo { get; set; }            
        public Decimal Reorden { get; set; }            
        public Decimal CostoPromedio { get; set; }            
        public Decimal UltimoCosto { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ControlProductoAlmacenID", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.ControlProductoAlmacenID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.ProductoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.AlmacenID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Maximo", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.Maximo = CDecimal2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Minimo", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.Minimo = CDecimal2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Reorden", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.Reorden = CDecimal2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CostoPromedio", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.CostoPromedio = CDecimal2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoCosto", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.UltimoCosto = CDecimal2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "ControlProductoAlmacen");
                if(!nombreColumna.Equals("")){this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
            }
        }
    }
}
