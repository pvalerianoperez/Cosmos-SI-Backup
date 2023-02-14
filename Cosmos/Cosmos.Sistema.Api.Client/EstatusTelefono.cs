
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class EstatusTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTelefono> listado = new List<Cosmos.Sistema.Entidades.EstatusTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Consultar(int estatusTelefonoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Consultar(Cosmos.Sistema.Entidades.EstatusTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTelefono> listado = new List<Cosmos.Sistema.Entidades.EstatusTelefono>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusTelefono resultado = new Cosmos.Sistema.Entidades.EstatusTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Guardar(int estatusTelefonoID, string estatusTelefonoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID, EstatusTelefonoClave = estatusTelefonoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.EstatusTelefono Guardar(Cosmos.Sistema.Entidades.EstatusTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTelefono> listado = new List<Cosmos.Sistema.Entidades.EstatusTelefono>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusTelefono resultado = new Cosmos.Sistema.Entidades.EstatusTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estatusTelefonoID){
            return Eliminar(new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.EstatusTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
