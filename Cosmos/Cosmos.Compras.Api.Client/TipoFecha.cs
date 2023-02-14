
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoFecha
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoFecha> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoFecha> listado = new List<Cosmos.Compras.Entidades.TipoFecha>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoFecha/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoFecha>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoFecha Consultar(int tipoFechaID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoFecha Consultar(Cosmos.Compras.Entidades.TipoFecha o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoFecha> listado = new List<Cosmos.Compras.Entidades.TipoFecha>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoFecha resultado = new Cosmos.Compras.Entidades.TipoFecha();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoFecha/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoFecha>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoFecha Guardar(int tipoFechaID, string tipoFechaClave, string nombre, string nombreCorto, bool estatus){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID, TipoFechaClave = tipoFechaClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus });
        }

        public static Cosmos.Compras.Entidades.TipoFecha Guardar(Cosmos.Compras.Entidades.TipoFecha o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoFecha> listado = new List<Cosmos.Compras.Entidades.TipoFecha>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoFecha resultado = new Cosmos.Compras.Entidades.TipoFecha();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoFecha/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoFecha>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoFechaID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoFecha o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoFecha/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
