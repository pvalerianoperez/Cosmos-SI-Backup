using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class TipoObservacion
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.TipoObservacion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoObservacion> listado = new List<Cosmos.Academico.Admision.Entidades.TipoObservacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoObservacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoObservacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Consultar(int TipoObservacionID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.TipoObservacion() { TipoObservacionID = TipoObservacionID });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Consultar(Cosmos.Academico.Admision.Entidades.TipoObservacion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoObservacion> listado = new List<Cosmos.Academico.Admision.Entidades.TipoObservacion>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.TipoObservacion resultado = new Cosmos.Academico.Admision.Entidades.TipoObservacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoObservacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoObservacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Guardar(int TipoObservacionID, string TipoObservacionClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.TipoObservacion() { TipoObservacionID = TipoObservacionID, TipoObservacionClave = TipoObservacionClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Guardar(Cosmos.Academico.Admision.Entidades.TipoObservacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoObservacion> listado = new List<Cosmos.Academico.Admision.Entidades.TipoObservacion>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.TipoObservacion resultado = new Cosmos.Academico.Admision.Entidades.TipoObservacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoObservacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoObservacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int TipoObservacionID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.TipoObservacion() { TipoObservacionID = TipoObservacionID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.TipoObservacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoObservacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}