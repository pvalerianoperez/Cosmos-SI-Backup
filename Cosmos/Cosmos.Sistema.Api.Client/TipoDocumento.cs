
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class TipoDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoDocumento> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumento> listado = new List<Cosmos.Sistema.Entidades.TipoDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Consultar(int tipoDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Consultar(Cosmos.Sistema.Entidades.TipoDocumento o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumento> listado = new List<Cosmos.Sistema.Entidades.TipoDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoDocumento resultado = new Cosmos.Sistema.Entidades.TipoDocumento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Guardar(int tipoDocumentoID, string tipoDocumentoClave, string nombre, string nombreCorto, bool estatus, int moduloID){ 
            return Guardar(new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID, TipoDocumentoClave = tipoDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus, ModuloID = moduloID });
        }

        public static Cosmos.Sistema.Entidades.TipoDocumento Guardar(Cosmos.Sistema.Entidades.TipoDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.TipoDocumento> listado = new List<Cosmos.Sistema.Entidades.TipoDocumento>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.TipoDocumento resultado = new Cosmos.Sistema.Entidades.TipoDocumento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoDocumentoID){
            return Eliminar(new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.TipoDocumento o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/TipoDocumento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
