
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Sistema
{
    public partial class ClaseProductoController : ApiController
    {
        #region CRUD
        
        [HttpPost]
        [Route("api/Sistema/ClaseProducto/Listado")]
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
                    respuesta.Datos = Cosmos.Sistema.Negocio.ClaseProducto.Listado();
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
        [Route("api/Sistema/ClaseProducto/Guardar")]
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
                    Cosmos.Sistema.Entidades.ClaseProducto o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.ClaseProducto>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Sistema.Entidades.ClaseProducto>(){Cosmos.Sistema.Negocio.ClaseProducto.Guardar(solicitud.UsuarioID, o)};
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
        [Route("api/Sistema/ClaseProducto/Eliminar")]
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
                    Cosmos.Sistema.Entidades.ClaseProducto o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.ClaseProducto>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Sistema.Negocio.ClaseProducto.Eliminar(solicitud.UsuarioID, o);
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
        [Route("api/Sistema/ClaseProducto/Consultar")]
        public RespuestaBase Consultar(SolicitudBase solicitud) {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Sistema.Entidades.ClaseProducto o = JsonConvert.DeserializeObject<Cosmos.Sistema.Entidades.ClaseProducto>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Sistema.Entidades.ClaseProducto>(){Cosmos.Sistema.Negocio.ClaseProducto.Consultar(o)};
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
   
