using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class Vinculo
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Vinculo> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Vinculo> listado = new List<Cosmos.Academico.Admision.Entidades.Vinculo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Vinculo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Consultar(int VinculoID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Vinculo() { VinculoID = VinculoID });
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Consultar(Cosmos.Academico.Admision.Entidades.Vinculo o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Vinculo> listado = new List<Cosmos.Academico.Admision.Entidades.Vinculo>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Vinculo resultado = new Cosmos.Academico.Admision.Entidades.Vinculo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Vinculo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Guardar(int VinculoID, string VinculoClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Vinculo() { VinculoID = VinculoID, VinculoClave = VinculoClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Guardar(Cosmos.Academico.Admision.Entidades.Vinculo o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Vinculo> listado = new List<Cosmos.Academico.Admision.Entidades.Vinculo>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Vinculo resultado = new Cosmos.Academico.Admision.Entidades.Vinculo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Vinculo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int VinculoID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Vinculo() { VinculoID = VinculoID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Vinculo o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Vinculo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}