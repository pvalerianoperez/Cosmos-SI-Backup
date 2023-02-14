
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class OrdenCompraEncabezado
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> listado = new List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/OrdenCompraEncabezado/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Consultar(int ordenCompraEncabezadoID)
        {
            return Consultar(new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Consultar(Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> listado = new List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.OrdenCompraEncabezado resultado = new Cosmos.Compras.Entidades.OrdenCompraEncabezado();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/OrdenCompraEncabezado/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Guardar(int ordenCompraEncabezadoID, int sucursalID, int tipoDocumentoID, int serieID, int folio, int proveedorID, int personalID, DateTime fecha, string referencia, string concepto, int estatusDocumentoID, bool preAutorizada, int usuarioIDPreAutoriza, DateTime fechaPreAutoriza, bool autorizada, int usuarioIDAutoriza, DateTime fechaAutoriza)
        {
            return Guardar(new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID, SucursalID = sucursalID, TipoDocumentoID = tipoDocumentoID, SerieID = serieID, Folio = folio, ProveedorID = proveedorID, PersonalID = personalID, Fecha = fecha, Referencia = referencia, Concepto = concepto, EstatusDocumentoID = estatusDocumentoID, PreAutorizada = preAutorizada, UsuarioIDPreAutoriza = usuarioIDPreAutoriza, FechaPreAutoriza = fechaPreAutoriza, Autorizada = autorizada, UsuarioIDAutoriza = usuarioIDAutoriza, FechaAutoriza = fechaAutoriza });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Guardar(Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> listado = new List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.OrdenCompraEncabezado resultado = new Cosmos.Compras.Entidades.OrdenCompraEncabezado();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/OrdenCompraEncabezado/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int ordenCompraEncabezadoID)
        {
            return Eliminar(new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/OrdenCompraEncabezado/Eliminar", solicitud);
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
            DataTable listado = null;

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/OrdenCompraEncabezado/ListadoFiltros", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
