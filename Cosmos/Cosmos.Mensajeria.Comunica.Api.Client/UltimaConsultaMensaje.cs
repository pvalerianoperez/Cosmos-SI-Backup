using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class UltimaConsultaMensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaMensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje Consultar(int usuarioID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje() { UsuarioID = usuarioID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje Consultar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaMensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje Guardar(int usuarioID, DateTime fechaUltimaConsulta)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje() { UsuarioID = usuarioID, FechaUltimaConsulta = fechaUltimaConsulta });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje Guardar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaMensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int usuarioID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje() { UsuarioID = usuarioID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaMensaje/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
