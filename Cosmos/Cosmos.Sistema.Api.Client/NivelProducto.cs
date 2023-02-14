
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class NivelProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.NivelProducto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.NivelProducto> listado = new List<Cosmos.Sistema.Entidades.NivelProducto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/NivelProducto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.NivelProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.NivelProducto Consultar(int nivelProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.NivelProducto Consultar(Cosmos.Sistema.Entidades.NivelProducto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.NivelProducto> listado = new List<Cosmos.Sistema.Entidades.NivelProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.NivelProducto resultado = new Cosmos.Sistema.Entidades.NivelProducto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/NivelProducto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.NivelProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.NivelProducto Guardar(int nivelProductoID, string nivelProductoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID, NivelProductoClave = nivelProductoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.NivelProducto Guardar(Cosmos.Sistema.Entidades.NivelProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.NivelProducto> listado = new List<Cosmos.Sistema.Entidades.NivelProducto>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.NivelProducto resultado = new Cosmos.Sistema.Entidades.NivelProducto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/NivelProducto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.NivelProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int nivelProductoID){
            return Eliminar(new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.NivelProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/NivelProducto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
