
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class UsuarioEstatusDocumentoPermiso
    {        
        public int UsuarioEstatusDocumentoPermisoID { get; set; }            
        public int UsuarioID { get; set; }            
        public int EstatusDocumentoID { get; set; }            
        public int CentroCostoID { get; set; }            
        public int AreaID { get; set; }            
        public int EmpresaID { get; set; }            
        public int AlmacenID { get; set; }            
        public int SucursalID { get; set; }            
        public decimal Monto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "UsuarioEstatusDocumentoPermiso";
                
                //UsuarioEstatusDocumentoPermisoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioEstatusDocumentoPermisoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioEstatusDocumentoPermisoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CentroCostoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CentroCostoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CentroCostoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AreaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AreaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AlmacenID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //SucursalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SucursalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Monto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Monto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Monto =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
            }
        }
    }
}
