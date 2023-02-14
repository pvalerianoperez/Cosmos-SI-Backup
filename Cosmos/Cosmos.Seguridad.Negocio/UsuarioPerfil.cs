
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class UsuarioPerfil
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioPerfil> Listado() {            
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> lst = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_UsuarioPerfil_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.UsuarioPerfil o = new Cosmos.Seguridad.Entidades.UsuarioPerfil();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Consultar(int usuarioID, int perfilID, int empresaID) {
            return Consultar(new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Consultar(Cosmos.Seguridad.Entidades.UsuarioPerfil o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_UsuarioPerfil_Consultar", o.UsuarioID, o.PerfilID, o.EmpresaID);
            o = new Cosmos.Seguridad.Entidades.UsuarioPerfil();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static bool Guardar(int modificacionUsuarioID, int usuarioID, int perfilID, int empresaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.UsuarioPerfil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_UsuarioPerfil_Guardar", modificacionUsuarioID, o.UsuarioID, o.PerfilID, o.EmpresaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int usuarioID, int perfilID, int empresaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.UsuarioPerfil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_UsuarioPerfil_Eliminar", modificacionUsuarioID, o.UsuarioID, o.PerfilID, o.EmpresaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
