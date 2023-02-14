
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class HorarioPersonal
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.HorarioPersonal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.HorarioPersonal() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.HorarioPersonal> Listado(Cosmos.Compras.Entidades.HorarioPersonal o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;
            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.HorarioPersonal> listado = new List<Cosmos.Compras.Entidades.HorarioPersonal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/HorarioPersonal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.HorarioPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Consultar(int horarioPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Consultar(Cosmos.Compras.Entidades.HorarioPersonal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.HorarioPersonal> listado = new List<Cosmos.Compras.Entidades.HorarioPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.HorarioPersonal resultado = new Cosmos.Compras.Entidades.HorarioPersonal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/HorarioPersonal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.HorarioPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Guardar(int horarioPersonalID, string horarioPersonalClave, int empresaID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID, HorarioPersonalClave = horarioPersonalClave, EmpresaID = empresaID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.HorarioPersonal Guardar(Cosmos.Compras.Entidades.HorarioPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.HorarioPersonal> listado = new List<Cosmos.Compras.Entidades.HorarioPersonal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.HorarioPersonal resultado = new Cosmos.Compras.Entidades.HorarioPersonal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/HorarioPersonal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.HorarioPersonal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int horarioPersonalID){
            return Eliminar(new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.HorarioPersonal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/HorarioPersonal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
