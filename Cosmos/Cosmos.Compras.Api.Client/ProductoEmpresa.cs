
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ProductoEmpresa
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProductoEmpresa> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoEmpresa> listado = new List<Cosmos.Compras.Entidades.ProductoEmpresa>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProductoEmpresa/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Consultar(int productoEmpresaID) {
            return Consultar(new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID  });
        }
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Consultar(Cosmos.Compras.Entidades.ProductoEmpresa o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoEmpresa> listado = new List<Cosmos.Compras.Entidades.ProductoEmpresa>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProductoEmpresa resultado = new Cosmos.Compras.Entidades.ProductoEmpresa();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProductoEmpresa/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Guardar(int productoEmpresaID, int empresaID, int productoID, string productoClave){ 
            return Guardar(new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID, EmpresaID = empresaID, ProductoID = productoID, ProductoClave = productoClave });
        }

        public static Cosmos.Compras.Entidades.ProductoEmpresa Guardar(Cosmos.Compras.Entidades.ProductoEmpresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ProductoEmpresa> listado = new List<Cosmos.Compras.Entidades.ProductoEmpresa>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ProductoEmpresa resultado = new Cosmos.Compras.Entidades.ProductoEmpresa();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ProductoEmpresa/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ProductoEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int productoEmpresaID){
            return Eliminar(new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ProductoEmpresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ProductoEmpresa/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
