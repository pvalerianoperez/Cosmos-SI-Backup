using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Academico.Admision.Api.Client
{
    public class TipoRepresentanteFamilia
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> Listado()
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> listado = new List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoRepresentanteFamilia/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Consultar(int TipoRepresentanteFamiliaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia() { TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Consultar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> listado = new List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia resultado = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoRepresentanteFamilia/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Guardar(int TipoRepresentanteFamiliaID, string TipoRepresentanteFamiliaClave, string nombre, string nombreCorto, string descripcion)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia() { TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID, TipoRepresentanteFamiliaClave = TipoRepresentanteFamiliaClave, Nombre = nombre, NombreCorto = nombreCorto, Descripcion = descripcion });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Guardar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> listado = new List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>();

            //resultado del metodo 
            Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia resultado = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoRepresentanteFamilia/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }

        public static bool Eliminar(int TipoRepresentanteFamiliaID)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia() { TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID });
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Academico/Admision/TipoRepresentanteFamilia/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
    }
}