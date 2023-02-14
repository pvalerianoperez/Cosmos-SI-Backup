using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class Mensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Consultar(int mensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje() { MensajeID = mensajeID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Consultar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.Mensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.Mensaje();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Guardar(int mensajeID, 
            int canalComunicacionID, 
            int tipoMensajeID, 
            int remitenteID, 
            int destinatarioID, 
            DateTime fechaProgramadaEnvio, 
            string tema,
            string mensaje, 
            bool requiereAcuse)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje() { MensajeID = mensajeID,
                CanalComunicacionID = canalComunicacionID,
                TipoMensajeID = tipoMensajeID,
                RemitenteID = remitenteID,
                DestinatarioID = destinatarioID,
                FechaProgramadaEnvio = fechaProgramadaEnvio,
                Tema = tema,
                Body = mensaje,
                RequiereAcuse = requiereAcuse
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Guardar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.Mensaje resultado = new Cosmos.Mensajeria.Comunica.Entidades.Mensaje();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/Mensaje/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int mensajeID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje() { MensajeID = mensajeID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
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
