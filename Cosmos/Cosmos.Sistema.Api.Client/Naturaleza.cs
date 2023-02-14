
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class Naturaleza
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Naturaleza> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Naturaleza> listado = new List<Cosmos.Sistema.Entidades.Naturaleza>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Naturaleza/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Naturaleza>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.Naturaleza Consultar(int NaturalezaID) {
            return Consultar(new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID  });
        }
        
        public static Cosmos.Sistema.Entidades.Naturaleza Consultar(Cosmos.Sistema.Entidades.Naturaleza o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Naturaleza> listado = new List<Cosmos.Sistema.Entidades.Naturaleza>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Naturaleza resultado = new Cosmos.Sistema.Entidades.Naturaleza();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Naturaleza/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Naturaleza>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.Naturaleza Guardar(int NaturalezaID, string NaturalezaClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID, NaturalezaClave = NaturalezaClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.Naturaleza Guardar(Cosmos.Sistema.Entidades.Naturaleza o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Naturaleza> listado = new List<Cosmos.Sistema.Entidades.Naturaleza>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Naturaleza resultado = new Cosmos.Sistema.Entidades.Naturaleza();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Naturaleza/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Naturaleza>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int NaturalezaID){
            return Eliminar(new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.Naturaleza o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Naturaleza/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
