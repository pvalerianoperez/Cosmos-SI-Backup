
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Usuario
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Usuario> Listado() {            
            List<Cosmos.Seguridad.Entidades.Usuario> lst = new List<Cosmos.Seguridad.Entidades.Usuario>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Usuario o = new Cosmos.Seguridad.Entidades.Usuario();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Usuario Consultar(int usuarioID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Usuario Consultar(Cosmos.Seguridad.Entidades.Usuario o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_Consultar", o.UsuarioID);
            o = new Cosmos.Seguridad.Entidades.Usuario();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Usuario Guardar(int modificacionUsuarioID, int usuarioID, string correoElectronico, string nombre, string alias, bool activo, int intentos, bool bloqueado, string usuarioAD, bool administrador, DateTime ultimoAcceso, int ultimaEmpresaID, int ultimoModuloID, int ultimaOpcionID, string ultimaIP) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID, CorreoElectronico = correoElectronico, Nombre = nombre, Alias = alias, Activo = activo, Intentos = intentos, Bloqueado = bloqueado, UsuarioAD = usuarioAD, Administrador = administrador, UltimoAcceso = ultimoAcceso, UltimaEmpresaID = ultimaEmpresaID, UltimoModuloID = ultimoModuloID, UltimaOpcionID = ultimaOpcionID, UltimaIP = ultimaIP  });
        }
        
        public static Cosmos.Seguridad.Entidades.Usuario Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Usuario o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_Guardar", modificacionUsuarioID, o.UsuarioID, o.CorreoElectronico, o.Nombre, o.Alias, o.Activo, o.Intentos, o.Bloqueado, o.UsuarioAD, o.Administrador, o.UltimoAcceso, o.UltimaEmpresaID, o.UltimoModuloID, o.UltimaOpcionID, o.UltimaIP);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["UsuarioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int usuarioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Usuario o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_Eliminar", modificacionUsuarioID, o.UsuarioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion
        public static Cosmos.Seguridad.Entidades.Usuario IniciarSesion(string correoElectronico, string contrasena, string ip)
        {
            Cosmos.Seguridad.Entidades.Usuario o = null;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_IniciarSesion", correoElectronico, contrasena, ip);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["UsuarioID"]);
            }

            return o;
        }

        public static Cosmos.Seguridad.Entidades.Usuario ActualizarContrasena(int usuarioID, string contrasena, string ip)
        {
            Cosmos.Seguridad.Entidades.Usuario o = null;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_ActualizarContrasena", usuarioID, contrasena, ip);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["UsuarioID"]);
            }

            return o;
        }

        public static bool GuardarPerfil(int usuarioID, int empresaID, int perfilID)
        {
            Cosmos.Seguridad.Entidades.Usuario o = null;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_GuardarPerfil", usuarioID, empresaID, perfilID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                return true;
            }

            return false;
        }

        public static bool EliminarPerfil(int usuarioID, int empresaID, int perfilID)
        {
            Cosmos.Seguridad.Entidades.Usuario o = null;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Usuario_EliminarPerfil", usuarioID, empresaID, perfilID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                return true;
            }

            return false;
        }

        public static List<Cosmos.Seguridad.Entidades.OpcionListado> ListadoOpciones(int usuarioID, int empresaID, int moduloID)
        {
            List<Cosmos.Seguridad.Entidades.OpcionListado> lst = new List<Cosmos.Seguridad.Entidades.OpcionListado>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_ListadoOpciones", usuarioID, empresaID, moduloID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.OpcionListado o = new Cosmos.Seguridad.Entidades.OpcionListado();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Seguridad.Entidades.OpcionListado> ListadoAcciones(int usuarioID, int empresaID, int moduloID, string url)
        {
            List<Cosmos.Seguridad.Entidades.OpcionListado> lst = new List<Cosmos.Seguridad.Entidades.OpcionListado>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_ListadoAcciones", usuarioID, empresaID, moduloID, url);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.OpcionListado o = new Cosmos.Seguridad.Entidades.OpcionListado();
                    o.Load(dr);
                    o.Migaja = CastHelper.CStr2(dr["Migaja"]);
                    o.AccionesDisponibles = CastHelper.CStr2(dr["AccionesDisponibles"]).Trim().Replace(" ", "").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    o.AccionesPermitidas = CastHelper.CStr2(dr["AccionesPermitidas"]).Trim().Replace(" ", "").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Seguridad.Entidades.Modulo> ListadoModulos(int usuarioID, int empresaID)
        {
            List<Cosmos.Seguridad.Entidades.Modulo> lst = new List<Cosmos.Seguridad.Entidades.Modulo>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_ListadoModulos", usuarioID, empresaID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Modulo o = new Cosmos.Seguridad.Entidades.Modulo();
                    o.Load(dr);                   
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Seguridad.Entidades.Empresa> ListadoEmpresas(int usuarioID)
        {
            List<Cosmos.Seguridad.Entidades.Empresa> lst = new List<Cosmos.Seguridad.Entidades.Empresa>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_ListadoEmpresas", usuarioID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Empresa o = new Cosmos.Seguridad.Entidades.Empresa();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Seguridad.Entidades.UsuarioPerfil> ListadoPerfiles(int usuarioID)
        {
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> lst = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Usuario_Perfil_Listado", usuarioID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.UsuarioPerfil o = new Cosmos.Seguridad.Entidades.UsuarioPerfil();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
    }
}
