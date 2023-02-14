
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class Parametro
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Parametro> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Parametro> listado = new List<Cosmos.Sistema.Entidades.Parametro>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Parametro/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Parametro>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.Parametro Consultar(int sistemaParametroID) {
            return Consultar(new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID  });
        }
        
        public static Cosmos.Sistema.Entidades.Parametro Consultar(Cosmos.Sistema.Entidades.Parametro o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Parametro> listado = new List<Cosmos.Sistema.Entidades.Parametro>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Parametro resultado = new Cosmos.Sistema.Entidades.Parametro();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Parametro/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Parametro>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.Parametro Guardar(int sistemaParametroID, string nombre, int moduloID, string valor){ 
            return Guardar(new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID, Nombre = nombre, ModuloID = moduloID, Valor = valor });
        }

        public static Cosmos.Sistema.Entidades.Parametro Guardar(Cosmos.Sistema.Entidades.Parametro o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Parametro> listado = new List<Cosmos.Sistema.Entidades.Parametro>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Parametro resultado = new Cosmos.Sistema.Entidades.Parametro();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Parametro/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Parametro>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaParametroID){
            return Eliminar(new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.Parametro o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Parametro/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
