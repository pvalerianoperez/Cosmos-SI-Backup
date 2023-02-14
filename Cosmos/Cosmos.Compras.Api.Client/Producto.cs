
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Producto
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Producto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Producto> listado = new List<Cosmos.Compras.Entidades.Producto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Producto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Producto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Producto Consultar(int productoID) {
            return Consultar(new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID  });
        }
        
        public static Cosmos.Compras.Entidades.Producto Consultar(Cosmos.Compras.Entidades.Producto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Producto> listado = new List<Cosmos.Compras.Entidades.Producto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Producto resultado = new Cosmos.Compras.Entidades.Producto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Producto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Producto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Producto Guardar(int productoID, int marcaID, string nombre, string nombreCorto, int unidadID, int claseProductoID, int tipoProductoID, int nivelProductoID, int metodoCosteoID, bool manejaLotes, bool manejaSeries, decimal reorden, int familiaProductoID, int estatusProductoID){ 
            return Guardar(new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID, MarcaID = marcaID, Nombre = nombre, NombreCorto = nombreCorto, UnidadID = unidadID, ClaseProductoID = claseProductoID, TipoProductoID = tipoProductoID, NivelProductoID = nivelProductoID, MetodoCosteoID = metodoCosteoID, ManejaLotes = manejaLotes, ManejaSeries = manejaSeries, Reorden = reorden, FamiliaProductoID = familiaProductoID, EstatusProductoID = estatusProductoID });
        }

        public static Cosmos.Compras.Entidades.Producto Guardar(Cosmos.Compras.Entidades.Producto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Producto> listado = new List<Cosmos.Compras.Entidades.Producto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Producto resultado = new Cosmos.Compras.Entidades.Producto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Producto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Producto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int productoID){
            return Eliminar(new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Producto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Producto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static DataTable ListadoFamiliaProducto(int familiaProductoID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Compras.Entidades.Producto() { FamiliaProductoID = familiaProductoID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            DataTable listado=null;

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Producto/ListadoFamiliaProducto", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;

           

        }
    }
}
