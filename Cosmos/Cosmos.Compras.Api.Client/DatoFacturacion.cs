
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class DatoFacturacion
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.DatoFacturacion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.DatoFacturacion> listado = new List<Cosmos.Compras.Entidades.DatoFacturacion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/DatoFacturacion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Consultar(int datoFacturacionID) {
            return Consultar(new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID  });
        }
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Consultar(Cosmos.Compras.Entidades.DatoFacturacion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.DatoFacturacion> listado = new List<Cosmos.Compras.Entidades.DatoFacturacion>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.DatoFacturacion resultado = new Cosmos.Compras.Entidades.DatoFacturacion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/DatoFacturacion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Guardar(int datoFacturacionID, int personaID, string rFC, int domicilioID){ 
            return Guardar(new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID, PersonaID = personaID, RFC = rFC, DomicilioID = domicilioID });
        }

        public static Cosmos.Compras.Entidades.DatoFacturacion Guardar(Cosmos.Compras.Entidades.DatoFacturacion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.DatoFacturacion> listado = new List<Cosmos.Compras.Entidades.DatoFacturacion>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.DatoFacturacion resultado = new Cosmos.Compras.Entidades.DatoFacturacion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/DatoFacturacion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int datoFacturacionID){
            return Eliminar(new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.DatoFacturacion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/DatoFacturacion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
