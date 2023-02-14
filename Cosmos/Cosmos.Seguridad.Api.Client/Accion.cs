
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Accion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Accion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Accion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Accion Consultar(int accionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Accion Consultar(Cosmos.Seguridad.Entidades.Accion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Accion resultado = new Cosmos.Seguridad.Entidades.Accion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Accion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Accion Guardar(int accionID, string accionClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID, AccionClave = accionClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.Accion Guardar(Cosmos.Seguridad.Entidades.Accion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Accion resultado = new Cosmos.Seguridad.Entidades.Accion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Accion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int accionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Accion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Accion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static List<Cosmos.Seguridad.Entidades.Accion> ListadoTipoOpcionID(int tipoOpcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Accion/ListadoTipoOpcionID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Seguridad.Entidades.Accion> ListadoOpcionID(int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Accion> listado = new List<Cosmos.Seguridad.Entidades.Accion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Accion/ListadoOpcionID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Accion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }

   
}
