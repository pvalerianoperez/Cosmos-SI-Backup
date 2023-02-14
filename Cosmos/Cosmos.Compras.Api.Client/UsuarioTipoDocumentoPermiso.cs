
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class UsuarioTipoDocumentoPermiso
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UsuarioTipoDocumentoPermiso/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Consultar(int usuarioTipoDocumentoPermisoID) {
            return Consultar(new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Consultar(Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso resultado = new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UsuarioTipoDocumentoPermiso/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Guardar(int usuarioTipoDocumentoPermisoID, int usuarioID, int tipoDocumentoID, int centroCostoID, int areaID, int empresaID, int almacenID, int sucursalID, bool preautoriza, decimal preautorizarMonto, bool autoriza, decimal autorizarMonto){ 
            return Guardar(new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID, UsuarioID = usuarioID, TipoDocumentoID = tipoDocumentoID, CentroCostoID = centroCostoID, AreaID = areaID, EmpresaID = empresaID, AlmacenID = almacenID, SucursalID = sucursalID, Preautoriza = preautoriza, PreautorizarMonto = preautorizarMonto, Autoriza = autoriza, AutorizarMonto = autorizarMonto });
        }

        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Guardar(Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso resultado = new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UsuarioTipoDocumentoPermiso/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int usuarioTipoDocumentoPermisoID){
            return Eliminar(new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UsuarioTipoDocumentoPermiso/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
