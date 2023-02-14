
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Cosmos.Mensajeria.Chat.Negocio;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Mensajeria.Chat
{
    public partial class ConversacionController : ApiController
    {
        #region CRUD

        [HttpPost]
        [Route("api/Mensajeria/Conversacion/Listado")]
        public RespuestaBase Listado(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = Cosmos.Mensajeria.Chat.Negocio.Conversacion.Listado();
                }
                else
                {
                    throw new Exception("Acceso inválido.");
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

        [HttpPost]
        [Route("api/Mensajeria/Conversacion/Guardar")]
        public RespuestaBase Guardar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Mensajeria.Chat.Entidades.Conversacion o = JsonConvert.DeserializeObject<Cosmos.Mensajeria.Chat.Entidades.Conversacion>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>() { Cosmos.Mensajeria.Chat.Negocio.Conversacion.Guardar(solicitud.UsuarioID, o) };
                }
                else
                {
                    throw new Exception("Acceso inválido.");
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

        [HttpPost]
        [Route("api/Mensajeria/Conversacion/Eliminar")]
        public RespuestaBase Eliminar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Mensajeria.Chat.Entidades.Conversacion o = JsonConvert.DeserializeObject<Cosmos.Mensajeria.Chat.Entidades.Conversacion>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Mensajeria.Chat.Negocio.Conversacion.Eliminar(solicitud.UsuarioID, o);
                    respuesta.Datos = null;
                }
                else
                {
                    throw new Exception("Acceso inválido.");
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

        [HttpPost]
        [Route("api/Mensajeria/Conversacion/Consultar")]
        public RespuestaBase Consultar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Mensajeria.Chat.Entidades.Conversacion o = JsonConvert.DeserializeObject<Cosmos.Mensajeria.Chat.Entidades.Conversacion>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    //respuesta.Datos = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>() { Cosmos.Mensajeria.Chat.Negocio.Conversacion.Consultar(solicitud.UsuarioID, o) };
                }
                else
                {
                    throw new Exception("Acceso inválido.");
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



        #endregion
    }
}
