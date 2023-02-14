using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Api.Client
{
    public class Documento
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Documento> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.Documento> listado = new List<Cosmos.Academico.Entidades.Documento>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Documento/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.Documento>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Entidades.Documento Consultar(int DocumentoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = DocumentoID });
        }

        public static Cosmos.Academico.Entidades.Documento Consultar(Cosmos.Academico.Entidades.Documento o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.Documento> listado = new List<Cosmos.Academico.Entidades.Documento>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.Documento resultado = new Cosmos.Academico.Entidades.Documento();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Documento/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.Documento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Entidades.Documento Guardar(int DocumentoID, string DocumentoClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = DocumentoID, DocumentoClave = DocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Entidades.Documento Guardar(Cosmos.Academico.Entidades.Documento o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Entidades.Documento> listado = new List<Cosmos.Academico.Entidades.Documento>();

            //resultado del metodo 
            Cosmos.Academico.Entidades.Documento resultado = new Cosmos.Academico.Entidades.Documento();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Documento/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Entidades.Documento>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int DocumentoID)
        {
            return Eliminar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = DocumentoID });
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.Documento o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Documento/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
