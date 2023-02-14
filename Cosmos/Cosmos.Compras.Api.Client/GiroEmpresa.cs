
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class GiroEmpresa
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.GiroEmpresa> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.GiroEmpresa> listado = new List<Cosmos.Compras.Entidades.GiroEmpresa>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/GiroEmpresa/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.GiroEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Consultar(int giroEmpresaID) {
            return Consultar(new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID  });
        }
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Consultar(Cosmos.Compras.Entidades.GiroEmpresa o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.GiroEmpresa> listado = new List<Cosmos.Compras.Entidades.GiroEmpresa>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.GiroEmpresa resultado = new Cosmos.Compras.Entidades.GiroEmpresa();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/GiroEmpresa/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.GiroEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Guardar(int giroEmpresaID, string giroEmpresaClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID, GiroEmpresaClave = giroEmpresaClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.GiroEmpresa Guardar(Cosmos.Compras.Entidades.GiroEmpresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.GiroEmpresa> listado = new List<Cosmos.Compras.Entidades.GiroEmpresa>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.GiroEmpresa resultado = new Cosmos.Compras.Entidades.GiroEmpresa();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/GiroEmpresa/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.GiroEmpresa>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int giroEmpresaID){
            return Eliminar(new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.GiroEmpresa o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/GiroEmpresa/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
