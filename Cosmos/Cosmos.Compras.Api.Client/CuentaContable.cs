
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class CuentaContable
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.CuentaContable> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CuentaContable> listado = new List<Cosmos.Compras.Entidades.CuentaContable>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/CuentaContable/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CuentaContable>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.CuentaContable Consultar(int cuentaContableID) {
            return Consultar(new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID  });
        }
        
        public static Cosmos.Compras.Entidades.CuentaContable Consultar(Cosmos.Compras.Entidades.CuentaContable o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CuentaContable> listado = new List<Cosmos.Compras.Entidades.CuentaContable>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.CuentaContable resultado = new Cosmos.Compras.Entidades.CuentaContable();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/CuentaContable/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CuentaContable>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.CuentaContable Guardar(int cuentaContableID, string cuentaContableClave, string nombre, int perteneceCuentaContableID){ 
            return Guardar(new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID, CuentaContableClave = cuentaContableClave, Nombre = nombre, PerteneceCuentaContableID = perteneceCuentaContableID });
        }

        public static Cosmos.Compras.Entidades.CuentaContable Guardar(Cosmos.Compras.Entidades.CuentaContable o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CuentaContable> listado = new List<Cosmos.Compras.Entidades.CuentaContable>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.CuentaContable resultado = new Cosmos.Compras.Entidades.CuentaContable();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/CuentaContable/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CuentaContable>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int cuentaContableID){
            return Eliminar(new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.CuentaContable o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/CuentaContable/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
