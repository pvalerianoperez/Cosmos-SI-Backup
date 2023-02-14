
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Ciudad
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Ciudad> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Ciudad> listado = new List<Cosmos.Compras.Entidades.Ciudad>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Ciudad/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Ciudad>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Ciudad Consultar(int ciudadID) {
            return Consultar(new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID  });
        }
        
        public static Cosmos.Compras.Entidades.Ciudad Consultar(Cosmos.Compras.Entidades.Ciudad o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Ciudad> listado = new List<Cosmos.Compras.Entidades.Ciudad>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Ciudad resultado = new Cosmos.Compras.Entidades.Ciudad();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Ciudad/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Ciudad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Ciudad Guardar(int ciudadID, string ciudadClave, string nombre, string nombreCorto, int municipioID){ 
            return Guardar(new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID, CiudadClave = ciudadClave, Nombre = nombre, NombreCorto = nombreCorto, MunicipioID = municipioID });
        }

        public static Cosmos.Compras.Entidades.Ciudad Guardar(Cosmos.Compras.Entidades.Ciudad o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Ciudad> listado = new List<Cosmos.Compras.Entidades.Ciudad>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Ciudad resultado = new Cosmos.Compras.Entidades.Ciudad();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Ciudad/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Ciudad>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int ciudadID){
            return Eliminar(new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Ciudad o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Ciudad/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
