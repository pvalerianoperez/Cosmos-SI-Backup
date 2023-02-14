
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Estado
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Estado> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Estado> listado = new List<Cosmos.Compras.Entidades.Estado>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Estado/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Estado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Estado Consultar(int estadoID) {
            return Consultar(new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID  });
        }
        
        public static Cosmos.Compras.Entidades.Estado Consultar(Cosmos.Compras.Entidades.Estado o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Estado> listado = new List<Cosmos.Compras.Entidades.Estado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Estado resultado = new Cosmos.Compras.Entidades.Estado();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Estado/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Estado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Estado Guardar(int estadoID, string estadoClave, string nombre, string nombreCorto, int paisID){ 
            return Guardar(new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID, EstadoClave = estadoClave, Nombre = nombre, NombreCorto = nombreCorto, PaisID = paisID });
        }

        public static Cosmos.Compras.Entidades.Estado Guardar(Cosmos.Compras.Entidades.Estado o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Estado> listado = new List<Cosmos.Compras.Entidades.Estado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Estado resultado = new Cosmos.Compras.Entidades.Estado();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Estado/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Estado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estadoID){
            return Eliminar(new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Estado o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Estado/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
