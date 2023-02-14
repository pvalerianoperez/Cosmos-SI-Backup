
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Chat.Api.Client
{
    public class Mensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Consultar(int MensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = MensajeID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Consultar(Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.Mensaje resultado = new Cosmos.Mensajeria.Chat.Entidades.Mensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Guardar(int mensajeID, int usuarioID, int conversacionID, int tipoMensajeID, string mensaje)
        {
            return Guardar(new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = mensajeID, UsuarioID = usuarioID, ConversacionID = conversacionID, TipoMensajeID = tipoMensajeID, ContentMensaje = mensaje });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Guardar(Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.Mensaje resultado = new Cosmos.Mensajeria.Chat.Entidades.Mensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int MensajeID)
        {
            return Eliminar(new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = MensajeID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
