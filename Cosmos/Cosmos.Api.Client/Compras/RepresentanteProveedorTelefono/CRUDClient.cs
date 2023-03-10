
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Compras
{
    public partial class RepresentanteProveedorTelefono
    {
        public static List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono> listado = new List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/RepresentanteProveedorTelefono/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
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
        
        public static Cosmos.Entidades.Compras.RepresentanteProveedorTelefono Guardar(int representanteProveedorTelefonoID, int representanteProveedorID, int telefonoID, string extension, bool predeterminado, string comentarios) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID, RepresentanteProveedorID = representanteProveedorID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono> listado = new List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>();

            //resultado del metodo 
            Cosmos.Entidades.Compras.RepresentanteProveedorTelefono resultado = new Cosmos.Entidades.Compras.RepresentanteProveedorTelefono();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/RepresentanteProveedorTelefono/Guardar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                    if(listado!=null){
                        if(listado.Count>0){
                            resultado = listado[0];
                        }
                    }
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

        public static void Eliminar(int representanteProveedorTelefonoID) {

            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/RepresentanteProveedorTelefono/Eliminar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud); 
                if (!respuesta.Exitoso){
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex) {
                throw(ex);
            }                                   
        }
        
        public static Cosmos.Entidades.Compras.RepresentanteProveedorTelefono Consultar(int representanteProveedorTelefonoID) {
        
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
             //listado de respuesta
            List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono> listado = new List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/RepresentanteProveedorTelefono/Consultar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud); 
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.RepresentanteProveedorTelefono>>(JsonConvert.SerializeObject(respuesta.Datos));
                }
                else {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                } 
            }
            catch (Exception ex) {
                throw(ex);
            }
                
            //regresa la respuesta
            if (listado.Count > 0) { 
                return listado[0]; 
            }else{
                return null;
            }
        }
    
    }
}
