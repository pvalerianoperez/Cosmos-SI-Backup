
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RepresentanteProveedorMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorMail/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Consultar(int representanteProveedorMailID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorMail o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorMail resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorMail/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Guardar(int representanteProveedorMailID, int representanteProveedorID, string mail, int tipoMailID, bool predeterminado, string comentarios){ 
            return Guardar(new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID, RepresentanteProveedorID = representanteProveedorID, Mail = mail, TipoMailID = tipoMailID, Predeterminado = predeterminado, Comentarios = comentarios });
        }

        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Guardar(Cosmos.Compras.Entidades.RepresentanteProveedorMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedorMail resultado = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorMail/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int representanteProveedorMailID){
            return Eliminar(new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RepresentanteProveedorMail o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedorMail/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
