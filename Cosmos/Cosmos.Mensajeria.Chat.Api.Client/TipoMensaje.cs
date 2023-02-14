using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Chat.Api.Client
{
    public class TipoMensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Consultar(int tipoMensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Consultar(Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.TipoMensaje resultado = new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Guardar(int tipoMensajeID, string tipoNombre)
        {
            return Guardar(new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID, TipoNombre = tipoNombre });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Guardar(Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.TipoMensaje resultado = new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/TipoMensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int tipoMensajeID)
        {
            return Eliminar(new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = tipoMensajeID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
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
