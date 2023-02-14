
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Seguridad.Api.Client
{
    public partial class UsuarioOpcionBitacora
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora> listado = new List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioOpcionBitacora/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora Guardar(int usuarioID, DateTime fecha, int empresaID, int moduloID, int opcionID){ 
            return Guardar(new Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora() { UsuarioID = usuarioID, Fecha = fecha, EmpresaID = empresaID, ModuloID = moduloID, OpcionID = opcionID });
        }

        public static Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora Guardar(Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora> listado = new List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora>();

            //resultado del metodo 
            Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora resultado = new Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Seguridad/UsuarioOpcionBitacora/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        #endregion
        
       
    }
}
