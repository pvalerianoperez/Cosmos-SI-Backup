﻿
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Sistema
{
    public partial class TipoMailController : ApiController
    {
        #region CRUD
        
        [HttpPost]
        [Route("api/Sistema/TipoMail/Listado")]
        public RespuestaBase Listado(SolicitudBase solicitud) {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = Cosmos.Sistema.Negocio.TipoMail.Listado();
                }else{
                    throw new Exception("Acceso inválido.");
                }
            }
            catch (Exception ex) {
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
        [Route("api/Sistema/TipoMail/Guardar")]
        public RespuestaBase Guardar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Sistema.Entidades.TipoMail o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.TipoMail>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Sistema.Entidades.TipoMail>(){Cosmos.Sistema.Negocio.TipoMail.Guardar(solicitud.UsuarioID, o)};
                }else{
                    throw new Exception("Acceso inválido.");
                }
            }
            catch (Exception ex) {
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
        [Route("api/Sistema/TipoMail/Eliminar")]
        public RespuestaBase Eliminar(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Sistema.Entidades.TipoMail o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.TipoMail>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Sistema.Negocio.TipoMail.Eliminar(solicitud.UsuarioID, o);
                    respuesta.Datos = null;
                }else{
                    throw new Exception("Acceso inválido.");
                }
            }
            catch (Exception ex) {
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
        [Route("api/Sistema/TipoMail/Consultar")]
        public RespuestaBase Consultar(SolicitudBase solicitud) {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Sistema.Entidades.TipoMail o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.TipoMail>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Sistema.Entidades.TipoMail>(){Cosmos.Sistema.Negocio.TipoMail.Consultar(o)};
                }else{
                    throw new Exception("Acceso inválido.");
                }
            }
            catch (Exception ex) {
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
   
