
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ConceptoIngreso
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.ConceptoIngreso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.ConceptoIngreso() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.ConceptoIngreso> Listado(Cosmos.Compras.Entidades.ConceptoIngreso o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoIngreso> listado = new List<Cosmos.Compras.Entidades.ConceptoIngreso>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ConceptoIngreso/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoIngreso>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Consultar(int conceptoIngresoID) {
            return Consultar(new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Consultar(Cosmos.Compras.Entidades.ConceptoIngreso o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoIngreso> listado = new List<Cosmos.Compras.Entidades.ConceptoIngreso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ConceptoIngreso resultado = new Cosmos.Compras.Entidades.ConceptoIngreso();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ConceptoIngreso/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoIngreso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Guardar(int conceptoIngresoID, string nombre, string nombreCorto, int empresaID){ 
            return Guardar(new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID});
        }

        public static Cosmos.Compras.Entidades.ConceptoIngreso Guardar(Cosmos.Compras.Entidades.ConceptoIngreso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoIngreso> listado = new List<Cosmos.Compras.Entidades.ConceptoIngreso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ConceptoIngreso resultado = new Cosmos.Compras.Entidades.ConceptoIngreso();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ConceptoIngreso/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoIngreso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int conceptoIngresoID){
            return Eliminar(new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ConceptoIngreso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ConceptoIngreso/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
