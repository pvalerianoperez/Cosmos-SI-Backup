using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class TipoMensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje Consultar(int tipoMensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje Consultar(Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje Guardar(int tipoMensajeID, string tipoClave, string nombre, string nombreCorto)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID, TipoClave = tipoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje Guardar(Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int tipoMensajeID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.TipoMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
