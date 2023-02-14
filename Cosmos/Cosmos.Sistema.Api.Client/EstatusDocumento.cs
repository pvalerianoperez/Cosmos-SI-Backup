
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class EstatusDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusDocumento> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusDocumento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Consultar(int sistemaEstatusDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Consultar(Cosmos.Sistema.Entidades.EstatusDocumento o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusDocumento resultado = new Cosmos.Sistema.Entidades.EstatusDocumento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusDocumento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Guardar(int sistemaEstatusDocumentoID, string sistemaEstatusDocumentoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, SistemaEstatusDocumentoClave = sistemaEstatusDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.EstatusDocumento Guardar(Cosmos.Sistema.Entidades.EstatusDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.EstatusDocumento> listado = new List<Cosmos.Sistema.Entidades.EstatusDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.EstatusDocumento resultado = new Cosmos.Sistema.Entidades.EstatusDocumento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/EstatusDocumento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.EstatusDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaEstatusDocumentoID){
            return Eliminar(new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.EstatusDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/EstatusDocumento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
