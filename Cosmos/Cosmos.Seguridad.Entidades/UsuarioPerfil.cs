
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class UsuarioPerfil
    {        
        public int UsuarioID { get; set; }            
        public int PerfilID { get; set; }            
        public int EmpresaID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaUsuarioPerfil";
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PerfilID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerfilID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PerfilID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
