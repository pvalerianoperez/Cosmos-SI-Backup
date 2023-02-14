
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Banco
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Banco> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Banco> listado = new List<Cosmos.Compras.Entidades.Banco>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Banco/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Banco>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Banco Consultar(int bancoID) {
            return Consultar(new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID  });
        }
        
        public static Cosmos.Compras.Entidades.Banco Consultar(Cosmos.Compras.Entidades.Banco o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Banco> listado = new List<Cosmos.Compras.Entidades.Banco>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Banco resultado = new Cosmos.Compras.Entidades.Banco();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Banco/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Banco>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Banco Guardar(int bancoID, string bancoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID, BancoClave = bancoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Banco Guardar(Cosmos.Compras.Entidades.Banco o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Banco> listado = new List<Cosmos.Compras.Entidades.Banco>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Banco resultado = new Cosmos.Compras.Entidades.Banco();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Banco/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Banco>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int bancoID){
            return Eliminar(new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Banco o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Banco/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
