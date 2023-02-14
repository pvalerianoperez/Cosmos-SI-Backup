
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Telefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Telefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Telefono> listado = new List<Cosmos.Compras.Entidades.Telefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Telefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Telefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Telefono Consultar(int telefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.Telefono Consultar(Cosmos.Compras.Entidades.Telefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Telefono> listado = new List<Cosmos.Compras.Entidades.Telefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Telefono resultado = new Cosmos.Compras.Entidades.Telefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Telefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Telefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Telefono Guardar(int telefonoID, string ladaPais, string numeroTelefonico, int tipoTelefonoID){ 
            return Guardar(new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID, LadaPais = ladaPais, NumeroTelefonico = numeroTelefonico, TipoTelefonoID = tipoTelefonoID });
        }

        public static Cosmos.Compras.Entidades.Telefono Guardar(Cosmos.Compras.Entidades.Telefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Telefono> listado = new List<Cosmos.Compras.Entidades.Telefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Telefono resultado = new Cosmos.Compras.Entidades.Telefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Telefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Telefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int telefonoID){
            return Eliminar(new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Telefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Telefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
