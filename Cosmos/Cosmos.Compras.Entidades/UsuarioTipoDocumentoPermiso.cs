
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class UsuarioTipoDocumentoPermiso
    {        
        public int UsuarioTipoDocumentoPermisoID { get; set; }            
        public int UsuarioID { get; set; }            
        public int TipoDocumentoID { get; set; }            
        public int CentroCostoID { get; set; }            
        public int AreaID { get; set; }            
        public int EmpresaID { get; set; }            
        public int AlmacenID { get; set; }            
        public int SucursalID { get; set; }            
        public bool Preautoriza { get; set; }            
        public decimal PreautorizarMonto { get; set; }            
        public bool Autoriza { get; set; }            
        public decimal AutorizarMonto { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "UsuarioTipoDocumentoPermiso";
                
                //UsuarioTipoDocumentoPermisoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioTipoDocumentoPermisoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioTipoDocumentoPermisoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TipoDocumentoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
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
                
                //Preautoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Preautoriza", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Preautoriza =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //PreautorizarMonto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PreautorizarMonto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PreautorizarMonto =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //Autoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Autoriza", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Autoriza =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //AutorizarMonto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AutorizarMonto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AutorizarMonto =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
            }
        }
    }
}
