
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ProductoEmpresa
    {        
        public int ProductoEmpresaID { get; set; }            
        public int EmpresaID { get; set; }            
        public int ProductoID { get; set; }            
        public string ProductoClave { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ProductoEmpresa";
                
                //ProductoEmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoEmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoEmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ProductoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
