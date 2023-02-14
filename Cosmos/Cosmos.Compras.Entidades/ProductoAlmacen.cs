
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ProductoAlmacen
    {        
        public int ProductoAlmacenID { get; set; }            
        public int ProductoID { get; set; }            
        public int AlmacenID { get; set; }            
        public decimal Maximo { get; set; }            
        public decimal Minimo { get; set; }            
        public decimal Reorden { get; set; }            
        public decimal CostoPromedio { get; set; }            
        public decimal UltimoCosto { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ProductoAlmacen";
                
                //ControlProductoAlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoAlmacenID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoAlmacenID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AlmacenID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Maximo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Maximo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Maximo =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //Minimo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Minimo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Minimo =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //Reorden
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Reorden", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Reorden =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //CostoPromedio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CostoPromedio", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CostoPromedio =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //UltimoCosto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoCosto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimoCosto =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
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
