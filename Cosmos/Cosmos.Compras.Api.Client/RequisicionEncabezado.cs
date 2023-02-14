
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RequisicionEncabezado
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RequisicionEncabezado> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionEncabezado> listado = new List<Cosmos.Compras.Entidades.RequisicionEncabezado>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionEncabezado/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(int requisicionEncabezadoID) {
            return Consultar(new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(Cosmos.Compras.Entidades.RequisicionEncabezado o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionEncabezado> listado = new List<Cosmos.Compras.Entidades.RequisicionEncabezado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RequisicionEncabezado resultado = new Cosmos.Compras.Entidades.RequisicionEncabezado();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RequisicionEncabezado/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Guardar(int requisicionEncabezadoID, int tipoDocumentoID, int serieID, int sucursalID, int folio, DateTime fecha, string referencia, int personalID, int centroCostoID, int areaID, string concepto, int estatusDocumentoID, int explosionID, bool preAutorizada, int usuarioIDPreAutoriza, DateTime fechaPreAutoriza, bool autorizada, int usuarioIDAutoriza, DateTime fechaAutoriza){ 
            return Guardar(new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID, TipoDocumentoID = tipoDocumentoID, SerieID = serieID, SucursalID = sucursalID, Folio = folio, Fecha = fecha, Referencia = referencia, PersonalID = personalID, CentroCostoID = centroCostoID, AreaID = areaID, Concepto = concepto, EstatusDocumentoID = estatusDocumentoID, ExplosionID = explosionID, PreAutorizada = preAutorizada, UsuarioIDPreAutoriza = usuarioIDPreAutoriza, FechaPreAutoriza = fechaPreAutoriza, Autorizada = autorizada, UsuarioIDAutoriza = usuarioIDAutoriza, FechaAutoriza = fechaAutoriza });
        }

        public static Cosmos.Compras.Entidades.RequisicionEncabezado Guardar(Cosmos.Compras.Entidades.RequisicionEncabezado o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RequisicionEncabezado> listado = new List<Cosmos.Compras.Entidades.RequisicionEncabezado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RequisicionEncabezado resultado = new Cosmos.Compras.Entidades.RequisicionEncabezado();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionEncabezado/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RequisicionEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int requisicionEncabezadoID){
            return Eliminar(new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RequisicionEncabezado o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RequisicionEncabezado/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static DataTable ListadoFiltros(Cosmos.Api.Entidades.ConsultaDocumentos o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            DataTable listado=null;

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RequisicionEncabezado/ListadoFiltros", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
