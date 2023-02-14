
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class TipoMail
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoMail> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoMail> listado = new List<Cosmos.Sistema.Entidades.TipoMail>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoMail/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoMail>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.TipoMail Consultar(int tipoMailID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoMail Consultar(Cosmos.Sistema.Entidades.TipoMail o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoMail> listado = new List<Cosmos.Sistema.Entidades.TipoMail>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoMail resultado = new Cosmos.Sistema.Entidades.TipoMail();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoMail/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.TipoMail Guardar(int tipoMailID, string tipoMailClave, string nombre, string nombreCorto, bool estatus){ 
            return Guardar(new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID, TipoMailClave = tipoMailClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus });
        }

        public static Cosmos.Sistema.Entidades.TipoMail Guardar(Cosmos.Sistema.Entidades.TipoMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoMail> listado = new List<Cosmos.Sistema.Entidades.TipoMail>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoMail resultado = new Cosmos.Sistema.Entidades.TipoMail();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoMail/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoMailID){
            return Eliminar(new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.TipoMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoMail/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
