
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoRepresentanteProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoRepresentanteProveedor/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Consultar(int tipoRepresentanteProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Consultar(Cosmos.Compras.Entidades.TipoRepresentanteProveedor o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoRepresentanteProveedor resultado = new Cosmos.Compras.Entidades.TipoRepresentanteProveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoRepresentanteProveedor/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Guardar(int tipoRepresentanteProveedorID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Guardar(Cosmos.Compras.Entidades.TipoRepresentanteProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoRepresentanteProveedor resultado = new Cosmos.Compras.Entidades.TipoRepresentanteProveedor();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoRepresentanteProveedor/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoRepresentanteProveedorID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoRepresentanteProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoRepresentanteProveedor/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
