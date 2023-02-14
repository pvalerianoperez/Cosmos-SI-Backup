
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class FormaPago
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.FormaPago> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FormaPago> listado = new List<Cosmos.Compras.Entidades.FormaPago>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/FormaPago/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FormaPago>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.FormaPago Consultar(int formaPagoID) {
            return Consultar(new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID  });
        }
        
        public static Cosmos.Compras.Entidades.FormaPago Consultar(Cosmos.Compras.Entidades.FormaPago o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FormaPago> listado = new List<Cosmos.Compras.Entidades.FormaPago>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.FormaPago resultado = new Cosmos.Compras.Entidades.FormaPago();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/FormaPago/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FormaPago>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.FormaPago Guardar(int formaPagoID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.FormaPago Guardar(Cosmos.Compras.Entidades.FormaPago o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FormaPago> listado = new List<Cosmos.Compras.Entidades.FormaPago>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.FormaPago resultado = new Cosmos.Compras.Entidades.FormaPago();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/FormaPago/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FormaPago>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int formaPagoID){
            return Eliminar(new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.FormaPago o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/FormaPago/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
