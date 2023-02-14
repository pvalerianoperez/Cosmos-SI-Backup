
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProveedorSucursal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorSucursal> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorSucursal> listado = new List<Cosmos.Compras.Entidades.ProveedorSucursal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorSucursal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorSucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Consultar(int proveedorSucursalID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Consultar(Cosmos.Compras.Entidades.ProveedorSucursal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorSucursal> listado = new List<Cosmos.Compras.Entidades.ProveedorSucursal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorSucursal resultado = new Cosmos.Compras.Entidades.ProveedorSucursal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorSucursal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorSucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Guardar(int proveedorSucursalID, int sucursalID, int proveedorID, string proveedorClave, int estatus){ 
            return Guardar(new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID, SucursalID = sucursalID, ProveedorID = proveedorID, ProveedorClave = proveedorClave, Estatus = estatus });
        }

        public static Cosmos.Compras.Entidades.ProveedorSucursal Guardar(Cosmos.Compras.Entidades.ProveedorSucursal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProveedorSucursal> listado = new List<Cosmos.Compras.Entidades.ProveedorSucursal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProveedorSucursal resultado = new Cosmos.Compras.Entidades.ProveedorSucursal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProveedorSucursal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProveedorSucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int proveedorSucursalID){
            return Eliminar(new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProveedorSucursal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProveedorSucursal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
