
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Profesion
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Profesion> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Profesion> listado = new List<Cosmos.Compras.Entidades.Profesion>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Profesion/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Profesion>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Profesion Consultar(int profesionID) {
            return Consultar(new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID  });
        }
        
        public static Cosmos.Compras.Entidades.Profesion Consultar(Cosmos.Compras.Entidades.Profesion o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Profesion> listado = new List<Cosmos.Compras.Entidades.Profesion>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Profesion resultado = new Cosmos.Compras.Entidades.Profesion();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Profesion/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Profesion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Profesion Guardar(int profesionID, string profesionClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID, ProfesionClave = profesionClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.Profesion Guardar(Cosmos.Compras.Entidades.Profesion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Profesion> listado = new List<Cosmos.Compras.Entidades.Profesion>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Profesion resultado = new Cosmos.Compras.Entidades.Profesion();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Profesion/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Profesion>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int profesionID){
            return Eliminar(new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Profesion o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Profesion/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
