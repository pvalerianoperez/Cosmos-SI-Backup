
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Compras
{
    public partial class RepresentanteProveedorController : ApiController
    {
        #region CRUD
        
        [HttpPost]
        [Route("api/Compras/RepresentanteProveedor/Listado")]
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
                    respuesta.Datos = Cosmos.Compras.Negocio.RepresentanteProveedor.Listado();
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
        [Route("api/Compras/RepresentanteProveedor/Guardar")]
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
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = JsonConvert.DeserializeObject<Cosmos.Compras.Entidades.RepresentanteProveedor>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>(){Cosmos.Compras.Negocio.RepresentanteProveedor.Guardar(solicitud.UsuarioID, o)};
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
        [Route("api/Compras/RepresentanteProveedor/Eliminar")]
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
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = JsonConvert.DeserializeObject<Cosmos.Compras.Entidades.RepresentanteProveedor>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Compras.Negocio.RepresentanteProveedor.Eliminar(solicitud.UsuarioID, o);
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
        [Route("api/Compras/RepresentanteProveedor/Consultar")]
        public RespuestaBase Consultar(SolicitudBase solicitud) {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = JsonConvert.DeserializeObject<Cosmos.Compras.Entidades.RepresentanteProveedor>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>(){Cosmos.Compras.Negocio.RepresentanteProveedor.Consultar(o)};
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

        [HttpPost]
        [Route("api/Compras/RepresentanteProveedor/ConsultarCompleto")]
        public RespuestaBase ConsultarCompleto(SolicitudBase solicitud)
        {

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            try
            {
                if (Funciones.AccesoValido(solicitud))
                {

                    Cosmos.Compras.Entidades.RepresentanteProveedor oP = JsonConvert.DeserializeObject<Cosmos.Compras.Entidades.RepresentanteProveedor>(JsonConvert.SerializeObject(solicitud.Datos));

                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                    //crea la lista vacia
                    List<Cosmos.Compras.Entidades.RepresentanteProveedor> lst = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();

                    //consulta la base de datos
                    lst.Add(Cosmos.Compras.Negocio.RepresentanteProveedor.ConsultarCompleto(oP.RepresentanteProveedorID));

                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = lst;
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
    }
}
   
