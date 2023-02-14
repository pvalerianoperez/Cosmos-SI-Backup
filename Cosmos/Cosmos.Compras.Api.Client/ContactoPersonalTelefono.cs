
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ContactoPersonalTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Consultar(int contactoPersonalTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Consultar(Cosmos.Compras.Entidades.ContactoPersonalTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalTelefono resultado = new Cosmos.Compras.Entidades.ContactoPersonalTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Guardar(int contactoPersonalTelefonoID, int contactoPersonalID, int telefonoID, string extension, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID, ContactoPersonalID = contactoPersonalID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Guardar(Cosmos.Compras.Entidades.ContactoPersonalTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> listado = new List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ContactoPersonalTelefono resultado = new Cosmos.Compras.Entidades.ContactoPersonalTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int contactoPersonalTelefonoID){
            return Eliminar(new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ContactoPersonalTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ContactoPersonalTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
