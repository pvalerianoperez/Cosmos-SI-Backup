
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ContactoPersonalMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalMail> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalMail> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalMail>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalMail/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Consultar(int contactoPersonalMailID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Consultar(Cosmos.Compras.Entidades.ContactoPersonalMail o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalMail> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalMail resultado = new Cosmos.Compras.Entidades.ContactoPersonalMail();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalMail/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Guardar(int contactoPersonalMailID, int contactoPersonalID, string email, int tipoMail, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID, ContactoPersonalID = contactoPersonalID, Email = email, TipoMail = tipoMail, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.ContactoPersonalMail Guardar(Cosmos.Compras.Entidades.ContactoPersonalMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalMail> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalMail resultado = new Cosmos.Compras.Entidades.ContactoPersonalMail();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalMail/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int contactoPersonalMailID){
            return Eliminar(new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ContactoPersonalMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalMail/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
