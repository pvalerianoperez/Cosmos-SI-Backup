
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class TipoOpcion
    {

        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.TipoOpcion> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.TipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.TipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Consultar(int tipoOpcionID)
        {
            return Consultar(new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID });
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Consultar(Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.TipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.TipoOpcion resultado = new Cosmos.Seguridad.Entidades.TipoOpcion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.TipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Guardar(int tipoOpcionID, string nombre, string nombreCorto)
        {
            return Guardar(new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Guardar(Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.TipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.TipoOpcion resultado = new Cosmos.Seguridad.Entidades.TipoOpcion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.TipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int tipoOpcionID)
        {
            return Eliminar(new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static bool AccionGuardar(int tipoOpcionID, int accionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.TipoOpcionAccion() { TipoOpcionID = tipoOpcionID, AccionID= accionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/AccionGuardar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static bool AccionEliminar(int tipoOpcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.TipoOpcionAccion() { TipoOpcionID = tipoOpcionID};

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/AccionEliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static List<Cosmos.Seguridad.Entidades.Accion> AccionListado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/TipoOpcion/AccionListado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
