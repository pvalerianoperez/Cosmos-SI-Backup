
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class PersonalMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalMail> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalMail> listado = new List<Cosmos.Compras.Entidades.PersonalMail>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalMail/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.PersonalMail Consultar(int personalMailID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalMail Consultar(Cosmos.Compras.Entidades.PersonalMail o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalMail> listado = new List<Cosmos.Compras.Entidades.PersonalMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalMail resultado = new Cosmos.Compras.Entidades.PersonalMail();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalMail/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.PersonalMail Guardar(int personalMailID, int personalID, string email, int tipoMailID, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID, PersonalID = personalID, Email = email, TipoMailID = tipoMailID, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.PersonalMail Guardar(Cosmos.Compras.Entidades.PersonalMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.PersonalMail> listado = new List<Cosmos.Compras.Entidades.PersonalMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.PersonalMail resultado = new Cosmos.Compras.Entidades.PersonalMail();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/PersonalMail/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.PersonalMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personalMailID){
            return Eliminar(new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.PersonalMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/PersonalMail/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
