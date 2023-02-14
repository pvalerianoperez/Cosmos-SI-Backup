
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Domicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Domicilio> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Domicilio> listado = new List<Cosmos.Compras.Entidades.Domicilio>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Domicilio/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Domicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Domicilio Consultar(int domicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.Domicilio Consultar(Cosmos.Compras.Entidades.Domicilio o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Domicilio> listado = new List<Cosmos.Compras.Entidades.Domicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Domicilio resultado = new Cosmos.Compras.Entidades.Domicilio();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Domicilio/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Domicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Domicilio Guardar(int domicilioID, string calle, string numeroExterior, string numeroInterior, string entreCalle1, string entreCalle2, int codigoPostal, string colonia, string coordenadas, int ciudadID){ 
            return Guardar(new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID, Calle = calle, NumeroExterior = numeroExterior, NumeroInterior = numeroInterior, EntreCalle1 = entreCalle1, EntreCalle2 = entreCalle2, CodigoPostal = codigoPostal, Colonia = colonia, Coordenadas = coordenadas, CiudadID = ciudadID });
        }

        public static Cosmos.Compras.Entidades.Domicilio Guardar(Cosmos.Compras.Entidades.Domicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Domicilio> listado = new List<Cosmos.Compras.Entidades.Domicilio>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Domicilio resultado = new Cosmos.Compras.Entidades.Domicilio();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Domicilio/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Domicilio>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int domicilioID){
            return Eliminar(new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Domicilio o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Domicilio/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
