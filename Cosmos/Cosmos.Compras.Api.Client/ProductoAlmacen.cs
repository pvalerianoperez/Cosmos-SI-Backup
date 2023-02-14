
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProductoAlmacen
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProductoAlmacen> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ProductoAlmacen>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProductoAlmacen/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Consultar(int productoAlmacenID) {
            return Consultar(new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = productoAlmacenID  });
        }
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Consultar(Cosmos.Compras.Entidades.ProductoAlmacen o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ProductoAlmacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProductoAlmacen resultado = new Cosmos.Compras.Entidades.ProductoAlmacen();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProductoAlmacen/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Guardar(int productoAlmacenID, int productoID, int almacenID, decimal maximo, decimal minimo, decimal reorden, decimal costoPromedio, decimal ultimoCosto){ 
            return Guardar(new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = productoAlmacenID, ProductoID = productoID, AlmacenID = almacenID, Maximo = maximo, Minimo = minimo, Reorden = reorden, CostoPromedio = costoPromedio, UltimoCosto = ultimoCosto });
        }

        public static Cosmos.Compras.Entidades.ProductoAlmacen Guardar(Cosmos.Compras.Entidades.ProductoAlmacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ProductoAlmacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProductoAlmacen resultado = new Cosmos.Compras.Entidades.ProductoAlmacen();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProductoAlmacen/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int productoAlmacenID){
            return Eliminar(new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = productoAlmacenID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProductoAlmacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProductoAlmacen/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
