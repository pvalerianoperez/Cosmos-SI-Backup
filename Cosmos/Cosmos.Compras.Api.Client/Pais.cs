
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Pais
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Pais> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Pais> listado = new List<Cosmos.Compras.Entidades.Pais>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Pais/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Pais>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Pais Consultar(int paisID) {
            return Consultar(new Cosmos.Compras.Entidades.Pais() { PaisID = paisID  });
        }
        
        public static Cosmos.Compras.Entidades.Pais Consultar(Cosmos.Compras.Entidades.Pais o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Pais> listado = new List<Cosmos.Compras.Entidades.Pais>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Pais resultado = new Cosmos.Compras.Entidades.Pais();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Pais/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Pais>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Pais Guardar(int paisID, string paisClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Pais() { PaisID = paisID, PaisClave = paisClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Pais Guardar(Cosmos.Compras.Entidades.Pais o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Pais> listado = new List<Cosmos.Compras.Entidades.Pais>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Pais resultado = new Cosmos.Compras.Entidades.Pais();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Pais/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Pais>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int paisID){
            return Eliminar(new Cosmos.Compras.Entidades.Pais() { PaisID = paisID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Pais o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Pais/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
