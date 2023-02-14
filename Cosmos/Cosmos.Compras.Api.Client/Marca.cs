
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Marca
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Marca> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Marca> listado = new List<Cosmos.Compras.Entidades.Marca>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Marca/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Marca>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Marca Consultar(int marcaID) {
            return Consultar(new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID  });
        }
        
        public static Cosmos.Compras.Entidades.Marca Consultar(Cosmos.Compras.Entidades.Marca o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Marca> listado = new List<Cosmos.Compras.Entidades.Marca>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Marca resultado = new Cosmos.Compras.Entidades.Marca();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Marca/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Marca>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Marca Guardar(int marcaID, string marcaClave, string nombre, string nombreCorto, string estatus){ 
            return Guardar(new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID, MarcaClave = marcaClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus });
        }

        public static Cosmos.Compras.Entidades.Marca Guardar(Cosmos.Compras.Entidades.Marca o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Marca> listado = new List<Cosmos.Compras.Entidades.Marca>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Marca resultado = new Cosmos.Compras.Entidades.Marca();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Marca/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Marca>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int marcaID){
            return Eliminar(new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Marca o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Marca/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
