
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Zona
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Zona> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Zona> listado = new List<Cosmos.Compras.Entidades.Zona>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Zona/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Zona>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Zona Consultar(int zonaID) {
            return Consultar(new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID  });
        }
        
        public static Cosmos.Compras.Entidades.Zona Consultar(Cosmos.Compras.Entidades.Zona o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Zona> listado = new List<Cosmos.Compras.Entidades.Zona>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Zona resultado = new Cosmos.Compras.Entidades.Zona();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Zona/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Zona>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Zona Guardar(int zonaID, string zonaClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID, ZonaClave = zonaClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Zona Guardar(Cosmos.Compras.Entidades.Zona o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Zona> listado = new List<Cosmos.Compras.Entidades.Zona>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Zona resultado = new Cosmos.Compras.Entidades.Zona();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Zona/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Zona>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int zonaID){
            return Eliminar(new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Zona o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Zona/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
