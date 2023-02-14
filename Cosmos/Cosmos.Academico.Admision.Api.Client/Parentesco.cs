using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class Parentesco
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Parentesco> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Parentesco> listado = new List<Cosmos.Academico.Admision.Entidades.Parentesco>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Parentesco/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Parentesco>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Consultar(int ParentescoID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Parentesco() { ParentescoID = ParentescoID });
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Consultar(Cosmos.Academico.Admision.Entidades.Parentesco o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Parentesco> listado = new List<Cosmos.Academico.Admision.Entidades.Parentesco>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Parentesco resultado = new Cosmos.Academico.Admision.Entidades.Parentesco();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Parentesco/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Parentesco>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Guardar(int ParentescoID, string ParentescoClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Parentesco() { ParentescoID = ParentescoID, ParentescoClave = ParentescoClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Guardar(Cosmos.Academico.Admision.Entidades.Parentesco o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.Parentesco> listado = new List<Cosmos.Academico.Admision.Entidades.Parentesco>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.Parentesco resultado = new Cosmos.Academico.Admision.Entidades.Parentesco();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/Parentesco/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.Parentesco>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int ParentescoID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Parentesco() { ParentescoID = ParentescoID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Parentesco o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/Parentesco/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}
