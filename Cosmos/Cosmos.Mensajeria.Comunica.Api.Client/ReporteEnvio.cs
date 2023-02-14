using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class ReporteEnvio
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/ReporteEnvio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Consultar(int reporteEnvioID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio() { ReporteEnvioID = reporteEnvioID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Consultar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio resultado = new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/ReporteEnvio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Guardar(int reporteEnvioID, int remitenteID, string tema, DateTime fecha)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio() { ReporteEnvioID = reporteEnvioID, RemitenteID = remitenteID, Tema = tema, Fecha = fecha });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Guardar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio resultado = new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/ReporteEnvio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int reporteEnvioID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio() { ReporteEnvioID = reporteEnvioID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/ReporteEnvio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
