
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class Usuario
    {        
        public int UsuarioID { get; set; }            
        public string CorreoElectronico { get; set; }            
        public string Contrasena { get; set; }            
        public string Nombre { get; set; }            
        public string Alias { get; set; }            
        public bool Activo { get; set; }            
        public int Intentos { get; set; }            
        public bool Bloqueado { get; set; }            
        public string UsuarioAD { get; set; }            
        public bool Administrador { get; set; }            
        public DateTime UltimoAcceso { get; set; }            
        public int UltimaEmpresaID { get; set; }            
        public int UltimoModuloID { get; set; }            
        public int UltimaOpcionID { get; set; }            
        public string UltimaIP { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaUsuario";
                
                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CorreoElectronico
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CorreoElectronico", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CorreoElectronico =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Contrasena
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Contrasena", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Contrasena =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Alias
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Alias", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Alias =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activo =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Intentos
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Intentos", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Intentos =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Bloqueado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Bloqueado", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Bloqueado =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //UsuarioAD
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioAD", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UsuarioAD =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Administrador
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Administrador", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Administrador =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //UltimoAcceso
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoAcceso", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimoAcceso =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //UltimaEmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaEmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimaEmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UltimoModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimoModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UltimaOpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaOpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimaOpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //UltimaIP
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaIP", prefijoTabla);
                if(!nombreColumna.Equals("")){this.UltimaIP =  CastHelper.CStr2(dr[nombreColumna]);}   
                
            }
        }
    }
}
