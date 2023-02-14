
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class GrupoEstatus
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.GrupoEstatus> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoEstatus> listado = new List<Cosmos.Sistema.Entidades.GrupoEstatus>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/GrupoEstatus/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Consultar(int sistemaGrupoEstatusID) {
            return Consultar(new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Consultar(Cosmos.Sistema.Entidades.GrupoEstatus o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoEstatus> listado = new List<Cosmos.Sistema.Entidades.GrupoEstatus>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.GrupoEstatus resultado = new Cosmos.Sistema.Entidades.GrupoEstatus();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/GrupoEstatus/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Guardar(int sistemaGrupoEstatusID, int sistemaGrupoID, string nombre, int tipoDocumentoID, string color, bool activo){ 
            return Guardar(new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID, SistemaGrupoID = sistemaGrupoID, Nombre = nombre, TipoDocumentoID = tipoDocumentoID, Color = color, Activo = activo });
        }

        public static Cosmos.Sistema.Entidades.GrupoEstatus Guardar(Cosmos.Sistema.Entidades.GrupoEstatus o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoEstatus> listado = new List<Cosmos.Sistema.Entidades.GrupoEstatus>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.GrupoEstatus resultado = new Cosmos.Sistema.Entidades.GrupoEstatus();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/GrupoEstatus/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoEstatus>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaGrupoEstatusID){
            return Eliminar(new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.GrupoEstatus o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/GrupoEstatus/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
