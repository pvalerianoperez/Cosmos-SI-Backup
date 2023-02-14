
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class PersonalTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalTelefono> listado = new List<Cosmos.Compras.Entidades.PersonalTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Consultar(int personalTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Consultar(Cosmos.Compras.Entidades.PersonalTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalTelefono> listado = new List<Cosmos.Compras.Entidades.PersonalTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalTelefono resultado = new Cosmos.Compras.Entidades.PersonalTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Guardar(int personalTelefonoID, int personalID, int telefonoID, string extension, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID, PersonalID = personalID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.PersonalTelefono Guardar(Cosmos.Compras.Entidades.PersonalTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalTelefono> listado = new List<Cosmos.Compras.Entidades.PersonalTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalTelefono resultado = new Cosmos.Compras.Entidades.PersonalTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personalTelefonoID){
            return Eliminar(new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.PersonalTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
