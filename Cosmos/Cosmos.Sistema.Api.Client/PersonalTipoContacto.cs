
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class PersonalTipoContacto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.PersonalTipoContacto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.PersonalTipoContacto> listado = new List<Cosmos.Sistema.Entidades.PersonalTipoContacto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/PersonalTipoContacto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.PersonalTipoContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Consultar(int personalTipoContactoID) {
            return Consultar(new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID  });
        }
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Consultar(Cosmos.Sistema.Entidades.PersonalTipoContacto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.PersonalTipoContacto> listado = new List<Cosmos.Sistema.Entidades.PersonalTipoContacto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.PersonalTipoContacto resultado = new Cosmos.Sistema.Entidades.PersonalTipoContacto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/PersonalTipoContacto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.PersonalTipoContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Guardar(int personalTipoContactoID, string nombre, string nombreCorto, bool conyuge){ 
            return Guardar(new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID, Nombre = nombre, NombreCorto = nombreCorto, Conyuge = conyuge });
        }

        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Guardar(Cosmos.Sistema.Entidades.PersonalTipoContacto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.PersonalTipoContacto> listado = new List<Cosmos.Sistema.Entidades.PersonalTipoContacto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.PersonalTipoContacto resultado = new Cosmos.Sistema.Entidades.PersonalTipoContacto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/PersonalTipoContacto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.PersonalTipoContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personalTipoContactoID){
            return Eliminar(new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.PersonalTipoContacto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/PersonalTipoContacto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
