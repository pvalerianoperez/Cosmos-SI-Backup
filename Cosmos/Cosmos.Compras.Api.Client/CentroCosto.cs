
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class CentroCosto
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.CentroCosto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.CentroCosto() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.CentroCosto> Listado(Cosmos.Compras.Entidades.CentroCosto o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CentroCosto> listado = new List<Cosmos.Compras.Entidades.CentroCosto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/CentroCosto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CentroCosto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.CentroCosto Consultar(int centroCostoID) {
            return Consultar(new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID  });
        }
        
        public static Cosmos.Compras.Entidades.CentroCosto Consultar(Cosmos.Compras.Entidades.CentroCosto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CentroCosto> listado = new List<Cosmos.Compras.Entidades.CentroCosto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.CentroCosto resultado = new Cosmos.Compras.Entidades.CentroCosto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/CentroCosto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CentroCosto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.CentroCosto Guardar(int centroCostoID, int empresaID, string centroCostoClave, string nombre, string nombreCorto, string administracion){ 
            return Guardar(new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID, EmpresaID=empresaID, CentroCostoClave = centroCostoClave, Nombre = nombre, NombreCorto = nombreCorto, Administracion = administracion });
        }

        public static Cosmos.Compras.Entidades.CentroCosto Guardar(Cosmos.Compras.Entidades.CentroCosto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.CentroCosto> listado = new List<Cosmos.Compras.Entidades.CentroCosto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.CentroCosto resultado = new Cosmos.Compras.Entidades.CentroCosto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/CentroCosto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.CentroCosto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int centroCostoID){
            return Eliminar(new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.CentroCosto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/CentroCosto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
