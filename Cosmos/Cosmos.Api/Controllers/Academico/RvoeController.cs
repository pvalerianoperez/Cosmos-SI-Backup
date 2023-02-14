
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Api.Models;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Academico
{
    public class RvoeController : ApiController
    {
        #region CRUD

        [HttpPost]
        [Route("api/Academico/Rvoe/Listado")]
        [JWTAuthorize(PermissionCatalogue.NONE)]
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
                    respuesta.Datos = Cosmos.Academico.Negocio.Rvoe.Listado();
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
        [Route("api/Academico/Rvoe/Guardar")]
        [JWTAuthorize(PermissionCatalogue.NONE)]
        public RespuestaBase Guardar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //******************************************************************************************
                    // - Consigo la descripción que va para el Log.
                    // - Genero el objeto oDataForLog para el Log
                    string descripcionForLog = Funciones.ValorParametroApi(solicitud, "DescripcionForLog", "");

                    var userToken = Cosmos.Seguridad.Negocio.UsuarioToken.GetInstance();
                    Cosmos.Seguridad.Entidades.DataForLog oDataForLog = new Cosmos.Seguridad.Entidades.DataForLog(userToken, descripcionForLog);
                    //******************************************************************************************

                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Academico.Entidades.Rvoe o = JsonConvert.DeserializeObject<Cosmos.Academico.Entidades.Rvoe>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Academico.Entidades.Rvoe>() { Cosmos.Academico.Negocio.Rvoe.Guardar(o, oDataForLog) };
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
        [Route("api/Academico/Rvoe/Eliminar")]
        [JWTAuthorize(PermissionCatalogue.NONE)]
        public RespuestaBase Eliminar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //******************************************************************************************
                    // - Consigo la descripción que va para el Log.
                    // - Genero el objeto oDataForLog para el Log
                    string descripcionForLog = Funciones.ValorParametroApi(solicitud, "DescripcionForLog", "");

                    var userToken = Cosmos.Seguridad.Negocio.UsuarioToken.GetInstance();
                    Cosmos.Seguridad.Entidades.DataForLog oDataForLog = new Cosmos.Seguridad.Entidades.DataForLog(userToken, descripcionForLog);
                    //******************************************************************************************

                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Academico.Entidades.Rvoe o = JsonConvert.DeserializeObject<Cosmos.Academico.Entidades.Rvoe>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Academico.Negocio.Rvoe.Eliminar(o.RvoeID, oDataForLog);
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
        [Route("api/Academico/Rvoe/Consultar")]
        [JWTAuthorize(PermissionCatalogue.NONE)]
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
                    Cosmos.Academico.Entidades.Rvoe o = JsonConvert.DeserializeObject<Cosmos.Academico.Entidades.Rvoe>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Academico.Entidades.Rvoe>() { Cosmos.Academico.Negocio.Rvoe.Consultar(o) };
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
