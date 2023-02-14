
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Fecha
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Fecha> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Fecha> listado = new List<Cosmos.Compras.Entidades.Fecha>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Fecha/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Fecha>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Fecha Consultar(int fechaID) {
            return Consultar(new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID  });
        }
        
        public static Cosmos.Compras.Entidades.Fecha Consultar(Cosmos.Compras.Entidades.Fecha o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Fecha> listado = new List<Cosmos.Compras.Entidades.Fecha>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Fecha resultado = new Cosmos.Compras.Entidades.Fecha();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Fecha/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Fecha>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Fecha Guardar(int fechaID, DateTime valor, int personaID, int tipoFechaID, string comentario){ 
            return Guardar(new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID, Valor = valor, PersonaID = personaID, TipoFechaID = tipoFechaID, Comentario = comentario });
        }

        public static Cosmos.Compras.Entidades.Fecha Guardar(Cosmos.Compras.Entidades.Fecha o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Fecha> listado = new List<Cosmos.Compras.Entidades.Fecha>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Fecha resultado = new Cosmos.Compras.Entidades.Fecha();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Fecha/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Fecha>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int fechaID){
            return Eliminar(new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Fecha o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Fecha/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
