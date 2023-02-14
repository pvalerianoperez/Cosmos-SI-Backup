
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class BitacoraEstatus
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.BitacoraEstatus> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.BitacoraEstatus> listado = new List<Cosmos.Sistema.Entidades.BitacoraEstatus>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/BitacoraEstatus/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.BitacoraEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Consultar(int bitacoraEstatusID) {
            return Consultar(new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID  });
        }
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Consultar(Cosmos.Sistema.Entidades.BitacoraEstatus o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.BitacoraEstatus> listado = new List<Cosmos.Sistema.Entidades.BitacoraEstatus>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.BitacoraEstatus resultado = new Cosmos.Sistema.Entidades.BitacoraEstatus();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/BitacoraEstatus/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.BitacoraEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Guardar(int bitacoraEstatusID, int tipoDocumentoID, int documentoID, int usuarioID, int sistemaEstatusDocumentoID, int sistemaEstatusDocumentoIDAnterior, DateTime fechaHora){ 
            return Guardar(new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID, TipoDocumentoID = tipoDocumentoID, DocumentoID = documentoID, UsuarioID = usuarioID, SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, SistemaEstatusDocumentoIDAnterior = sistemaEstatusDocumentoIDAnterior, FechaHora = fechaHora });
        }

        public static Cosmos.Sistema.Entidades.BitacoraEstatus Guardar(Cosmos.Sistema.Entidades.BitacoraEstatus o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.BitacoraEstatus> listado = new List<Cosmos.Sistema.Entidades.BitacoraEstatus>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.BitacoraEstatus resultado = new Cosmos.Sistema.Entidades.BitacoraEstatus();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/BitacoraEstatus/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.BitacoraEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int bitacoraEstatusID){
            return Eliminar(new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.BitacoraEstatus o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/BitacoraEstatus/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
