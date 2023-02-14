using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Api.Client
{
    public class TipoDocumento
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.TipoDocumento> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.TipoDocumento> listado = new List<Cosmos.Academico.Entidades.TipoDocumento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/TipoDocumento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Consultar(int TipoDocumentoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.TipoDocumento() { TipoDocumentoID = TipoDocumentoID });
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Consultar(Cosmos.Academico.Entidades.TipoDocumento o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.TipoDocumento> listado = new List<Cosmos.Academico.Entidades.TipoDocumento>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.TipoDocumento resultado = new Cosmos.Academico.Entidades.TipoDocumento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/TipoDocumento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Guardar(int TipoDocumentoID, string TipoDocumentoClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Entidades.TipoDocumento() { TipoDocumentoID = TipoDocumentoID, TipoDocumentoClave = TipoDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Guardar(Cosmos.Academico.Entidades.TipoDocumento o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.TipoDocumento> listado = new List<Cosmos.Academico.Entidades.TipoDocumento>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.TipoDocumento resultado = new Cosmos.Academico.Entidades.TipoDocumento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/TipoDocumento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.TipoDocumento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int TipoDocumentoID)
        {
            return Eliminar(new Cosmos.Academico.Entidades.TipoDocumento() { TipoDocumentoID = TipoDocumentoID });
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.TipoDocumento o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/TipoDocumento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
