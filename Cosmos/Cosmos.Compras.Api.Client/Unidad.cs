
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Unidad
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Unidad> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Unidad> listado = new List<Cosmos.Compras.Entidades.Unidad>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Unidad/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Unidad>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Unidad Consultar(int unidadID) {
            return Consultar(new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID  });
        }
        
        public static Cosmos.Compras.Entidades.Unidad Consultar(Cosmos.Compras.Entidades.Unidad o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Unidad> listado = new List<Cosmos.Compras.Entidades.Unidad>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Unidad resultado = new Cosmos.Compras.Entidades.Unidad();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Unidad/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Unidad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Unidad Guardar(int unidadID, string unidadClave, string nombre, string nombreCorto, string estatus){ 
            return Guardar(new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID, UnidadClave = unidadClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus });
        }

        public static Cosmos.Compras.Entidades.Unidad Guardar(Cosmos.Compras.Entidades.Unidad o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Unidad> listado = new List<Cosmos.Compras.Entidades.Unidad>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Unidad resultado = new Cosmos.Compras.Entidades.Unidad();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Unidad/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Unidad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int unidadID){
            return Eliminar(new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Unidad o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Unidad/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
