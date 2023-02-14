
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class PerfilOpcionAccion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Consultar(int perfilID, int opcionID, int accionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Consultar(Cosmos.Seguridad.Entidades.PerfilOpcionAccion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.PerfilOpcionAccion resultado = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Guardar(int perfilID, int opcionID, int accionID){ 
            return Guardar(new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID });
        }

        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Guardar(Cosmos.Seguridad.Entidades.PerfilOpcionAccion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.PerfilOpcionAccion resultado = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int perfilID, int opcionID, int accionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.PerfilOpcionAccion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static bool EliminarPerfilOpcion(int perfilID, int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/EliminarPerfilOpcion", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> ListadoPerfilIDOpcionID(int perfilID, int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/PerfilOpcionAccion/ListadoPerfilIDOpcionID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
