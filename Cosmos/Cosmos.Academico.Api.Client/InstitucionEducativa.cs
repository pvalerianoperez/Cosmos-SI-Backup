using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Api.Client
{
    public class InstitucionEducativa
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.InstitucionEducativa> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.InstitucionEducativa> listado = new List<Cosmos.Academico.Entidades.InstitucionEducativa>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/InstitucionEducativa/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.InstitucionEducativa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Consultar(int institucionEducativaID)
        {
            return Consultar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = institucionEducativaID });
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Consultar(Cosmos.Academico.Entidades.InstitucionEducativa o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.InstitucionEducativa> listado = new List<Cosmos.Academico.Entidades.InstitucionEducativa>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.InstitucionEducativa resultado = new Cosmos.Academico.Entidades.InstitucionEducativa();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/InstitucionEducativa/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.InstitucionEducativa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Guardar(int institucionEducativaID, string institucionEducativaClave, string nombre, string nombreCorto)
        {
            return Guardar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = institucionEducativaID, InstitucionEducativaClave = institucionEducativaClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Guardar(Cosmos.Academico.Entidades.InstitucionEducativa o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.InstitucionEducativa> listado = new List<Cosmos.Academico.Entidades.InstitucionEducativa>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.InstitucionEducativa resultado = new Cosmos.Academico.Entidades.InstitucionEducativa();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/InstitucionEducativa/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.InstitucionEducativa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int institucionEducativaID)
        {
            return Eliminar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = institucionEducativaID });
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.InstitucionEducativa o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/InstitucionEducativa/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
