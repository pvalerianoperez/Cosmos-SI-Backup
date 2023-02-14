
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Sistema.Api.Client
{
    public partial class Sexo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Sexo> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Sexo> listado = new List<Cosmos.Sistema.Entidades.Sexo>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Sexo/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Sexo>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Sistema.Entidades.Sexo Consultar(int sexoID) {
            return Consultar(new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID  });
        }
        
        public static Cosmos.Sistema.Entidades.Sexo Consultar(Cosmos.Sistema.Entidades.Sexo o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Sexo> listado = new List<Cosmos.Sistema.Entidades.Sexo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Sexo resultado = new Cosmos.Sistema.Entidades.Sexo();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Sexo/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Sexo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Sistema.Entidades.Sexo Guardar(int sexoID, string sexoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID, SexoClave = sexoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Sistema.Entidades.Sexo Guardar(Cosmos.Sistema.Entidades.Sexo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Sistema.Entidades.Sexo> listado = new List<Cosmos.Sistema.Entidades.Sexo>();

            //resultado del metodo 
            Cosmos.Sistema.Entidades.Sexo resultado = new Cosmos.Sistema.Entidades.Sexo();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Sistema/Sexo/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Sistema.Entidades.Sexo>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int sexoID){
            return Eliminar(new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID });
        }

        public static bool Eliminar(Cosmos.Sistema.Entidades.Sexo o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Sistema/Sexo/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
