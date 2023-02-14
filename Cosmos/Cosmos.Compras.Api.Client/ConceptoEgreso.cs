
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class ConceptoEgreso
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.ConceptoEgreso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.ConceptoEgreso() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.ConceptoEgreso> Listado(Cosmos.Compras.Entidades.ConceptoEgreso o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoEgreso> listado = new List<Cosmos.Compras.Entidades.ConceptoEgreso>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ConceptoEgreso/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoEgreso>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Consultar(int conceptoEgresoID) {
            return Consultar(new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Consultar(Cosmos.Compras.Entidades.ConceptoEgreso o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoEgreso> listado = new List<Cosmos.Compras.Entidades.ConceptoEgreso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ConceptoEgreso resultado = new Cosmos.Compras.Entidades.ConceptoEgreso();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ConceptoEgreso/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoEgreso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Guardar(int conceptoEgresoID, string conceptoEgresoClave, string nombre, string nombreCorto, string compraFactura, string desglosar, int empresaID){ 
            return Guardar(new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID, ConceptoEgresoClave = conceptoEgresoClave, Nombre = nombre, NombreCorto = nombreCorto, CompraFactura = compraFactura, Desglosar = desglosar, EmpresaID = empresaID });
        }

        public static Cosmos.Compras.Entidades.ConceptoEgreso Guardar(Cosmos.Compras.Entidades.ConceptoEgreso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.ConceptoEgreso> listado = new List<Cosmos.Compras.Entidades.ConceptoEgreso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.ConceptoEgreso resultado = new Cosmos.Compras.Entidades.ConceptoEgreso();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/ConceptoEgreso/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.ConceptoEgreso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int conceptoEgresoID){
            return Eliminar(new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.ConceptoEgreso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/ConceptoEgreso/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
