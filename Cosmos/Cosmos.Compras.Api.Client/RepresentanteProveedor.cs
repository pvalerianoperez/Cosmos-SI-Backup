
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class RepresentanteProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedor> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedor/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Consultar(int representanteProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Consultar(Cosmos.Compras.Entidades.RepresentanteProveedor o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedor resultado = new Cosmos.Compras.Entidades.RepresentanteProveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedor/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Guardar(int representanteProveedorID, int proveedorID, int personaID){ 
            return Guardar(new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID, ProveedorID = proveedorID, PersonaID = personaID });
        }

        public static Cosmos.Compras.Entidades.RepresentanteProveedor Guardar(Cosmos.Compras.Entidades.RepresentanteProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedor resultado = new Cosmos.Compras.Entidades.RepresentanteProveedor();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedor/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int representanteProveedorID){
            return Eliminar(new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.RepresentanteProveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedor/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion


        public static Cosmos.Compras.Entidades.RepresentanteProveedor ConsultarCompleto(int proveedorID)
        {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedor() { ProveedorID = proveedorID });
        }

        public static Cosmos.Compras.Entidades.RepresentanteProveedor ConsultarCompleto(Cosmos.Compras.Entidades.RepresentanteProveedor o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.RepresentanteProveedor> listado = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.RepresentanteProveedor resultado = new Cosmos.Compras.Entidades.RepresentanteProveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/RepresentanteProveedor/ConsultarCompleto", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.RepresentanteProveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
    }
}
