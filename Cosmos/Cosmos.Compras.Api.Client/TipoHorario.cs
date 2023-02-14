
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class TipoHorario
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoHorario> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoHorario() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.TipoHorario> Listado(Cosmos.Compras.Entidades.TipoHorario o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoHorario> listado = new List<Cosmos.Compras.Entidades.TipoHorario>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoHorario/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoHorario>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.TipoHorario Consultar(int tipoHorarioID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoHorario Consultar(Cosmos.Compras.Entidades.TipoHorario o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoHorario> listado = new List<Cosmos.Compras.Entidades.TipoHorario>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoHorario resultado = new Cosmos.Compras.Entidades.TipoHorario();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoHorario/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoHorario>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.TipoHorario Guardar(int tipoHorarioID, string tipoHorarioClave, string nombre, string nombreCorto, int empresaID, string homogeneo){ 
            return Guardar(new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID, TipoHorarioClave = tipoHorarioClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID, Homogeneo = homogeneo });
        }

        public static Cosmos.Compras.Entidades.TipoHorario Guardar(Cosmos.Compras.Entidades.TipoHorario o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.TipoHorario> listado = new List<Cosmos.Compras.Entidades.TipoHorario>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.TipoHorario resultado = new Cosmos.Compras.Entidades.TipoHorario();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/TipoHorario/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.TipoHorario>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int tipoHorarioID){
            return Eliminar(new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.TipoHorario o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/TipoHorario/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
