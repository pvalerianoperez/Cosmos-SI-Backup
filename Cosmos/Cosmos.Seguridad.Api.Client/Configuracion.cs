
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Configuracion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Configuracion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Configuracion> listado = new List<Cosmos.Seguridad.Entidades.Configuracion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Configuracion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Configuracion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Configuracion Consultar(int configuracionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Configuracion Consultar(Cosmos.Seguridad.Entidades.Configuracion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Configuracion> listado = new List<Cosmos.Seguridad.Entidades.Configuracion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Configuracion resultado = new Cosmos.Seguridad.Entidades.Configuracion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Configuracion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Configuracion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Configuracion Guardar(int configuracionID, string nombre, int maximoIntentosLogin, bool activa){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID, Nombre = nombre, MaximoIntentosLogin = maximoIntentosLogin, Activa = activa });
        }

        public static Cosmos.Seguridad.Entidades.Configuracion Guardar(Cosmos.Seguridad.Entidades.Configuracion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Configuracion> listado = new List<Cosmos.Seguridad.Entidades.Configuracion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Configuracion resultado = new Cosmos.Seguridad.Entidades.Configuracion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Configuracion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Configuracion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int configuracionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Configuracion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Configuracion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
