using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class DeviceToken
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/DeviceToken/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Consultar(int deviceTokenID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken() { DeviceTokenID = deviceTokenID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Consultar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.DeviceToken resultado = new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/DeviceToken/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Guardar(int deviceTokenID, string deviceToken, string os, string versionOS, string versionApp, string descripcion, DateTime fechaRegistro )
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken() { DeviceTokenID = deviceTokenID, Token = deviceToken, OS = os, VersionOS = versionOS, VersionApp = versionApp, Descripcion = descripcion, FechaRegistro = fechaRegistro });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Guardar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.DeviceToken resultado = new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/DeviceToken/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int deviceTokenID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken() { DeviceTokenID = deviceTokenID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/DeviceToken/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
