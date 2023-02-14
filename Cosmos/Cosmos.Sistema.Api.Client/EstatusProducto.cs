
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class EstatusProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusProducto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusProducto> listado = new List<Cosmos.Sistema.Entidades.EstatusProducto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusProducto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Consultar(int estatusProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Consultar(Cosmos.Sistema.Entidades.EstatusProducto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusProducto> listado = new List<Cosmos.Sistema.Entidades.EstatusProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusProducto resultado = new Cosmos.Sistema.Entidades.EstatusProducto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusProducto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Guardar(int estatusProductoID, string estatusProductoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID, EstatusProductoClave = estatusProductoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.EstatusProducto Guardar(Cosmos.Sistema.Entidades.EstatusProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusProducto> listado = new List<Cosmos.Sistema.Entidades.EstatusProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusProducto resultado = new Cosmos.Sistema.Entidades.EstatusProducto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusProducto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estatusProductoID){
            return Eliminar(new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.EstatusProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusProducto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
