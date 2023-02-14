
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Seguridad
{
    public partial class UsuarioOpcionBitacora
    {
        public static List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora> listado = new List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/UsuarioOpcionBitacora/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora>>(JsonConvert.SerializeObject(respuesta.Datos));
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
        
        public static Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora Guardar(int usuarioID, DateTime fecha, int empresaID, int moduloID, int opcionID) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora() { UsuarioID = usuarioID, Fecha = fecha, EmpresaID = empresaID, ModuloID = moduloID, OpcionID = opcionID };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora> listado = new List<Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora>();

            //resultado del metodo 
            Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora resultado = new Cosmos.Entidades.Seguridad.UsuarioOpcionBitacora();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/UsuarioOpcionBitacora/Guardar", AppGlobals.ApiURL);
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
