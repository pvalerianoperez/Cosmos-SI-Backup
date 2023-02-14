
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class TipoDocumentoRegla
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> listado = new List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumentoRegla/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Consultar(int tipoDocumentoReglaID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Consultar(Cosmos.Sistema.Entidades.TipoDocumentoRegla o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> listado = new List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoDocumentoRegla resultado = new Cosmos.Sistema.Entidades.TipoDocumentoRegla();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumentoRegla/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Guardar(int tipoDocumentoReglaID, int sistemaEstatusTipoDocumentoID, int sistemaEstatusTipoDocumentoIDPermite){ 
            return Guardar(new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, SistemaEstatusTipoDocumentoIDPermite = sistemaEstatusTipoDocumentoIDPermite });
        }

        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Guardar(Cosmos.Sistema.Entidades.TipoDocumentoRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> listado = new List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoDocumentoRegla resultado = new Cosmos.Sistema.Entidades.TipoDocumentoRegla();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumentoRegla/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoDocumentoReglaID){
            return Eliminar(new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.TipoDocumentoRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumentoRegla/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
