
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RepresentanteProveedorTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorTelefono/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Consultar(int representanteProveedorTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorTelefono resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorTelefono/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Guardar(int representanteProveedorTelefonoID, int representanteProveedorID, int telefonoID, string extension, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID, RepresentanteProveedorID = representanteProveedorID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Guardar(Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorTelefono resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorTelefono/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int representanteProveedorTelefonoID){
            return Eliminar(new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorTelefono/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
