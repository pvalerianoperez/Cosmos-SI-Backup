
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Idioma
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Idioma> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Idioma> listado = new List<Cosmos.Compras.Entidades.Idioma>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Idioma/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Idioma>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Idioma Consultar(int idiomaID) {
            return Consultar(new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID  });
        }
        
        public static Cosmos.Compras.Entidades.Idioma Consultar(Cosmos.Compras.Entidades.Idioma o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Idioma> listado = new List<Cosmos.Compras.Entidades.Idioma>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Idioma resultado = new Cosmos.Compras.Entidades.Idioma();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Idioma/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Idioma>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Idioma Guardar(int idiomaID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Idioma Guardar(Cosmos.Compras.Entidades.Idioma o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Idioma> listado = new List<Cosmos.Compras.Entidades.Idioma>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Idioma resultado = new Cosmos.Compras.Entidades.Idioma();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Idioma/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Idioma>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int idiomaID){
            return Eliminar(new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Idioma o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Idioma/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
