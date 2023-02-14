
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class PerfilOpcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcion Consultar(int perfilID, int opcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcion Consultar(Cosmos.Seguridad.Entidades.PerfilOpcion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.PerfilOpcion resultado = new Cosmos.Seguridad.Entidades.PerfilOpcion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcion Guardar(int perfilID, int opcionID){ 
            return Guardar(new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID });
        }

        public static Cosmos.Seguridad.Entidades.PerfilOpcion Guardar(Cosmos.Seguridad.Entidades.PerfilOpcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.PerfilOpcion resultado = new Cosmos.Seguridad.Entidades.PerfilOpcion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int perfilID, int opcionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.PerfilOpcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
