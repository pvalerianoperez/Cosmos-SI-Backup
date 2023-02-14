
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class EstatusPersonal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstatusPersonal> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusPersonal> listado = new List<Cosmos.Compras.Entidades.EstatusPersonal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstatusPersonal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Consultar(int estatusPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Consultar(Cosmos.Compras.Entidades.EstatusPersonal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusPersonal> listado = new List<Cosmos.Compras.Entidades.EstatusPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstatusPersonal resultado = new Cosmos.Compras.Entidades.EstatusPersonal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstatusPersonal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Guardar(int estatusPersonalID, string estatusPersonalClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID, EstatusPersonalClave = estatusPersonalClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.EstatusPersonal Guardar(Cosmos.Compras.Entidades.EstatusPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusPersonal> listado = new List<Cosmos.Compras.Entidades.EstatusPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstatusPersonal resultado = new Cosmos.Compras.Entidades.EstatusPersonal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstatusPersonal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estatusPersonalID){
            return Eliminar(new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.EstatusPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstatusPersonal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
