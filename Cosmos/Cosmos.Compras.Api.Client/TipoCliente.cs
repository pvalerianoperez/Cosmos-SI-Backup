
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoCliente
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoCliente> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoCliente> listado = new List<Cosmos.Compras.Entidades.TipoCliente>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoCliente/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoCliente>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoCliente Consultar(int tipoClienteID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoCliente Consultar(Cosmos.Compras.Entidades.TipoCliente o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoCliente> listado = new List<Cosmos.Compras.Entidades.TipoCliente>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoCliente resultado = new Cosmos.Compras.Entidades.TipoCliente();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoCliente/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoCliente>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoCliente Guardar(int tipoClienteID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.TipoCliente Guardar(Cosmos.Compras.Entidades.TipoCliente o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoCliente> listado = new List<Cosmos.Compras.Entidades.TipoCliente>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoCliente resultado = new Cosmos.Compras.Entidades.TipoCliente();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoCliente/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoCliente>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoClienteID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoCliente o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoCliente/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
