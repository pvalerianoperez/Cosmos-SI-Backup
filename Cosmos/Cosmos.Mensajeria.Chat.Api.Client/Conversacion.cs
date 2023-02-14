
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Chat.Api.Client
{
    public class Conversacion
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Conversacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Consultar(int ConversacionID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = ConversacionID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Consultar(Cosmos.Mensajeria.Chat.Entidades.Conversacion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.Conversacion resultado = new Cosmos.Mensajeria.Chat.Entidades.Conversacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/Conversacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Guardar(int conversacionID, string nombre)
        {
            return Guardar(new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = conversacionID, Nombre = nombre });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Guardar(Cosmos.Mensajeria.Chat.Entidades.Conversacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.Conversacion resultado = new Cosmos.Mensajeria.Chat.Entidades.Conversacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Conversacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int ConversacionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = ConversacionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Chat.Entidades.Conversacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/Conversacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
