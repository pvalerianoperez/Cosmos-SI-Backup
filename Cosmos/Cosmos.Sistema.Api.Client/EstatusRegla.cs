
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class EstatusRegla
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusRegla> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusRegla> listado = new List<Cosmos.Sistema.Entidades.EstatusRegla>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusRegla/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.EstatusRegla Consultar(int estatusReglaID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusRegla() { EstatusReglaID = estatusReglaID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusRegla Consultar(Cosmos.Sistema.Entidades.EstatusRegla o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusRegla> listado = new List<Cosmos.Sistema.Entidades.EstatusRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusRegla resultado = new Cosmos.Sistema.Entidades.EstatusRegla();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusRegla/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.EstatusRegla Guardar(int estatusReglaID, int sistemaEstatusTipoDocumentoID, int sistemaEstatusTipoDocumentoIDPermite){ 
            return Guardar(new Cosmos.Sistema.Entidades.EstatusRegla() { EstatusReglaID = estatusReglaID, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, SistemaEstatusTipoDocumentoIDPermite = sistemaEstatusTipoDocumentoIDPermite });
        }

        public static Cosmos.Sistema.Entidades.EstatusRegla Guardar(Cosmos.Sistema.Entidades.EstatusRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusRegla> listado = new List<Cosmos.Sistema.Entidades.EstatusRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusRegla resultado = new Cosmos.Sistema.Entidades.EstatusRegla();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusRegla/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estatusReglaID){
            return Eliminar(new Cosmos.Sistema.Entidades.EstatusRegla() { EstatusReglaID = estatusReglaID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.EstatusRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusRegla/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
