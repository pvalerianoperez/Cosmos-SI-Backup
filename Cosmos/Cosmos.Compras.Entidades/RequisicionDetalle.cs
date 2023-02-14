
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class RequisicionDetalle
    {        
        public int RequisicionDetalleID { get; set; }            
        public int RequisicionEncabezadoID { get; set; }            
        public int Renglon { get; set; }            
        public int ProductoID { get; set; }            
        public double Cantidad { get; set; }            
        public int UnidadID { get; set; }            
        public int AlmacenID { get; set; }            
        public int ConceptoEgresoID { get; set; }            
        public int CuentaContableID { get; set; }            
        public string DescripcioAdicional { get; set; }            
        public int EstatusDocumentoID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "RequisicionDetalle";
                
                //RequisicionDetalleID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RequisicionDetalleID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.RequisicionDetalleID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //RequisicionEncabezadoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RequisicionEncabezadoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.RequisicionEncabezadoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Renglon
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Renglon", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Renglon =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ProductoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Cantidad
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Cantidad", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Cantidad = CastHelper.CDbl2(dr[nombreColumna]);}   
                
                //UnidadID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UnidadID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UnidadID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AlmacenID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ConceptoEgresoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConceptoEgresoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ConceptoEgresoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CuentaContableID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CuentaContableID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CuentaContableID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //DescripcioAdicional
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DescripcioAdicional", prefijoTabla);
                if(!nombreColumna.Equals("")){this.DescripcioAdicional =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //EstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
