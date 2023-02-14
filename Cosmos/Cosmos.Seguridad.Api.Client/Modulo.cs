
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Modulo
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Modulo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Modulo> listado = new List<Cosmos.Seguridad.Entidades.Modulo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Modulo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Modulo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Modulo Consultar(int moduloID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Modulo Consultar(Cosmos.Seguridad.Entidades.Modulo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Modulo> listado = new List<Cosmos.Seguridad.Entidades.Modulo>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Modulo resultado = new Cosmos.Seguridad.Entidades.Modulo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Modulo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Modulo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Modulo Guardar(int moduloID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.Modulo Guardar(Cosmos.Seguridad.Entidades.Modulo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Modulo> listado = new List<Cosmos.Seguridad.Entidades.Modulo>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Modulo resultado = new Cosmos.Seguridad.Entidades.Modulo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Modulo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Modulo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int moduloID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Modulo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Modulo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
