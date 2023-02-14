
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProveedorSucursal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorSucursal> Listado() {            
            List<Cosmos.Compras.Entidades.ProveedorSucursal> lst = new List<Cosmos.Compras.Entidades.ProveedorSucursal>();            
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorSucursal_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorSucursal o = new Cosmos.Compras.Entidades.ProveedorSucursal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Consultar(int proveedorSucursalID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Consultar(Cosmos.Compras.Entidades.ProveedorSucursal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorSucursal_Consultar", o.ProveedorSucursalID);
            o = new Cosmos.Compras.Entidades.ProveedorSucursal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Guardar(int modificacionUsuarioID, int proveedorSucursalID, int sucursalID, int proveedorID, string proveedorClave, int estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID, SucursalID = sucursalID, ProveedorID = proveedorID, ProveedorClave = proveedorClave, Estatus = estatus  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorSucursal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorSucursal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorSucursal_Guardar", modificacionUsuarioID, o.ProveedorSucursalID, o.SucursalID, o.ProveedorID, o.ProveedorClave, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProveedorSucursalID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int proveedorSucursalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorSucursal() { ProveedorSucursalID = proveedorSucursalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorSucursal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorSucursal_Eliminar", modificacionUsuarioID, o.ProveedorSucursalID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
