
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class EstatusDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstatusDocumento> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusDocumento> listado = new List<Cosmos.Compras.Entidades.EstatusDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstatusDocumento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Consultar(int estatusDocumentoID) {
            return Consultar(new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Consultar(Cosmos.Compras.Entidades.EstatusDocumento o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusDocumento> listado = new List<Cosmos.Compras.Entidades.EstatusDocumento>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstatusDocumento resultado = new Cosmos.Compras.Entidades.EstatusDocumento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstatusDocumento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Guardar(int estatusDocumentoID, string estatusDocumentoClave, string nombre, string nombreCorto, int sistemaEstatusTipoDocumentoID, bool predeterminado){ 
            return Guardar(new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID, EstatusDocumentoClave = estatusDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, Predeterminado = predeterminado });
        }

        public static Cosmos.Compras.Entidades.EstatusDocumento Guardar(Cosmos.Compras.Entidades.EstatusDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusDocumento> listado = new List<Cosmos.Compras.Entidades.EstatusDocumento>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstatusDocumento resultado = new Cosmos.Compras.Entidades.EstatusDocumento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstatusDocumento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estatusDocumentoID){
            return Eliminar(new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.EstatusDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstatusDocumento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static List<Cosmos.Compras.Entidades.EstatusDocumento> ListadoTipoDocumentoID( int tipoDocumentoID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Compras.Entidades.EstatusDocumento() { SistemaEstatusTipoDocumentoID = tipoDocumentoID };
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstatusDocumento> listado = new List<Cosmos.Compras.Entidades.EstatusDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstatusDocumento/ListadoTipoDocumentoID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
