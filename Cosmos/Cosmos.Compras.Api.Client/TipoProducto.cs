
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoProducto
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoProducto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoProducto() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.TipoProducto> Listado(Cosmos.Compras.Entidades.TipoProducto o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProducto> listado = new List<Cosmos.Compras.Entidades.TipoProducto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoProducto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoProducto Consultar(int tipoProductoID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProducto Consultar(Cosmos.Compras.Entidades.TipoProducto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProducto> listado = new List<Cosmos.Compras.Entidades.TipoProducto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoProducto resultado = new Cosmos.Compras.Entidades.TipoProducto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoProducto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoProducto Guardar(int tipoProductoID, string tipoProductoClave, string nombre, string nombreCorto, int empresaID){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID, TipoProductoClave = tipoProductoClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID });
        }

        public static Cosmos.Compras.Entidades.TipoProducto Guardar(Cosmos.Compras.Entidades.TipoProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProducto> listado = new List<Cosmos.Compras.Entidades.TipoProducto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoProducto resultado = new Cosmos.Compras.Entidades.TipoProducto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoProducto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProducto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoProductoID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoProducto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoProducto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
