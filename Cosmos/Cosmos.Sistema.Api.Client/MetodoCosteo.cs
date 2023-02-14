
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class MetodoCosteo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.MetodoCosteo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.MetodoCosteo> listado = new List<Cosmos.Sistema.Entidades.MetodoCosteo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/MetodoCosteo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.MetodoCosteo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Consultar(int metodoCosteoID) {
            return Consultar(new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID  });
        }
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Consultar(Cosmos.Sistema.Entidades.MetodoCosteo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.MetodoCosteo> listado = new List<Cosmos.Sistema.Entidades.MetodoCosteo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.MetodoCosteo resultado = new Cosmos.Sistema.Entidades.MetodoCosteo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/MetodoCosteo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.MetodoCosteo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Guardar(int metodoCosteoID, string metodoCosteoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID, MetodoCosteoClave = metodoCosteoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.MetodoCosteo Guardar(Cosmos.Sistema.Entidades.MetodoCosteo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.MetodoCosteo> listado = new List<Cosmos.Sistema.Entidades.MetodoCosteo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.MetodoCosteo resultado = new Cosmos.Sistema.Entidades.MetodoCosteo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/MetodoCosteo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.MetodoCosteo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int metodoCosteoID){
            return Eliminar(new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.MetodoCosteo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/MetodoCosteo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
