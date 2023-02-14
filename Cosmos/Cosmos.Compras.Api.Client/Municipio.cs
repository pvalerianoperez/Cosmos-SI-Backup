
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Municipio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Municipio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Municipio> listado = new List<Cosmos.Compras.Entidades.Municipio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Municipio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Municipio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Municipio Consultar(int municipioID) {
            return Consultar(new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID  });
        }
        
        public static Cosmos.Compras.Entidades.Municipio Consultar(Cosmos.Compras.Entidades.Municipio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Municipio> listado = new List<Cosmos.Compras.Entidades.Municipio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Municipio resultado = new Cosmos.Compras.Entidades.Municipio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Municipio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Municipio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Municipio Guardar(int municipioID, string municipioClave, string nombre, string nombreCorto, int estadoID){ 
            return Guardar(new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID, MunicipioClave = municipioClave, Nombre = nombre, NombreCorto = nombreCorto, EstadoID = estadoID });
        }

        public static Cosmos.Compras.Entidades.Municipio Guardar(Cosmos.Compras.Entidades.Municipio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Municipio> listado = new List<Cosmos.Compras.Entidades.Municipio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Municipio resultado = new Cosmos.Compras.Entidades.Municipio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Municipio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Municipio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int municipioID){
            return Eliminar(new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Municipio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Municipio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
