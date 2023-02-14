
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Sistema
{
    public partial class Parametro
    {
        public static List<Cosmos.Entidades.Sistema.Parametro> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Sistema.Parametro> listado = new List<Cosmos.Entidades.Sistema.Parametro>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Sistema/Parametro/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Sistema.Parametro>>(JsonConvert.SerializeObject(respuesta.Datos));
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
        
        public static Cosmos.Entidades.Sistema.Parametro Guardar(bool clientesCompartidos, bool proveedoresCompartidos, bool productosCompartidos) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Sistema.Parametro() { ClientesCompartidos = clientesCompartidos, ProveedoresCompartidos = proveedoresCompartidos, ProductosCompartidos = productosCompartidos };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Sistema.Parametro> listado = new List<Cosmos.Entidades.Sistema.Parametro>();

            //resultado del metodo 
            Cosmos.Entidades.Sistema.Parametro resultado = new Cosmos.Entidades.Sistema.Parametro();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Sistema/Parametro/Guardar", AppGlobals.ApiURL);
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
