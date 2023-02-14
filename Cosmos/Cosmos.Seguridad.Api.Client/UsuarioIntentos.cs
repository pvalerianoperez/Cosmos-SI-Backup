
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class UsuarioIntentos
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioIntentos> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioIntentos> listado = new List<Cosmos.Seguridad.Entidades.UsuarioIntentos>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioIntentos/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioIntentos>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioIntentos Guardar(int usuarioID, DateTime fecha, string iP, string contrasena){ 
            return Guardar(new Cosmos.Seguridad.Entidades.UsuarioIntentos() { UsuarioID = usuarioID, Fecha = fecha, IP = iP, Contrasena = contrasena });
        }

        public static Cosmos.Seguridad.Entidades.UsuarioIntentos Guardar(Cosmos.Seguridad.Entidades.UsuarioIntentos o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioIntentos> listado = new List<Cosmos.Seguridad.Entidades.UsuarioIntentos>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.UsuarioIntentos resultado = new Cosmos.Seguridad.Entidades.UsuarioIntentos();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioIntentos/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioIntentos>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        #endregion
        
       
    }
}
