
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Proveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Proveedor> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Proveedor> listado = new List<Cosmos.Compras.Entidades.Proveedor>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Proveedor/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Proveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Proveedor Consultar(int proveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.Proveedor Consultar(Cosmos.Compras.Entidades.Proveedor o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Proveedor> listado = new List<Cosmos.Compras.Entidades.Proveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Proveedor resultado = new Cosmos.Compras.Entidades.Proveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Proveedor/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Proveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Proveedor Guardar(int proveedorID, int personaID, string nombreCorto, int tipoProveedorID, int giroEmpresaID, int medioContactoID, int vinculoID){ 
            return Guardar(new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID, PersonaID = personaID, NombreCorto = nombreCorto, TipoProveedorID = tipoProveedorID, GiroEmpresaID = giroEmpresaID, MedioContactoID = medioContactoID, VinculoID = vinculoID });
        }

        public static Cosmos.Compras.Entidades.Proveedor Guardar(Cosmos.Compras.Entidades.Proveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Proveedor> listado = new List<Cosmos.Compras.Entidades.Proveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Proveedor resultado = new Cosmos.Compras.Entidades.Proveedor();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Proveedor/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Proveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int proveedorID){
            return Eliminar(new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Proveedor o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Proveedor/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }

        #endregion

        public static Cosmos.Compras.Entidades.Proveedor ConsultarCompleto(int proveedorID)
        {
            return ConsultarCompleto(new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID });
        }

        public static Cosmos.Compras.Entidades.Proveedor ConsultarCompleto(Cosmos.Compras.Entidades.Proveedor o)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Proveedor> listado = new List<Cosmos.Compras.Entidades.Proveedor>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Proveedor resultado = new Cosmos.Compras.Entidades.Proveedor();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Proveedor/ConsultarCompleto", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Proveedor>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
    }
}
