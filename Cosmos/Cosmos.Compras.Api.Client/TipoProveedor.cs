
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoProveedor
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoProveedor> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoProveedor() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.TipoProveedor> Listado(Cosmos.Compras.Entidades.TipoProveedor o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoProveedor>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoProveedor/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoProveedor Consultar(int tipoProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProveedor Consultar(Cosmos.Compras.Entidades.TipoProveedor o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoProveedor resultado = new Cosmos.Compras.Entidades.TipoProveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoProveedor/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoProveedor Guardar(int tipoProveedorID, string tipoProveedorClave, string nombre, string nombreCorto, int empresaID){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID, TipoProveedorClave = tipoProveedorClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID });
        }

        public static Cosmos.Compras.Entidades.TipoProveedor Guardar(Cosmos.Compras.Entidades.TipoProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoProveedor> listado = new List<Cosmos.Compras.Entidades.TipoProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoProveedor resultado = new Cosmos.Compras.Entidades.TipoProveedor();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoProveedor/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoProveedorID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoProveedor/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
