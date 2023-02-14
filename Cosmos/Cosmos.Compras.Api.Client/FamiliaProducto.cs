
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class FamiliaProducto
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.FamiliaProducto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FamiliaProducto> listado = new List<Cosmos.Compras.Entidades.FamiliaProducto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/FamiliaProducto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FamiliaProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.FamiliaProducto Consultar(int familiaProductoID) {
            return Consultar(new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID  });
        }
        
        public static Cosmos.Compras.Entidades.FamiliaProducto Consultar(Cosmos.Compras.Entidades.FamiliaProducto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FamiliaProducto> listado = new List<Cosmos.Compras.Entidades.FamiliaProducto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.FamiliaProducto resultado = new Cosmos.Compras.Entidades.FamiliaProducto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/FamiliaProducto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FamiliaProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.FamiliaProducto Guardar(int familiaProductoID, int padreID, string familiaClave, string familiaClavePadre, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID, PadreID = padreID, FamiliaClave = familiaClave, FamiliaClavePadre = familiaClavePadre, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.FamiliaProducto Guardar(Cosmos.Compras.Entidades.FamiliaProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.FamiliaProducto> listado = new List<Cosmos.Compras.Entidades.FamiliaProducto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.FamiliaProducto resultado = new Cosmos.Compras.Entidades.FamiliaProducto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/FamiliaProducto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.FamiliaProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int familiaProductoID){
            return Eliminar(new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.FamiliaProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/FamiliaProducto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
