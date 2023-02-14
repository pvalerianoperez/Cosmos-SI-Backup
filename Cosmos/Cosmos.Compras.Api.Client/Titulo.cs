
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Titulo
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Titulo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Titulo> listado = new List<Cosmos.Compras.Entidades.Titulo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Titulo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Titulo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Titulo Consultar(int tituloID) {
            return Consultar(new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID  });
        }
        
        public static Cosmos.Compras.Entidades.Titulo Consultar(Cosmos.Compras.Entidades.Titulo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Titulo> listado = new List<Cosmos.Compras.Entidades.Titulo>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Titulo resultado = new Cosmos.Compras.Entidades.Titulo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Titulo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Titulo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Titulo Guardar(int tituloID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Titulo Guardar(Cosmos.Compras.Entidades.Titulo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Titulo> listado = new List<Cosmos.Compras.Entidades.Titulo>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Titulo resultado = new Cosmos.Compras.Entidades.Titulo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Titulo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Titulo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tituloID){
            return Eliminar(new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Titulo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Titulo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
