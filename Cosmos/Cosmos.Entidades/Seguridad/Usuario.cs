
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
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
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CorreoElectronico", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.CorreoElectronico = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Contrasena", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Contrasena = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Alias", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Alias = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Activo = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Intentos", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Intentos = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Bloqueado", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Bloqueado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioAD", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UsuarioAD = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Administrador", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.Administrador = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoAcceso", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UltimoAcceso = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaEmpresaID", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UltimaEmpresaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimoModuloID", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UltimoModuloID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaOpcionID", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UltimaOpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UltimaIP", "SistemaUsuario");
                if(!nombreColumna.Equals("")){this.UltimaIP = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
            }
        }
    }
}
