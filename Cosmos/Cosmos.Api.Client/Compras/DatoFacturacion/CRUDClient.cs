﻿
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Compras
{
    public partial class DatoFacturacion
    {
        public static List<Cosmos.Entidades.Compras.DatoFacturacion> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Compras.DatoFacturacion> listado = new List<Cosmos.Entidades.Compras.DatoFacturacion>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/DatoFacturacion/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
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
        
        public static Cosmos.Entidades.Compras.DatoFacturacion Guardar(int datoFacturacionID, int personaID, string rFC, int domicilioID) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.DatoFacturacion() { DatoFacturacionID = datoFacturacionID, PersonaID = personaID, RFC = rFC, DomicilioID = domicilioID };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Compras.DatoFacturacion> listado = new List<Cosmos.Entidades.Compras.DatoFacturacion>();

            //resultado del metodo 
            Cosmos.Entidades.Compras.DatoFacturacion resultado = new Cosmos.Entidades.Compras.DatoFacturacion();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/DatoFacturacion/Guardar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
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

        public static void Eliminar(int datoFacturacionID) {

            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.DatoFacturacion() { DatoFacturacionID = datoFacturacionID };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/DatoFacturacion/Eliminar", AppGlobals.ApiURL);
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
        
        public static Cosmos.Entidades.Compras.DatoFacturacion Consultar(int datoFacturacionID) {
        
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.DatoFacturacion() { DatoFacturacionID = datoFacturacionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
             //listado de respuesta
            List<Cosmos.Entidades.Compras.DatoFacturacion> listado = new List<Cosmos.Entidades.Compras.DatoFacturacion>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/DatoFacturacion/Consultar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud); 
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.DatoFacturacion>>(JsonConvert.SerializeObject(respuesta.Datos));
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
