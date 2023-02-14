
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Almacen
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Almacen> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.Almacen> Listado(Cosmos.Compras.Entidades.Sucursal o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Almacen> listado = new List<Cosmos.Compras.Entidades.Almacen>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Almacen/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Almacen>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Almacen Consultar(int almacenID) {
            return Consultar(new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID  });
        }
        
        public static Cosmos.Compras.Entidades.Almacen Consultar(Cosmos.Compras.Entidades.Almacen o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Almacen> listado = new List<Cosmos.Compras.Entidades.Almacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Almacen resultado = new Cosmos.Compras.Entidades.Almacen();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Almacen/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Almacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Almacen Guardar(int almacenID, string almacenClave, string nombre, string nombreCorto, int sucursalID){ 
            return Guardar(new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID, AlmacenClave = almacenClave, Nombre = nombre, NombreCorto = nombreCorto, SucursalID = sucursalID });
        }

        public static Cosmos.Compras.Entidades.Almacen Guardar(Cosmos.Compras.Entidades.Almacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Almacen> listado = new List<Cosmos.Compras.Entidades.Almacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Almacen resultado = new Cosmos.Compras.Entidades.Almacen();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Almacen/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Almacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int almacenID){
            return Eliminar(new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Almacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Almacen/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
