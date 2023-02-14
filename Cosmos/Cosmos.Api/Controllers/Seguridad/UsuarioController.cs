
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Cosmos.Seguridad.Negocio;
using Newtonsoft.Json;

namespace Cosmos.Api.Controllers.Seguridad
{
    public partial class UsuarioController : ApiController
    {
        #region CRUD
        
        [HttpPost]
        [Route("api/Seguridad/Usuario/Listado")]
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
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.Listado();
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
        [Route("api/Seguridad/Usuario/Guardar")]
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
                    Cosmos.Seguridad.Entidades.Usuario o = JsonConvert.DeserializeObject<Cosmos.Seguridad.Entidades.Usuario>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Seguridad.Entidades.Usuario>(){Cosmos.Seguridad.Negocio.Usuario.Guardar(solicitud.UsuarioID, o)};
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
        [Route("api/Seguridad/Usuario/Eliminar")]
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
                    Cosmos.Seguridad.Entidades.Usuario o = JsonConvert.DeserializeObject<Cosmos.Seguridad.Entidades.Usuario>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = Cosmos.Seguridad.Negocio.Usuario.Eliminar(solicitud.UsuarioID, o);
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
        [Route("api/Seguridad/Usuario/Consultar")]
        public RespuestaBase Consultar(SolicitudBase solicitud) {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud)) {                    
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;                    
                    //obtiene el objeto que se utilizara como parametro
                    Cosmos.Seguridad.Entidades.Usuario o = JsonConvert.DeserializeObject<Cosmos.Seguridad.Entidades.Usuario>(JsonConvert.SerializeObject(solicitud.Datos));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";                
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = new List<Cosmos.Seguridad.Entidades.Usuario>(){Cosmos.Seguridad.Negocio.Usuario.Consultar(o)};
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
        [AllowAnonymous]
        [Route("api/Seguridad/Usuario/IniciarSesion")]
        public HttpResponseMessage IniciarSesion(SolicitudBase solicitud)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                //lee los parametros necesarios
                string correoElectronico = Funciones.ValorParametroApi(solicitud, "CorreoElectronico", "");
                string contrasena = Funciones.ValorParametroApi(solicitud, "Contrasena", "");
                string nombreHost = Funciones.ValorParametroApi(solicitud, "NombreHost", "");
                string ip = ((System.Web.HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["REMOTE_ADDR"];
                int utc = Cosmos.Framework.CastHelper.CInt2((Funciones.ValorParametroApi(solicitud, "Utc", "")));

                List<Cosmos.Seguridad.Entidades.Usuario> lst = new List<Cosmos.Seguridad.Entidades.Usuario>();
                Cosmos.Seguridad.Entidades.Usuario o = Cosmos.Seguridad.Negocio.Usuario.IniciarSesion(correoElectronico, contrasena, ip);
                if (o != null && o.UsuarioID > 0)
                {

                    lst.Add(o);
                    respuesta.UsuarioID = o.UsuarioID;
                    respuesta.Datos = lst;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    response = Request.CreateResponse<RespuestaBase>(HttpStatusCode.OK, respuesta);

                    // ***************************************************************
                    // Le agregamos el encabezado con el token
                    var userToken = UsuarioToken.Crear(o, nombreHost, ip, utc);
                    response.Headers.Add("Access-Token", userToken.GetJwt());
                    // ***************************************************************


                }
                else {
                    throw new Exception("No se encontró el usuario.");
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
                response = Request.CreateResponse<RespuestaBase>(HttpStatusCode.OK, respuesta);
            }

            //regresa la respuesta
            return response;
        }

        [HttpPost]
        [Route("api/Seguridad/Usuario/ActualizarContrasena")]
        public RespuestaBase ActualizarContrasena(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                //lee los parametros necesarios
                int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                string contrasena = Funciones.ValorParametroApi(solicitud, "Contrasena", "");
                string ip = ((System.Web.HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["REMOTE_ADDR"];

                List<Cosmos.Seguridad.Entidades.Usuario> lst = new List<Cosmos.Seguridad.Entidades.Usuario>();
                Cosmos.Seguridad.Entidades.Usuario o = Cosmos.Seguridad.Negocio.Usuario.ActualizarContrasena(usuarioID, contrasena, ip);
                if (o != null && o.UsuarioID > 0)
                {
                    lst.Add(o);
                    respuesta.Datos = lst;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                }
                else
                {
                    throw new Exception("No se encontró el usuario.");
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
        [Route("api/Seguridad/Usuario/GuardarPerfil")]
        public RespuestaBase GuardarPerfil(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                //lee los parametros necesarios
                int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                int empresaID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "EmpresaID", "0"));
                int perfilID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "PerfilID", "0"));

                
                
                if (Cosmos.Seguridad.Negocio.Usuario.GuardarPerfil(usuarioID,empresaID,perfilID))
                {
                    respuesta.Datos = null;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                }
                else
                {
                    throw new Exception("No se encontró perfil.");
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
        [Route("api/Seguridad/Usuario/EliminarPerfil")]
        public RespuestaBase EliminarPerfil(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                //lee los parametros necesarios
                int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                int empresaID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "EmpresaID", "0"));
                int perfilID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "PerfilID", "0"));



                if (Cosmos.Seguridad.Negocio.Usuario.EliminarPerfil(usuarioID, empresaID, perfilID))
                {
                    respuesta.Datos = null;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                }
                else
                {
                    throw new Exception("No se encontró perfil.");
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
        [Route("api/Seguridad/Usuario/ListadoOpciones")]
        public RespuestaBase ListadoOpciones(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                    int empresaID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "EmpresaID", "0"));
                    int moduloID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "ModuloID", "0"));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.ListadoOpciones(usuarioID, empresaID, moduloID);
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
        [Route("api/Seguridad/Usuario/ListadoAcciones")]
        public RespuestaBase ListadoAcciones(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                    int empresaID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "EmpresaID", "0"));
                    int moduloID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "ModuloID", "0"));
                    string url = CastHelper.CStr2(Funciones.ValorParametroApi(solicitud, "URL", ""));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.ListadoAcciones(usuarioID, empresaID, moduloID, url);
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
        [Route("api/Seguridad/Usuario/ListadoModulos")]
        public RespuestaBase ListadoModulos(SolicitudBase solicitud)
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
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.ListadoModulos(solicitud.UsuarioID, solicitud.EmpresaID);
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
        [Route("api/Seguridad/Usuario/ListadoEmpresas")]
        public RespuestaBase ListadoEmpresas(SolicitudBase solicitud)
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
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.ListadoEmpresas(solicitud.UsuarioID);
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
        [Route("api/Seguridad/Usuario/ListadoPerfiles")]
        public RespuestaBase ListadoPerfiles(SolicitudBase solicitud)
        {
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                if (Funciones.AccesoValido(solicitud))
                {
                    //establece la conexion
                    SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;
                    //consulta la base de datos
                    int usuarioID = CastHelper.CInt2(Funciones.ValorParametroApi(solicitud, "UsuarioID", "0"));
                    //prepara la respuesta
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "OK";
                    respuesta.CodigoError = 0;
                    respuesta.MensajeError = "";
                    respuesta.Exitoso = true;
                    respuesta.Datos = Cosmos.Seguridad.Negocio.Usuario.ListadoPerfiles(usuarioID);
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
   
