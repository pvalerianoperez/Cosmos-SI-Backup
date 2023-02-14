
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class UsuarioEstatusDocumentoPermiso
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> Listado(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o) {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UsuarioEstatusDocumentoPermiso/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Consultar(int usuarioEstatusDocumentoPermisoID) {
            return Consultar(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Consultar(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso resultado = new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UsuarioEstatusDocumentoPermiso/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Guardar(int usuarioEstatusDocumentoPermisoID, int usuarioID, int estatusDocumentoID, int centroCostoID, int areaID, int empresaID, int almacenID, int sucursalID, decimal monto){ 
            return Guardar(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID, UsuarioID = usuarioID, EstatusDocumentoID = estatusDocumentoID, CentroCostoID = centroCostoID, AreaID = areaID, EmpresaID = empresaID, AlmacenID = almacenID, SucursalID = sucursalID, Monto = monto });
        }

        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Guardar(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> listado = new List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso resultado = new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/UsuarioEstatusDocumentoPermiso/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int usuarioEstatusDocumentoPermisoID){
            return Eliminar(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/UsuarioEstatusDocumentoPermiso/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
