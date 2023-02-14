
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class EstadoCivil
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstadoCivil> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstadoCivil> listado = new List<Cosmos.Compras.Entidades.EstadoCivil>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstadoCivil/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstadoCivil>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.EstadoCivil Consultar(int estadoCivilID) {
            return Consultar(new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID  });
        }
        
        public static Cosmos.Compras.Entidades.EstadoCivil Consultar(Cosmos.Compras.Entidades.EstadoCivil o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstadoCivil> listado = new List<Cosmos.Compras.Entidades.EstadoCivil>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstadoCivil resultado = new Cosmos.Compras.Entidades.EstadoCivil();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstadoCivil/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstadoCivil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.EstadoCivil Guardar(int estadoCivilID, string estadoCivilClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID, EstadoCivilClave = estadoCivilClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.EstadoCivil Guardar(Cosmos.Compras.Entidades.EstadoCivil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.EstadoCivil> listado = new List<Cosmos.Compras.Entidades.EstadoCivil>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.EstadoCivil resultado = new Cosmos.Compras.Entidades.EstadoCivil();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/EstadoCivil/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.EstadoCivil>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int estadoCivilID){
            return Eliminar(new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.EstadoCivil o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/EstadoCivil/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
