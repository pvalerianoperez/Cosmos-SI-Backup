
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Academico.Api.Client
{
    public class AreaFormacion
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.AreaFormacion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.AreaFormacion> listado = new List<Cosmos.Academico.Entidades.AreaFormacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/AreaFormacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.AreaFormacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Consultar(int AreaFormacionID)
        {
            return Consultar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID });
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Consultar(Cosmos.Academico.Entidades.AreaFormacion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.AreaFormacion> listado = new List<Cosmos.Academico.Entidades.AreaFormacion>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.AreaFormacion resultado = new Cosmos.Academico.Entidades.AreaFormacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/AreaFormacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.AreaFormacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Guardar(int AreaFormacionID, string AreaFormacionClave, string nombre, string nombreCorto)
        {
            return Guardar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID, AreaFormacionClave = AreaFormacionClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Guardar(Cosmos.Academico.Entidades.AreaFormacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.AreaFormacion> listado = new List<Cosmos.Academico.Entidades.AreaFormacion>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.AreaFormacion resultado = new Cosmos.Academico.Entidades.AreaFormacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/AreaFormacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.AreaFormacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int AreaFormacionID)
        {
            return Eliminar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID });
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.AreaFormacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/AreaFormacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
