using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class CanalComunicacion
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/CanalComunicacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Consultar(int canalComunicacionID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion() { CanalComunicacionID = canalComunicacionID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Consultar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion resultado = new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/CanalComunicacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Guardar(int canalComunicacionID, string canalComunicacionClave, string nombre, string nombreCorto, bool activo)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion() { CanalComunicacionID = canalComunicacionID, CanalComunicacionClave = canalComunicacionClave, Nombre = nombre, NombreCorto = nombreCorto, Activo = activo });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Guardar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion resultado = new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/CanalComunicacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int canalComunicacionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion() { CanalComunicacionID = canalComunicacionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/CanalComunicacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
