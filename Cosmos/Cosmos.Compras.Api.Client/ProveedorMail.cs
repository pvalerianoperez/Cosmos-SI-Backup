
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProveedorMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorMail> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorMail> listado = new List<Cosmos.Compras.Entidades.ProveedorMail>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorMail/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProveedorMail Consultar(int proveedorMailID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorMail Consultar(Cosmos.Compras.Entidades.ProveedorMail o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorMail> listado = new List<Cosmos.Compras.Entidades.ProveedorMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorMail resultado = new Cosmos.Compras.Entidades.ProveedorMail();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorMail/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProveedorMail Guardar(int proveedorMailID, int proveedorID, int tipoMailID, string mail, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID, ProveedorID = proveedorID, TipoMailID = tipoMailID, Mail = mail, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.ProveedorMail Guardar(Cosmos.Compras.Entidades.ProveedorMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorMail> listado = new List<Cosmos.Compras.Entidades.ProveedorMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorMail resultado = new Cosmos.Compras.Entidades.ProveedorMail();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorMail/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int proveedorMailID){
            return Eliminar(new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProveedorMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorMail/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
