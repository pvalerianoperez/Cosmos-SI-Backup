using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class RazonNoViable
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.RazonNoViable> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.RazonNoViable> listado = new List<Cosmos.Academico.Admision.Entidades.RazonNoViable>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/RazonNoViable/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.RazonNoViable>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Consultar(int RazonNoViableID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.RazonNoViable() { RazonNoViableID = RazonNoViableID });
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Consultar(Cosmos.Academico.Admision.Entidades.RazonNoViable o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.RazonNoViable> listado = new List<Cosmos.Academico.Admision.Entidades.RazonNoViable>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.RazonNoViable resultado = new Cosmos.Academico.Admision.Entidades.RazonNoViable();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/RazonNoViable/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.RazonNoViable>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Guardar(int RazonNoViableID, string RazonNoViableClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.RazonNoViable() { RazonNoViableID = RazonNoViableID, RazonNoViableClave = RazonNoViableClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Guardar(Cosmos.Academico.Admision.Entidades.RazonNoViable o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.RazonNoViable> listado = new List<Cosmos.Academico.Admision.Entidades.RazonNoViable>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.RazonNoViable resultado = new Cosmos.Academico.Admision.Entidades.RazonNoViable();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/RazonNoViable/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.RazonNoViable>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int RazonNoViableID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.RazonNoViable() { RazonNoViableID = RazonNoViableID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.RazonNoViable o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/RazonNoViable/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}