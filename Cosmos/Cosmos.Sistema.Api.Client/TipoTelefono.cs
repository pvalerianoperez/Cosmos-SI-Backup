
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class TipoTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoTelefono> listado = new List<Cosmos.Sistema.Entidades.TipoTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Consultar(int tipoTelefonoID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Consultar(Cosmos.Sistema.Entidades.TipoTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoTelefono> listado = new List<Cosmos.Sistema.Entidades.TipoTelefono>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoTelefono resultado = new Cosmos.Sistema.Entidades.TipoTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Guardar(int tipoTelefonoID, string tipoTelefonoClave, string nombre, string nombreCorto, bool estatus){ 
            return Guardar(new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID, TipoTelefonoClave = tipoTelefonoClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus });
        }

        public static Cosmos.Sistema.Entidades.TipoTelefono Guardar(Cosmos.Sistema.Entidades.TipoTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoTelefono> listado = new List<Cosmos.Sistema.Entidades.TipoTelefono>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoTelefono resultado = new Cosmos.Sistema.Entidades.TipoTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoTelefonoID){
            return Eliminar(new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.TipoTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
