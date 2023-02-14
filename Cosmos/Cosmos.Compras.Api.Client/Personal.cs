
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Personal
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Personal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Personal() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Personal> Listado(Cosmos.Compras.Entidades.Personal o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Personal> listado = new List<Cosmos.Compras.Entidades.Personal>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Personal/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Personal>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Personal Consultar(int personalID) {
            return Consultar(new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID  });
        }
        
        public static Cosmos.Compras.Entidades.Personal Consultar(Cosmos.Compras.Entidades.Personal o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Personal> listado = new List<Cosmos.Compras.Entidades.Personal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Personal resultado = new Cosmos.Compras.Entidades.Personal();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Personal/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Personal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Personal Guardar(int personalID, int personaID, string personalClave, int empresaID, int puestoID, int reportaAPersonalID, int areaID, int centroCostoID, int horarioPersonalID, int estatusPersonalID){ 
            return Guardar(new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID, PersonaID = personaID, PersonalClave = personalClave, EmpresaID = empresaID, PuestoID = puestoID, ReportaAPersonalID = reportaAPersonalID, AreaID = areaID, CentroCostoID = centroCostoID, HorarioPersonalID = horarioPersonalID, EstatusPersonalID = estatusPersonalID });
        }

        public static Cosmos.Compras.Entidades.Personal Guardar(Cosmos.Compras.Entidades.Personal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Personal> listado = new List<Cosmos.Compras.Entidades.Personal>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Personal resultado = new Cosmos.Compras.Entidades.Personal();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Personal/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Personal>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personalID){
            return Eliminar(new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Personal o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Personal/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
