using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Chat.Api.Client
{
    public class PermisoConversacion
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/PermisoConversacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion Consultar(int permisoConversacionID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion() { PermisoConversacionID = permisoConversacionID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion Consultar(Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion resultado = new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/PermisoConversacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion Guardar(int permisoConversacionID, string permisoConversacionNombre)
        {
            return Guardar(new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion() { PermisoConversacionID = permisoConversacionID, PermisoConversacionNombre = permisoConversacionNombre });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion Guardar(Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion> listado = new List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion resultado = new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/PermisoConversacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int permisoConversacionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion() { PermisoConversacionID = permisoConversacionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/PermisoConversacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
