﻿
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Compras
{
    public partial class TipoMovimientoProveedor
    {
        public static List<Cosmos.Entidades.Compras.TipoMovimientoProveedor> Listado() {

        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Compras.TipoMovimientoProveedor> listado = new List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/TipoMovimientoProveedor/Listado", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
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
        
        public static Cosmos.Entidades.Compras.TipoMovimientoProveedor Guardar(int tipoMovimientoProveedorID, string tipoMovimientoProveedorClave, string nombre, string nombreCorto) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID, TipoMovimientoProveedorClave = tipoMovimientoProveedorClave, Nombre = nombre, NombreCorto = nombreCorto };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
            //listado de respuesta
            List<Cosmos.Entidades.Compras.TipoMovimientoProveedor> listado = new List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>();

            //resultado del metodo 
            Cosmos.Entidades.Compras.TipoMovimientoProveedor resultado = new Cosmos.Entidades.Compras.TipoMovimientoProveedor();
            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/TipoMovimientoProveedor/Guardar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
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

        public static void Eliminar(int tipoMovimientoProveedorID) {

            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID };
            
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/TipoMovimientoProveedor/Eliminar", AppGlobals.ApiURL);
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
        
        public static Cosmos.Entidades.Compras.TipoMovimientoProveedor Consultar(int tipoMovimientoProveedorID) {
        
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Compras.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();
            
             //listado de respuesta
            List<Cosmos.Entidades.Compras.TipoMovimientoProveedor> listado = new List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Compras/TipoMovimientoProveedor/Consultar", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud); 
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Compras.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
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
