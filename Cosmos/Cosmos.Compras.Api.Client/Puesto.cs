
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Puesto
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Puesto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Puesto() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Puesto> Listado(Cosmos.Compras.Entidades.Puesto o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Puesto> listado = new List<Cosmos.Compras.Entidades.Puesto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Puesto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Puesto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Puesto Consultar(int puestoID) {
            return Consultar(new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID  });
        }
        
        public static Cosmos.Compras.Entidades.Puesto Consultar(Cosmos.Compras.Entidades.Puesto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Puesto> listado = new List<Cosmos.Compras.Entidades.Puesto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Puesto resultado = new Cosmos.Compras.Entidades.Puesto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Puesto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Puesto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Puesto Guardar(int puestoID, int empresaID, string puestoClave, string nombre, string nombreCorto, decimal sueldo, string baseNeto, string tipo, string objetivo, string reqAcademicos, int tiempoDesempeno){ 
            return Guardar(new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID, EmpresaID = empresaID, PuestoClave = puestoClave, Nombre = nombre, NombreCorto = nombreCorto, Sueldo = sueldo, BaseNeto = baseNeto, Tipo = tipo, Objetivo = objetivo, ReqAcademicos = reqAcademicos, TiempoDesempeno = tiempoDesempeno });
        }

        public static Cosmos.Compras.Entidades.Puesto Guardar(Cosmos.Compras.Entidades.Puesto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Puesto> listado = new List<Cosmos.Compras.Entidades.Puesto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Puesto resultado = new Cosmos.Compras.Entidades.Puesto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Puesto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Puesto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int puestoID){
            return Eliminar(new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Puesto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Puesto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
