
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Empresa
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Empresa> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Empresa> listado = new List<Cosmos.Seguridad.Entidades.Empresa>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Empresa/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Empresa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Empresa Consultar(int empresaID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Empresa Consultar(Cosmos.Seguridad.Entidades.Empresa o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Empresa> listado = new List<Cosmos.Seguridad.Entidades.Empresa>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Empresa resultado = new Cosmos.Seguridad.Entidades.Empresa();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Empresa/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Empresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Empresa Guardar(int empresaID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.Empresa Guardar(Cosmos.Seguridad.Entidades.Empresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Empresa> listado = new List<Cosmos.Seguridad.Entidades.Empresa>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Empresa resultado = new Cosmos.Seguridad.Entidades.Empresa();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Empresa/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Empresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int empresaID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Empresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Empresa/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
