
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class UsuarioEstatusDocumentoPermiso
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> Listado(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso entidad) {            
            List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso> lst = new List<Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso>();            
            DataTable dt = SQLHelper.GetTable("Compras_UsuarioEstatusDocumentoPermiso_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o = new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Consultar(int usuarioEstatusDocumentoPermisoID) {
            return Consultar(new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Consultar(Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_UsuarioEstatusDocumentoPermiso_Consultar", o.UsuarioEstatusDocumentoPermisoID);
            o = new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Guardar(int modificacionUsuarioID, int usuarioEstatusDocumentoPermisoID, int usuarioID, int estatusDocumentoID, int centroCostoID, int areaID, int empresaID, int almacenID, int sucursalID, decimal monto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID, UsuarioID = usuarioID, EstatusDocumentoID = estatusDocumentoID, CentroCostoID = centroCostoID, AreaID = areaID, EmpresaID = empresaID, AlmacenID = almacenID, SucursalID = sucursalID, Monto = monto  });
        }
        
        public static Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UsuarioEstatusDocumentoPermiso_Guardar", modificacionUsuarioID, o.UsuarioEstatusDocumentoPermisoID, o.UsuarioID, o.EstatusDocumentoID, o.CentroCostoID, o.AreaID, o.EmpresaID, o.AlmacenID, o.SucursalID, o.Monto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["UsuarioEstatusDocumentoPermisoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int usuarioEstatusDocumentoPermisoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso() { UsuarioEstatusDocumentoPermisoID = usuarioEstatusDocumentoPermisoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UsuarioEstatusDocumentoPermiso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UsuarioEstatusDocumentoPermiso_Eliminar", modificacionUsuarioID, o.UsuarioEstatusDocumentoPermisoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
