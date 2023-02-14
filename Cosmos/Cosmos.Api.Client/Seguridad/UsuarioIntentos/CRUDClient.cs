
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Seguridad
{
    public partial class UsuarioIntentos
    {
        public static List<Cosmos.Entidades.Seguridad.UsuarioIntentos> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.UsuarioIntentos> listado = new List<Cosmos.Entidades.Seguridad.UsuarioIntentos>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/UsuarioIntentos/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.UsuarioIntentos>>(JsonConvert.SerializeObject(respuesta.Datos));
                }
                else {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }            
            }
            catch (Exception ex) {
                throw (ex);
            }
                
            //regresa la respuesta
            return listado;  
            
                    
        }
        
        public static Cosmos.Entidades.Seguridad.UsuarioIntentos Guardar(int usuarioID, DateTime fecha, string iP, string contrasena) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Seguridad.UsuarioIntentos() { UsuarioID = usuarioID, Fecha = fecha, IP = iP, Contrasena = contrasena };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.UsuarioIntentos> listado = new List<Cosmos.Entidades.Seguridad.UsuarioIntentos>();

            //resultado del metodo 
            Cosmos.Entidades.Seguridad.UsuarioIntentos resultado = new Cosmos.Entidades.Seguridad.UsuarioIntentos();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/UsuarioIntentos/Guardar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                }else{
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex) {
                throw(ex);
            }
            return resultado;
        }

    
    }
}
