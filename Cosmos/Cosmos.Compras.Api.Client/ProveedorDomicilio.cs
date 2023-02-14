
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProveedorDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorDomicilio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.ProveedorDomicilio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorDomicilio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProveedorDomicilio Consultar(int proveedorDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorDomicilio Consultar(Cosmos.Compras.Entidades.ProveedorDomicilio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.ProveedorDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorDomicilio resultado = new Cosmos.Compras.Entidades.ProveedorDomicilio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorDomicilio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProveedorDomicilio Guardar(int proveedorDomicilioID, int proveedorID, int domicilioID, string nombre){ 
            return Guardar(new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID, ProveedorID = proveedorID, DomicilioID = domicilioID, Nombre = nombre });
        }

        public static Cosmos.Compras.Entidades.ProveedorDomicilio Guardar(Cosmos.Compras.Entidades.ProveedorDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.ProveedorDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorDomicilio resultado = new Cosmos.Compras.Entidades.ProveedorDomicilio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorDomicilio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int proveedorDomicilioID){
            return Eliminar(new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProveedorDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorDomicilio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
