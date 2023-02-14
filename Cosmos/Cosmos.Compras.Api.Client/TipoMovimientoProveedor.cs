
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoMovimientoProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoMovimientoProveedor/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Consultar(int tipoMovimientoProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Consultar(Cosmos.Compras.Entidades.TipoMovimientoProveedor o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoMovimientoProveedor resultado = new Cosmos.Compras.Entidades.TipoMovimientoProveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoMovimientoProveedor/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Guardar(int tipoMovimientoProveedorID, string tipoMovimientoProveedorClave, string nombre, string nombreCorto, int naturalezaID){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID, TipoMovimientoProveedorClave = tipoMovimientoProveedorClave, Nombre = nombre, NombreCorto = nombreCorto, NaturalezaID = naturalezaID });
        }

        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Guardar(Cosmos.Compras.Entidades.TipoMovimientoProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoMovimientoProveedor resultado = new Cosmos.Compras.Entidades.TipoMovimientoProveedor();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoMovimientoProveedor/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoMovimientoProveedorID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoMovimientoProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoMovimientoProveedor/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
