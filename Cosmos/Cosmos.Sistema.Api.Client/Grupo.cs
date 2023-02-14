
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class Grupo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Grupo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Grupo> listado = new List<Cosmos.Sistema.Entidades.Grupo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Grupo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Grupo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.Grupo Consultar(int sistemaGrupoID) {
            return Consultar(new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID  });
        }
        
        public static Cosmos.Sistema.Entidades.Grupo Consultar(Cosmos.Sistema.Entidades.Grupo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Grupo> listado = new List<Cosmos.Sistema.Entidades.Grupo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Grupo resultado = new Cosmos.Sistema.Entidades.Grupo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Grupo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Grupo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.Grupo Guardar(int sistemaGrupoID, string nombre, int moduloID, bool activo){ 
            return Guardar(new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID, Nombre = nombre, ModuloID = moduloID, Activo = activo });
        }

        public static Cosmos.Sistema.Entidades.Grupo Guardar(Cosmos.Sistema.Entidades.Grupo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Grupo> listado = new List<Cosmos.Sistema.Entidades.Grupo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Grupo resultado = new Cosmos.Sistema.Entidades.Grupo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Grupo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Grupo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sistemaGrupoID){
            return Eliminar(new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.Grupo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Grupo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
