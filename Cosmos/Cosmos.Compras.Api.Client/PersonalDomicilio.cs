
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class PersonalDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalDomicilio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.PersonalDomicilio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalDomicilio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Consultar(int personalDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Consultar(Cosmos.Compras.Entidades.PersonalDomicilio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.PersonalDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalDomicilio resultado = new Cosmos.Compras.Entidades.PersonalDomicilio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalDomicilio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Guardar(int personalDomicilioID, int personalID, int domicilioID){ 
            return Guardar(new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID, PersonalID = personalID, DomicilioID = domicilioID });
        }

        public static Cosmos.Compras.Entidades.PersonalDomicilio Guardar(Cosmos.Compras.Entidades.PersonalDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalDomicilio> listado = new List<Cosmos.Compras.Entidades.PersonalDomicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalDomicilio resultado = new Cosmos.Compras.Entidades.PersonalDomicilio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalDomicilio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalDomicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personalDomicilioID){
            return Eliminar(new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.PersonalDomicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalDomicilio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
