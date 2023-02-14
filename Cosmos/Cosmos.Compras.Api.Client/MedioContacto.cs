
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class MedioContacto
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.MedioContacto> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.MedioContacto> listado = new List<Cosmos.Compras.Entidades.MedioContacto>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/MedioContacto/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.MedioContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.MedioContacto Consultar(int medioContactoID) {
            return Consultar(new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID  });
        }
        
        public static Cosmos.Compras.Entidades.MedioContacto Consultar(Cosmos.Compras.Entidades.MedioContacto o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.MedioContacto> listado = new List<Cosmos.Compras.Entidades.MedioContacto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.MedioContacto resultado = new Cosmos.Compras.Entidades.MedioContacto();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/MedioContacto/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.MedioContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.MedioContacto Guardar(int medioContactoID, int medioContactoClave, string nombre, string nombreCorto){ 
            return Guardar(new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID, MedioContactoClave = medioContactoClave, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.MedioContacto Guardar(Cosmos.Compras.Entidades.MedioContacto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.MedioContacto> listado = new List<Cosmos.Compras.Entidades.MedioContacto>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.MedioContacto resultado = new Cosmos.Compras.Entidades.MedioContacto();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/MedioContacto/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.MedioContacto>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int medioContactoID){
            return Eliminar(new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.MedioContacto o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/MedioContacto/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
