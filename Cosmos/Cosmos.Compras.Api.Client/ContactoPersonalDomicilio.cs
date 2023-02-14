
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ContactoPersonalDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalDomicilio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Consultar(int contactoPersonalDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Consultar(Cosmos.Compras.Entidades.ContactoPersonalDomicilio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalDomicilio resultado = new Cosmos.Compras.Entidades.ContactoPersonalDomicilio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalDomicilio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Guardar(int contactoPersonalDomicilioID, int contactoPersonalID, int domicilioID){ 
            return Guardar(new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID, ContactoPersonalID = contactoPersonalID, DomicilioID = domicilioID });
        }

        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Guardar(Cosmos.Compras.Entidades.ContactoPersonalDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalDomicilio resultado = new Cosmos.Compras.Entidades.ContactoPersonalDomicilio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalDomicilio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int contactoPersonalDomicilioID){
            return Eliminar(new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ContactoPersonalDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalDomicilio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
