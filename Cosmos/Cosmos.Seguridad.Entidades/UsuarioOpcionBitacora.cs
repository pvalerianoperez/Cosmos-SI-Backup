
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class UsuarioOpcionBitacora
    {        
        public int UsuarioID { get; set; }            
        public DateTime Fecha { get; set; }            
        public int EmpresaID { get; set; }            
        public int ModuloID { get; set; }            
        public int OpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaUsuarioOpcionBitacora";
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Fecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Fecha =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //OpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.OpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
