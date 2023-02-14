
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class OpcionTipoOpcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/OpcionTipoOpcion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Consultar(int opcionID, int tipoOpcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Consultar(Cosmos.Seguridad.Entidades.OpcionTipoOpcion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.OpcionTipoOpcion resultado = new Cosmos.Seguridad.Entidades.OpcionTipoOpcion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/OpcionTipoOpcion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Guardar(int opcionID, int tipoOpcionID){ 
            return Guardar(new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID });
        }

        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Guardar(Cosmos.Seguridad.Entidades.OpcionTipoOpcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.OpcionTipoOpcion resultado = new Cosmos.Seguridad.Entidades.OpcionTipoOpcion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/OpcionTipoOpcion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int opcionID, int tipoOpcionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.OpcionTipoOpcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/OpcionTipoOpcion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
