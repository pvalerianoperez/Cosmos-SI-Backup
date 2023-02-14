using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class MotivoInteres
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoInteres> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoInteres> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoInteres>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoInteres/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoInteres>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Consultar(int MotivoInteresID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoInteres() { MotivoInteresID = MotivoInteresID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Consultar(Cosmos.Academico.Admision.Entidades.MotivoInteres o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoInteres> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoInteres>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoInteres resultado = new Cosmos.Academico.Admision.Entidades.MotivoInteres();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoInteres/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoInteres>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Guardar(int MotivoInteresID, string MotivoInteresClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoInteres() { MotivoInteresID = MotivoInteresID, MotivoInteresClave = MotivoInteresClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Guardar(Cosmos.Academico.Admision.Entidades.MotivoInteres o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.MotivoInteres> listado = new List<Cosmos.Academico.Admision.Entidades.MotivoInteres>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.MotivoInteres resultado = new Cosmos.Academico.Admision.Entidades.MotivoInteres();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoInteres/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.MotivoInteres>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int MotivoInteresID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoInteres() { MotivoInteresID = MotivoInteresID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoInteres o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/MotivoInteres/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
