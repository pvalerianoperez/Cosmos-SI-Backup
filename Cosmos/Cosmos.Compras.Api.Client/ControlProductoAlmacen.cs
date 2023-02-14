
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ControlProductoAlmacen
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ControlProductoAlmacen> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ControlProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ControlProductoAlmacen>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ControlProductoAlmacen/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ControlProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Consultar(int controlProductoAlmacenID) {
            return Consultar(new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID  });
        }
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Consultar(Cosmos.Compras.Entidades.ControlProductoAlmacen o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ControlProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ControlProductoAlmacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ControlProductoAlmacen resultado = new Cosmos.Compras.Entidades.ControlProductoAlmacen();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ControlProductoAlmacen/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ControlProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Guardar(int controlProductoAlmacenID, int productoID, int almacenID, decimal maximo, decimal minimo, decimal reorden, decimal costoPromedio, decimal ultimoCosto){ 
            return Guardar(new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID, ProductoID = productoID, AlmacenID = almacenID, Maximo = maximo, Minimo = minimo, Reorden = reorden, CostoPromedio = costoPromedio, UltimoCosto = ultimoCosto });
        }

        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Guardar(Cosmos.Compras.Entidades.ControlProductoAlmacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ControlProductoAlmacen> listado = new List<Cosmos.Compras.Entidades.ControlProductoAlmacen>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ControlProductoAlmacen resultado = new Cosmos.Compras.Entidades.ControlProductoAlmacen();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ControlProductoAlmacen/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ControlProductoAlmacen>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int controlProductoAlmacenID){
            return Eliminar(new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ControlProductoAlmacen o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ControlProductoAlmacen/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
