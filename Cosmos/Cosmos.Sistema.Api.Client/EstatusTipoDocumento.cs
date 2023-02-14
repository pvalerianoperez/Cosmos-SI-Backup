
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class EstatusTipoDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusTipoDocumento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Consultar(int sistemaEstatusTipoDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Consultar(Cosmos.Sistema.Entidades.EstatusTipoDocumento o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusTipoDocumento resultado = new Cosmos.Sistema.Entidades.EstatusTipoDocumento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusTipoDocumento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Guardar(int sistemaEstatusTipoDocumentoID, int sistemaEstatusDocumentoID, int tipoDocumentoID, bool predeterminado, bool restringido, bool monto){ 
            return Guardar(new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, TipoDocumentoID = tipoDocumentoID, Predeterminado = predeterminado, Restringido = restringido, Monto = monto });
        }

        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Guardar(Cosmos.Sistema.Entidades.EstatusTipoDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusTipoDocumento resultado = new Cosmos.Sistema.Entidades.EstatusTipoDocumento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusTipoDocumento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaEstatusTipoDocumentoID){
            return Eliminar(new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.EstatusTipoDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusTipoDocumento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
