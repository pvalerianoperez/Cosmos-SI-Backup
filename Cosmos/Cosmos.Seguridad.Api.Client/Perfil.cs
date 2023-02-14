
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Perfil
    {

        #region CRUD
        

        public static List<Cosmos.Seguridad.Entidades.Perfil> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Perfil> listado = new List<Cosmos.Seguridad.Entidades.Perfil>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Perfil>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Perfil Consultar(int perfilID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Perfil Consultar(Cosmos.Seguridad.Entidades.Perfil o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Perfil> listado = new List<Cosmos.Seguridad.Entidades.Perfil>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Perfil resultado = new Cosmos.Seguridad.Entidades.Perfil();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Perfil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Perfil Guardar(int perfilID, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.Perfil Guardar(Cosmos.Seguridad.Entidades.Perfil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Perfil> listado = new List<Cosmos.Seguridad.Entidades.Perfil>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Perfil resultado = new Cosmos.Seguridad.Entidades.Perfil();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Perfil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int perfilID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Perfil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion
        public static bool OpcionEliminar(int perfilID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID} ;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/OpcionEliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static bool OpcionGuardar(int perfilID, int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID};

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/OpcionGuardar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static List<Cosmos.Seguridad.Entidades.Opcion> ConsultarOpciones(int perfilID)
        {
            return ConsultarOpciones(new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID });
        }
        public static List<Cosmos.Seguridad.Entidades.Opcion> ConsultarOpciones(Cosmos.Seguridad.Entidades.Perfil o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Opcion> listado = new List<Cosmos.Seguridad.Entidades.Opcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/ConsultarOpciones", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }


        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> ConsultarAcciones(int perfilID, int opcionID)
        {
            return ConsultarAcciones(new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID });
        }
        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> ConsultarAcciones(Cosmos.Seguridad.Entidades.PerfilOpcion o)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> listado = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Perfil/ConsultarAcciones", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
    }
}
