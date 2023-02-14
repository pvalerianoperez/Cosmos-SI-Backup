
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class CuentaContable
    {        
        public int CuentaContableID { get; set; }            
        public string CuentaContableClave { get; set; }            
        public string Nombre { get; set; }            
        public int PerteneceCuentaContableID { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "CuentaContable";
                
                //CuentaContableID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CuentaContableID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CuentaContableID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CuentaContableClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CuentaContableClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CuentaContableClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //PerteneceCuentaContableID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerteneceCuentaContableID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PerteneceCuentaContableID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
