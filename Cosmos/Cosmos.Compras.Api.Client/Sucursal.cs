
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Sucursal
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.Sucursal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.Sucursal> Listado(Cosmos.Compras.Entidades.Sucursal entidad) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = entidad;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Sucursal> listado = new List<Cosmos.Compras.Entidades.Sucursal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Sucursal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Sucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Sucursal Consultar(int sucursalID) {
            return Consultar(new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.Sucursal Consultar(Cosmos.Compras.Entidades.Sucursal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Sucursal> listado = new List<Cosmos.Compras.Entidades.Sucursal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Sucursal resultado = new Cosmos.Compras.Entidades.Sucursal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Sucursal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Sucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Sucursal Guardar(int sucursalID, string sucursalClave, string nombre, string nombreCorto, int empresaID, int domicilioID){ 
            return Guardar(new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID, SucursalClave = sucursalClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID, DomicilioID = domicilioID });
        }

        public static Cosmos.Compras.Entidades.Sucursal Guardar(Cosmos.Compras.Entidades.Sucursal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Sucursal> listado = new List<Cosmos.Compras.Entidades.Sucursal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Sucursal resultado = new Cosmos.Compras.Entidades.Sucursal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Sucursal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Sucursal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sucursalID){
            return Eliminar(new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Sucursal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Sucursal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
