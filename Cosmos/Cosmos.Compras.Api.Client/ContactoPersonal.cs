
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ContactoPersonal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonal> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonal> listado = new List<Cosmos.Compras.Entidades.ContactoPersonal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Consultar(int contactoPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Consultar(Cosmos.Compras.Entidades.ContactoPersonal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonal> listado = new List<Cosmos.Compras.Entidades.ContactoPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonal resultado = new Cosmos.Compras.Entidades.ContactoPersonal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Guardar(int contactoPersonalID, int personalID, int personaID){ 
            return Guardar(new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID, PersonalID = personalID, PersonaID = personaID });
        }

        public static Cosmos.Compras.Entidades.ContactoPersonal Guardar(Cosmos.Compras.Entidades.ContactoPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonal> listado = new List<Cosmos.Compras.Entidades.ContactoPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonal resultado = new Cosmos.Compras.Entidades.ContactoPersonal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int contactoPersonalID){
            return Eliminar(new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ContactoPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
