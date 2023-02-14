
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class GrupoRegla
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.GrupoRegla> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoRegla> listado = new List<Cosmos.Sistema.Entidades.GrupoRegla>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/GrupoRegla/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Consultar(int sistemaGrupoReglaID) {
            return Consultar(new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Consultar(Cosmos.Sistema.Entidades.GrupoRegla o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoRegla> listado = new List<Cosmos.Sistema.Entidades.GrupoRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.GrupoRegla resultado = new Cosmos.Sistema.Entidades.GrupoRegla();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/GrupoRegla/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Guardar(int sistemaGrupoReglaID, int sistemaGrupoEstatusID, int sistemaEstatusTipoDocumentoID, bool activo){ 
            return Guardar(new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID, SistemaGrupoEstatusID = sistemaGrupoEstatusID, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, Activo = activo });
        }

        public static Cosmos.Sistema.Entidades.GrupoRegla Guardar(Cosmos.Sistema.Entidades.GrupoRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.GrupoRegla> listado = new List<Cosmos.Sistema.Entidades.GrupoRegla>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.GrupoRegla resultado = new Cosmos.Sistema.Entidades.GrupoRegla();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/GrupoRegla/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.GrupoRegla>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaGrupoReglaID){
            return Eliminar(new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.GrupoRegla o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/GrupoRegla/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
