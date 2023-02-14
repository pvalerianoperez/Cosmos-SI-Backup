using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class Escolaridad
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Escolaridad> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Escolaridad> listado = new List<Cosmos.Academico.Admision.Entidades.Escolaridad>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Escolaridad/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Escolaridad>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Consultar(int EscolaridadID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Escolaridad() { EscolaridadID = EscolaridadID });
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Consultar(Cosmos.Academico.Admision.Entidades.Escolaridad o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Escolaridad> listado = new List<Cosmos.Academico.Admision.Entidades.Escolaridad>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Escolaridad resultado = new Cosmos.Academico.Admision.Entidades.Escolaridad();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Escolaridad/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Escolaridad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Guardar(int EscolaridadID, string EscolaridadClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Escolaridad() { EscolaridadID = EscolaridadID, EscolaridadClave = EscolaridadClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Guardar(Cosmos.Academico.Admision.Entidades.Escolaridad o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Escolaridad> listado = new List<Cosmos.Academico.Admision.Entidades.Escolaridad>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Escolaridad resultado = new Cosmos.Academico.Admision.Entidades.Escolaridad();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Escolaridad/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Escolaridad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int EscolaridadID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Escolaridad() { EscolaridadID = EscolaridadID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Escolaridad o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Escolaridad/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
