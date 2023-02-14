
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class ClaseProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.ClaseProducto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.ClaseProducto> listado = new List<Cosmos.Sistema.Entidades.ClaseProducto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/ClaseProducto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.ClaseProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Consultar(int claseProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Consultar(Cosmos.Sistema.Entidades.ClaseProducto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.ClaseProducto> listado = new List<Cosmos.Sistema.Entidades.ClaseProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.ClaseProducto resultado = new Cosmos.Sistema.Entidades.ClaseProducto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/ClaseProducto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.ClaseProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Guardar(int claseProductoID, string claseProductoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID, ClaseProductoClave = claseProductoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.ClaseProducto Guardar(Cosmos.Sistema.Entidades.ClaseProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.ClaseProducto> listado = new List<Cosmos.Sistema.Entidades.ClaseProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.ClaseProducto resultado = new Cosmos.Sistema.Entidades.ClaseProducto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/ClaseProducto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.ClaseProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int claseProductoID){
            return Eliminar(new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.ClaseProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/ClaseProducto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
