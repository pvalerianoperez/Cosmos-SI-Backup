using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Seguridad
{
    public partial class Usuario
    {
        public static RespuestaBase IniciarSesion(string correoElectronico, string contrasena)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("CorreoElectronico", correoElectronico));
            solicitud.Parametros.Add(new ParametroApi("Contrasena", contrasena));
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/IniciarSesion", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
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

        public static Cosmos.Entidades.Seguridad.Usuario ActualizaContrasena(int usuarioID, string contrasena)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("Contrasena", contrasena));


            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.Usuario> listado = new List<Cosmos.Entidades.Seguridad.Usuario>();

            //resultado del metodo 
            Cosmos.Entidades.Seguridad.Usuario resultado = new Cosmos.Entidades.Seguridad.Usuario();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ActualizarContrasena", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null)
                    {
                        if (listado.Count > 0)
                        {
                            resultado = listado[0];
                        }
                    }
                }
                else
                {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resultado;
        }

        public static Cosmos.Entidades.Seguridad.Usuario GuardarPerfil(int usuarioID, int empresaID, int perfilID)
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
            List<Cosmos.Entidades.Seguridad.Usuario> listado = new List<Cosmos.Entidades.Seguridad.Usuario>();

            //resultado del metodo 
            Cosmos.Entidades.Seguridad.Usuario resultado = new Cosmos.Entidades.Seguridad.Usuario();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/GuardarPerfil", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null)
                    {
                        if (listado.Count > 0)
                        {
                            resultado = listado[0];
                        }
                    }
                }
                else
                {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resultado;
        }

        public static Cosmos.Entidades.Seguridad.Usuario EliminarPerfil(int usuarioID, int empresaID, int perfilID)
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
            List<Cosmos.Entidades.Seguridad.Usuario> listado = new List<Cosmos.Entidades.Seguridad.Usuario>();

            //resultado del metodo 
            Cosmos.Entidades.Seguridad.Usuario resultado = new Cosmos.Entidades.Seguridad.Usuario();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/EliminarPerfil", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Usuario>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if (listado != null)
                    {
                        if (listado.Count > 0)
                        {
                            resultado = listado[0];
                        }
                    }
                }
                else
                {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
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