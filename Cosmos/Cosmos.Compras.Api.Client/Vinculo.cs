
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Vinculo
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Vinculo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Vinculo> listado = new List<Cosmos.Compras.Entidades.Vinculo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Vinculo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Vinculo Consultar(int vinculoID) {
            return Consultar(new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID  });
        }
        
        public static Cosmos.Compras.Entidades.Vinculo Consultar(Cosmos.Compras.Entidades.Vinculo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Vinculo> listado = new List<Cosmos.Compras.Entidades.Vinculo>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Vinculo resultado = new Cosmos.Compras.Entidades.Vinculo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Vinculo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Vinculo Guardar(int vinculoID, string vinculoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID, VinculoClave = vinculoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Vinculo Guardar(Cosmos.Compras.Entidades.Vinculo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Vinculo> listado = new List<Cosmos.Compras.Entidades.Vinculo>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Vinculo resultado = new Cosmos.Compras.Entidades.Vinculo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Vinculo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Vinculo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int vinculoID){
            return Eliminar(new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Vinculo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Vinculo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
