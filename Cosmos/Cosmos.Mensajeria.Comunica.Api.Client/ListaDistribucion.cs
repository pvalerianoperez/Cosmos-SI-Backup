using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;

namespace Cosmos.Mensajeria.Comunica.Api.Client
{
    public class ListaDistribucion
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/ListaDistribucion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Consultar(int listaDistribucionID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion() { ListaDistribucionID = listaDistribucionID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Consultar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion resultado = new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/ListaDistribucion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Guardar(int listaDistribucionID, string listaDistribucionClave, string nombre, string nombreCorto, string versionApp, bool activa)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion() { ListaDistribucionID = listaDistribucionID, ListaDistribucionClave = listaDistribucionClave, Nombre = nombre, NombreCorto = nombreCorto, Activa = activa });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Guardar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> listado = new List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>();

            //resultado del metodo 
            Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion resultado = new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Mensajeria/ListaDistribucion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int listaDistribucionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion() { ListaDistribucionID = listaDistribucionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Mensajeria/ListaDistribucion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
