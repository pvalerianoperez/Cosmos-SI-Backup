
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Area
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Area> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Area() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Area> Listado(Cosmos.Compras.Entidades.Area o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Area> listado = new List<Cosmos.Compras.Entidades.Area>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Area/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Area>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Area Consultar(int areaId) {
            return Consultar(new Cosmos.Compras.Entidades.Area() { AreaId = areaId  });
        }
        
        public static Cosmos.Compras.Entidades.Area Consultar(Cosmos.Compras.Entidades.Area o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Area> listado = new List<Cosmos.Compras.Entidades.Area>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Area resultado = new Cosmos.Compras.Entidades.Area();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Area/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Area>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Area Guardar(int areaId, int empresaID, string areaClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Area() { AreaId = areaId, EmpresaID = empresaID, AreaClave = areaClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Area Guardar(Cosmos.Compras.Entidades.Area o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Area> listado = new List<Cosmos.Compras.Entidades.Area>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Area resultado = new Cosmos.Compras.Entidades.Area();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Area/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Area>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int areaId){
            return Eliminar(new Cosmos.Compras.Entidades.Area() { AreaId = areaId });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Area o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Area/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
