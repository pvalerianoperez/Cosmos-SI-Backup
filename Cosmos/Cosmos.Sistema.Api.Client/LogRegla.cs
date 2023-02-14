using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Sistema.Api.Client
{
    public  class LogRegla
    {

        #region CRUD

        public static List<Cosmos.Sistema.Entidades.LogRegla> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.LogRegla> listado = new List<Cosmos.Sistema.Entidades.LogRegla>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/LogRegla/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.LogRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Sistema.Entidades.LogRegla Consultar(int sistemaLogReglaID)
        {
            return Consultar(new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID });
        }

        public static Cosmos.Sistema.Entidades.LogRegla Consultar(Cosmos.Sistema.Entidades.LogRegla o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.LogRegla> listado = new List<Cosmos.Sistema.Entidades.LogRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.LogRegla resultado = new Cosmos.Sistema.Entidades.LogRegla();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/LogRegla/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.LogRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Sistema.Entidades.LogRegla Guardar(int sistemaLogReglaID, int userID, string tablanombre, Boolean c, Boolean r, Boolean u, Boolean d)
        {
            return Guardar(new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID, UserID = userID, TablaNombre = tablanombre, C = c, R = r, U = u, D = d });
        }

        public static Cosmos.Sistema.Entidades.LogRegla Guardar(Cosmos.Sistema.Entidades.LogRegla o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.LogRegla> listado = new List<Cosmos.Sistema.Entidades.LogRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.LogRegla resultado = new Cosmos.Sistema.Entidades.LogRegla();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/LogRegla/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.LogRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int sistemaLogReglaID)
        {
            return Eliminar(new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.LogRegla o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/LogRegla/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

    }
}
