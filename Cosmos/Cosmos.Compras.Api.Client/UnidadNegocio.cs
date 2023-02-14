
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class UnidadNegocio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.UnidadNegocio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UnidadNegocio> listado = new List<Cosmos.Compras.Entidades.UnidadNegocio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UnidadNegocio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UnidadNegocio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Consultar(int unidadNegocioID) {
            return Consultar(new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID  });
        }
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Consultar(Cosmos.Compras.Entidades.UnidadNegocio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UnidadNegocio> listado = new List<Cosmos.Compras.Entidades.UnidadNegocio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UnidadNegocio resultado = new Cosmos.Compras.Entidades.UnidadNegocio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UnidadNegocio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UnidadNegocio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Guardar(int unidadNegocioID, string unidadNegocioClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID, UnidadNegocioClave = unidadNegocioClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.UnidadNegocio Guardar(Cosmos.Compras.Entidades.UnidadNegocio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UnidadNegocio> listado = new List<Cosmos.Compras.Entidades.UnidadNegocio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UnidadNegocio resultado = new Cosmos.Compras.Entidades.UnidadNegocio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UnidadNegocio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UnidadNegocio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int unidadNegocioID){
            return Eliminar(new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.UnidadNegocio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UnidadNegocio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
