using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class MotivoCancelacionServicio
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoCancelacionServicio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Consultar(int MotivoCancelacionServicioID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio() { MotivoCancelacionServicioID = MotivoCancelacionServicioID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Consultar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio resultado = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoCancelacionServicio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Guardar(int MotivoCancelacionServicioID, string MotivoCancelacionServicioClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio() { MotivoCancelacionServicioID = MotivoCancelacionServicioID, MotivoCancelacionServicioClave = MotivoCancelacionServicioClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Guardar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio resultado = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoCancelacionServicio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int MotivoCancelacionServicioID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio() { MotivoCancelacionServicioID = MotivoCancelacionServicioID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoCancelacionServicio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}