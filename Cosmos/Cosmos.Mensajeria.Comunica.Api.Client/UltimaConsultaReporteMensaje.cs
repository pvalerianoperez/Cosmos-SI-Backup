using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class UltimaConsultaReporteMensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaReporteMensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje Consultar(int usuarioID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje() { UsuarioID = usuarioID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje Consultar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaReporteMensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje Guardar(int usuarioID, DateTime fechaUltimaConsulta)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje() { UsuarioID = usuarioID, FechaUltimaConsulta = fechaUltimaConsulta });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje Guardar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaReporteMensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int usuarioID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje() { UsuarioID = usuarioID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.UltimaConsultaReporteMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/UltimaConsultaReporteMensaje/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
