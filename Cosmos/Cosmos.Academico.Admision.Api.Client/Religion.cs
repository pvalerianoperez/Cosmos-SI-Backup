using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class Religion
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Religion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Religion> listado = new List<Cosmos.Academico.Admision.Entidades.Religion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Religion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Religion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Consultar(int ReligionID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Religion() { ReligionID = ReligionID });
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Consultar(Cosmos.Academico.Admision.Entidades.Religion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Religion> listado = new List<Cosmos.Academico.Admision.Entidades.Religion>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Religion resultado = new Cosmos.Academico.Admision.Entidades.Religion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Religion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Religion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Guardar(int ReligionID, string ReligionClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Religion() { ReligionID = ReligionID, ReligionClave = ReligionClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Guardar(Cosmos.Academico.Admision.Entidades.Religion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Religion> listado = new List<Cosmos.Academico.Admision.Entidades.Religion>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Religion resultado = new Cosmos.Academico.Admision.Entidades.Religion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Religion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Religion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int ReligionID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Religion() { ReligionID = ReligionID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Religion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Religion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}