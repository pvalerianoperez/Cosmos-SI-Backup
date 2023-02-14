
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RequisicionDetalle
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RequisicionDetalle> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionDetalle> listado = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionDetalle/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionDetalle>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Consultar(int requisicionDetalleID) {
            return Consultar(new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Consultar(Cosmos.Compras.Entidades.RequisicionDetalle o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionDetalle> listado = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RequisicionDetalle resultado = new Cosmos.Compras.Entidades.RequisicionDetalle();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RequisicionDetalle/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionDetalle>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Guardar(int requisicionDetalleID, int requisicionEncabezadoID, int renglon, int productoID, double cantidad, int unidadID, int almacenID, int conceptoEgresoID, int cuentaContableID, string descripcioAdicional, int estatusDocumentoID){ 
            return Guardar(new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID, RequisicionEncabezadoID = requisicionEncabezadoID, Renglon = renglon, ProductoID = productoID, Cantidad = cantidad, UnidadID = unidadID, AlmacenID = almacenID, ConceptoEgresoID = conceptoEgresoID, CuentaContableID = cuentaContableID, DescripcioAdicional = descripcioAdicional, EstatusDocumentoID = estatusDocumentoID });
        }

        public static Cosmos.Compras.Entidades.RequisicionDetalle Guardar(Cosmos.Compras.Entidades.RequisicionDetalle o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionDetalle> listado = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RequisicionDetalle resultado = new Cosmos.Compras.Entidades.RequisicionDetalle();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionDetalle/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionDetalle>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int requisicionDetalleID){
            return Eliminar(new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RequisicionDetalle o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RequisicionDetalle/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static List<Cosmos.Compras.Entidades.RequisicionDetalle> ListadoRequisicionEncabezadoID(int requisicionEncabezadoID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionEncabezadoID = requisicionEncabezadoID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionDetalle> listado = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionDetalle/ListadoRequisicionEncabezadoID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionDetalle>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

    }
}
