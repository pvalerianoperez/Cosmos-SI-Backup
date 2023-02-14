
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class UsuarioPerfil
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioPerfil> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> listado = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioPerfil/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioPerfil>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Consultar(int usuarioID, int perfilID, int empresaID) {
            return Consultar(new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Consultar(Cosmos.Seguridad.Entidades.UsuarioPerfil o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> listado = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.UsuarioPerfil resultado = new Cosmos.Seguridad.Entidades.UsuarioPerfil();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioPerfil/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioPerfil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Guardar(int usuarioID, int perfilID, int empresaID){ 
            return Guardar(new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID });
        }

        public static Cosmos.Seguridad.Entidades.UsuarioPerfil Guardar(Cosmos.Seguridad.Entidades.UsuarioPerfil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioPerfil> listado = new List<Cosmos.Seguridad.Entidades.UsuarioPerfil>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.UsuarioPerfil resultado = new Cosmos.Seguridad.Entidades.UsuarioPerfil();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioPerfil/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioPerfil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int usuarioID, int perfilID, int empresaID){
            return Eliminar(new Cosmos.Seguridad.Entidades.UsuarioPerfil() { UsuarioID = usuarioID, PerfilID = perfilID, EmpresaID = empresaID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.UsuarioPerfil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioPerfil/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
