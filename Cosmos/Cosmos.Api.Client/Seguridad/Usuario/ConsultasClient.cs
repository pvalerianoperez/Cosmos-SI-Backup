using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cosmos.Api.Client;
using Cosmos.Api.Entidades;
using Cosmos.Entidades.Seguridad;
using Newtonsoft.Json;

namespace Cosmos.Api.Client.Seguridad
{
    public partial class Usuario
    {
        public static List<Cosmos.Entidades.Seguridad.Modulo> ListadoModulos(SolicitudBase solicitud = null)
        {

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.Modulo> listado = new List<Cosmos.Entidades.Seguridad.Modulo>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ListadoModulos", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Modulo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }
            catch (Exception ex)
            {
                //throw (ex);
            }

            //regresa la respuesta
            return listado;
        }
        public static List<Cosmos.Entidades.Seguridad.Empresa> ListadoEmpresas(SolicitudBase solicitud = null)
        {

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.Empresa> listado = new List<Cosmos.Entidades.Seguridad.Empresa>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ListadoEmpresas", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Empresa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }
            catch (Exception ex)
            {
                //throw (ex);               
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Entidades.Seguridad.OpcionListado> ListadoOpciones(int usuarioID, int empresaID, int moduloID)
        {
            
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", AppGlobals.UsuarioID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("EmpresaID", AppGlobals.EmpresaID.ToString()));
            solicitud.Parametros.Add(new ParametroApi("ModuloID", AppGlobals.ModuloID.ToString()));

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.OpcionListado> listado = new List<Cosmos.Entidades.Seguridad.OpcionListado>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ListadoOpciones", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.OpcionListado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }
            catch (Exception ex)
            {                                
                //throw (ex);
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Entidades.Seguridad.OpcionListado> ListadoAcciones(int usuarioID, int empresaID, int moduloID, string urlRecurso)
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
            List<Cosmos.Entidades.Seguridad.OpcionListado> listado = new List<Cosmos.Entidades.Seguridad.OpcionListado>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ListadoAcciones", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.OpcionListado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }
            catch (Exception ex)
            {
                //throw (ex);
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Entidades.Seguridad.UsuarioPerfil> ListadoPerfiles(int usuarioID)
        {

            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Parametros = new List<ParametroApi>();
            solicitud.Parametros.Add(new ParametroApi("UsuarioID", usuarioID.ToString()));

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.UsuarioPerfil> listado = new List<Cosmos.Entidades.Seguridad.UsuarioPerfil>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Usuario/ListadoPerfiles", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.UsuarioPerfil>>(JsonConvert.SerializeObject(respuesta.Datos));
            }
            catch (Exception ex)
            {
                //throw (ex);
            }

            //regresa la respuesta
            return listado;
        }
    }
}