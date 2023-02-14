
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class UsuarioTipoDocumentoPermiso
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> Listado() {            
            List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso> lst = new List<Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso>();            
            DataTable dt = SQLHelper.GetTable("Compras_UsuarioTipoDocumentoPermiso_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o = new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Consultar(int usuarioTipoDocumentoPermisoID) {
            return Consultar(new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Consultar(Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_UsuarioTipoDocumentoPermiso_Consultar", o.UsuarioTipoDocumentoPermisoID);
            o = new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Guardar(int modificacionUsuarioID, int usuarioTipoDocumentoPermisoID, int usuarioID, int tipoDocumentoID, int centroCostoID, int areaID, int empresaID, int almacenID, int sucursalID, bool preautoriza, decimal preautorizarMonto, bool autoriza, decimal autorizarMonto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID, UsuarioID = usuarioID, TipoDocumentoID = tipoDocumentoID, CentroCostoID = centroCostoID, AreaID = areaID, EmpresaID = empresaID, AlmacenID = almacenID, SucursalID = sucursalID, Preautoriza = preautoriza, PreautorizarMonto = preautorizarMonto, Autoriza = autoriza, AutorizarMonto = autorizarMonto  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UsuarioTipoDocumentoPermiso_Guardar", modificacionUsuarioID, o.UsuarioTipoDocumentoPermisoID, o.UsuarioID, o.TipoDocumentoID, o.CentroCostoID, o.AreaID, o.EmpresaID, o.AlmacenID, o.SucursalID, o.Preautoriza, o.PreautorizarMonto, o.Autoriza, o.AutorizarMonto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["UsuarioTipoDocumentoPermisoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int usuarioTipoDocumentoPermisoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso() { UsuarioTipoDocumentoPermisoID = usuarioTipoDocumentoPermisoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UsuarioTipoDocumentoPermiso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UsuarioTipoDocumentoPermiso_Eliminar", modificacionUsuarioID, o.UsuarioTipoDocumentoPermisoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
