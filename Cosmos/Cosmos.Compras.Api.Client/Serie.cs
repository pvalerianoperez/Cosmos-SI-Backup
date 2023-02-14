
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Serie
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Serie> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Serie> Listado(Cosmos.Compras.Entidades.Sucursal o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Serie> listado = new List<Cosmos.Compras.Entidades.Serie>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Serie/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Serie>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Serie Consultar(int serieID) {
            return Consultar(new Cosmos.Compras.Entidades.Serie() { SerieID = serieID  });
        }
        
        public static Cosmos.Compras.Entidades.Serie Consultar(Cosmos.Compras.Entidades.Serie o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Serie> listado = new List<Cosmos.Compras.Entidades.Serie>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Serie resultado = new Cosmos.Compras.Entidades.Serie();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Serie/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Serie>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Serie Guardar(int serieID, int tipoDocumentoID, string serieClave, int folioInicial, int folioFinal, int ultimoFolio, bool estatus, bool predeterminado, int sucursalID){ 
            return Guardar(new Cosmos.Compras.Entidades.Serie() { SerieID = serieID, TipoDocumentoID = tipoDocumentoID, SerieClave = serieClave, FolioInicial = folioInicial, FolioFinal = folioFinal, UltimoFolio = ultimoFolio, Estatus = estatus, Predeterminado = predeterminado, SucursalID = sucursalID });
        }

        public static Cosmos.Compras.Entidades.Serie Guardar(Cosmos.Compras.Entidades.Serie o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Serie> listado = new List<Cosmos.Compras.Entidades.Serie>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Serie resultado = new Cosmos.Compras.Entidades.Serie();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Serie/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Serie>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int serieID){
            return Eliminar(new Cosmos.Compras.Entidades.Serie() { SerieID = serieID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Serie o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Serie/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
        public static List<Cosmos.Compras.Entidades.Serie> ListadoSerieRequisiciones()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Serie> listado = new List<Cosmos.Compras.Entidades.Serie>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Serie/ListadoSerieRequisiciones", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Serie>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
        public static List<Cosmos.Compras.Entidades.Serie> ListadoSerieTipoDocumento(int tipoDocumentoID, int sucursalID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Entidades.Serie() { TipoDocumentoID = tipoDocumentoID, SucursalID = sucursalID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Serie> listado = new List<Cosmos.Compras.Entidades.Serie>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Serie/ListadoSerieTipoDocumento", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Serie>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
