
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProveedorTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.ProveedorTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Consultar(int proveedorTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Consultar(Cosmos.Compras.Entidades.ProveedorTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.ProveedorTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorTelefono resultado = new Cosmos.Compras.Entidades.ProveedorTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Guardar(int proveedorTelefonoID, int proveedorID, int telefonoID, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID, ProveedorID = proveedorID, TelefonoID = telefonoID, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.ProveedorTelefono Guardar(Cosmos.Compras.Entidades.ProveedorTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.ProveedorTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorTelefono resultado = new Cosmos.Compras.Entidades.ProveedorTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int proveedorTelefonoID){
            return Eliminar(new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProveedorTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
