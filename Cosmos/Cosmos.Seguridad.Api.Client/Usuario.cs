
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Usuario
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Usuario> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Usuario Consultar(int usuarioID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Usuario Consultar(Cosmos.Seguridad.Entidades.Usuario o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Usuario resultado = new Cosmos.Seguridad.Entidades.Usuario();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Usuario Guardar(int usuarioID, string correoElectronico, string nombre, string alias, bool activo, int intentos, bool bloqueado, string usuarioAD, bool administrador, DateTime ultimoAcceso, int ultimaEmpresaID, int ultimoModuloID, int ultimaOpcionID, string ultimaIP){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID, CorreoElectronico = correoElectronico, Nombre = nombre, Alias = alias, Activo = activo, Intentos = intentos, Bloqueado = bloqueado, UsuarioAD = usuarioAD, Administrador = administrador, UltimoAcceso = ultimoAcceso, UltimaEmpresaID = ultimaEmpresaID, UltimoModuloID = ultimoModuloID, UltimaOpcionID = ultimaOpcionID, UltimaIP = ultimaIP });
        }

        public static Cosmos.Seguridad.Entidades.Usuario Guardar(Cosmos.Seguridad.Entidades.Usuario o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Usuario resultado = new Cosmos.Seguridad.Entidades.Usuario();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int usuarioID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Usuario() { UsuarioID = usuarioID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Usuario o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static List<Cosmos.Seguridad.Entidades.Modulo> ListadoModulos(SolicitudBase solicitud = null)
        {
           
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Modulo> listado = new List<Cosmos.Seguridad.Entidades.Modulo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/ListadoModulos", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Modulo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Seguridad.Entidades.Empresa> ListadoEmpresas(SolicitudBase solicitud = null)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Empresa> listado = new List<Cosmos.Seguridad.Entidades.Empresa>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/ListadoEmpresas", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Empresa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;

            
        }

        public static List<Cosmos.Seguridad.Entidades.OpcionListado> ListadoOpciones(int usuarioID, int empresaID, int moduloID)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("EmpresaID", empresaID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("ModuloID", moduloID.ToString()));

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.OpcionListado> listado = new List<Cosmos.Seguridad.Entidades.OpcionListado>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/ListadoOpciones", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.OpcionListado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;

          
        }

        public static List<Cosmos.Seguridad.Entidades.OpcionListado> ListadoAcciones(int usuarioID, int empresaID, int moduloID, string urlRecurso)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("EmpresaID", empresaID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("ModuloID", moduloID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("URL", urlRecurso));
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.OpcionListado> listado = new List<Cosmos.Seguridad.Entidades.OpcionListado>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/ListadoAcciones", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.OpcionListado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;

            
        }

        public static List<Cosmos.Seguridad.Entidades.UsuarioPerfil> ListadoPerfiles(int usuarioID)
        {

            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> listado = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Usuario/ListadoPerfiles", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioPerfil>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;

           
        }

        public static RespuestaBase IniciarSesion(string correoElectronico, string contrasena)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("CorreoElectronico", correoElectronico));
            solicitud.Parametros.Add(new ParametroApi("Contrasena", contrasena));
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio            
            

            //intenta llamar al servicio
            try
            {
                respuesta = APIHelper.Execute("api/Seguridad/Usuario/IniciarSesion", solicitud);
                if (!APIHelper.ErrorRespuestaAPI(respuesta))
                {
                    //todo OK!
                }
            }
            catch (Exception ex)
            {

                respuesta.CodigoRespuesta = 0;
                respuesta.MensajeRespuesta = "";
                respuesta.CodigoError = 1;
                respuesta.MensajeError = ex.Message;
                respuesta.Exitoso = false;
                respuesta.Datos = null;
            }

            //regresa la respuesta
            return respuesta;
        }

        public static Cosmos.Seguridad.Entidades.Usuario ActualizaContrasena(int usuarioID, string contrasena)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("Contrasena", contrasena));


            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Usuario resultado = new Cosmos.Seguridad.Entidades.Usuario();
            //intenta llamar al servicio
            try
            {
                //intenta llamar al servicio            
                respuesta = APIHelper.Execute("api/Seguridad/Usuario/ActualizarContrasena", solicitud);
                if (!APIHelper.ErrorRespuestaAPI(respuesta))
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null && listado.Count > 0) {
                        resultado = listado[0];
                    }
                }                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resultado;
        }

        public static Cosmos.Seguridad.Entidades.Usuario GuardarPerfil(int usuarioID, int empresaID, int perfilID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("EmpresaID", empresaID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("PerfilID", perfilID.ToString()));


            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Usuario resultado = new Cosmos.Seguridad.Entidades.Usuario();
            //intenta llamar al servicio
            try
            {
                respuesta = APIHelper.Execute("api/Seguridad/Usuario/GuardarPerfil", solicitud);
                if (!APIHelper.ErrorRespuestaAPI(respuesta))
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null && listado.Count > 0)
                    {
                        resultado = listado[0];
                    }
                }               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resultado;
        }

        public static Cosmos.Seguridad.Entidades.Usuario EliminarPerfil(int usuarioID, int empresaID, int perfilID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("EmpresaID", empresaID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("PerfilID", perfilID.ToString()));


            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Usuario> listado = new List<Cosmos.Seguridad.Entidades.Usuario>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Usuario resultado = new Cosmos.Seguridad.Entidades.Usuario();
            //intenta llamar al servicio
            try
            {
                respuesta = APIHelper.Execute("api/Seguridad/Usuario/EliminarPerfil", solicitud);
                if (!APIHelper.ErrorRespuestaAPI(respuesta))
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null && listado.Count > 0)
                    {
                        resultado = listado[0];
                    }
                }                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resultado;
        }
    }
}
