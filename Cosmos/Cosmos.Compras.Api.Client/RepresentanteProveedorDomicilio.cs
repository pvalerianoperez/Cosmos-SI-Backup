
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RepresentanteProveedorDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorDomicilio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Consultar(int representanteProveedorDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorDomicilio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Guardar(int representanteProveedorDomicilioID, int representanteProveedorID, int domicilioID, string nombre){ 
            return Guardar(new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID, RepresentanteProveedorID = representanteProveedorID, DomicilioID = domicilioID, Nombre = nombre });
        }

        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Guardar(Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorDomicilio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int representanteProveedorDomicilioID){
            return Eliminar(new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorDomicilio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
