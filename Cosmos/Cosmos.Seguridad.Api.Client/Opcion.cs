
using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class Opcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Opcion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Opcion> listado = new List<Cosmos.Seguridad.Entidades.Opcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.Opcion Consultar(int opcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Opcion Consultar(Cosmos.Seguridad.Entidades.Opcion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Opcion> listado = new List<Cosmos.Seguridad.Entidades.Opcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Opcion resultado = new Cosmos.Seguridad.Entidades.Opcion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Seguridad.Entidades.Opcion Guardar(int opcionID, int moduloID, int padreID, string nombre, string nombreCorto, string recursoWebsite, bool activo, bool protegido, bool popup, bool visibleMenu, string icono, int orden){ 
            return Guardar(new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID, ModuloID = moduloID, PadreID = padreID, Nombre = nombre, NombreCorto = nombreCorto, RecursoWebsite = recursoWebsite, Activo = activo, Protegido = protegido, Popup = popup, VisibleMenu = visibleMenu, Icono = icono, Orden = orden });
        }

        public static Cosmos.Seguridad.Entidades.Opcion Guardar(Cosmos.Seguridad.Entidades.Opcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Opcion> listado = new List<Cosmos.Seguridad.Entidades.Opcion>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.Opcion resultado = new Cosmos.Seguridad.Entidades.Opcion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int opcionID){
            return Eliminar(new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.Opcion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static bool TipoOpcionEliminar(int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID};

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/TipoOpcionEliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static bool TipoOpcionGuardar(int opcionID, int tipoOpcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID};

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/TipoOpcionGuardar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        public static List<Cosmos.Seguridad.Entidades.TipoOpcion> TipoOpcionListado(int opcionID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.TipoOpcion> listado = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/TipoOpcionListado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.TipoOpcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }

        public static List<Cosmos.Seguridad.Entidades.Opcion> ListadoPerfilID(int perfilID)
        {
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.Opcion> listado = new List<Cosmos.Seguridad.Entidades.Opcion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/Opcion/ListadoPerfilID", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }

            //regresa la respuesta
            return listado;
        }
        public static List<Cosmos.Seguridad.Entidades.Opcion> ListadoModuloID(int moduloID)
        {
            List<Cosmos.Seguridad.Entidades.Opcion> listado = Listado();
            return listado.Where(o => o.ModuloID == moduloID).ToList();
        }
    }
}
