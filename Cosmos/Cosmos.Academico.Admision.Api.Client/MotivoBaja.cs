using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class MotivoBaja
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoBaja> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoBaja> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoBaja>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoBaja/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoBaja>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Consultar(int MotivoBajaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoBaja() { MotivoBajaID = MotivoBajaID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Consultar(Cosmos.Academico.Admision.Entidades.MotivoBaja o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoBaja> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoBaja>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoBaja resultado = new Cosmos.Academico.Admision.Entidades.MotivoBaja();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoBaja/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoBaja>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Guardar(int MotivoBajaID, string MotivoBajaClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoBaja() { MotivoBajaID = MotivoBajaID, MotivoBajaClave = MotivoBajaClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Guardar(Cosmos.Academico.Admision.Entidades.MotivoBaja o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoBaja> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoBaja>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoBaja resultado = new Cosmos.Academico.Admision.Entidades.MotivoBaja();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoBaja/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoBaja>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int MotivoBajaID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoBaja() { MotivoBajaID = MotivoBajaID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoBaja o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoBaja/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
