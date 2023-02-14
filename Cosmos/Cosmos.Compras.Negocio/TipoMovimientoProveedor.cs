
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoMovimientoProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> Listado() {            
            List<Cosmos.Compras.Entidades.TipoMovimientoProveedor> lst = new List<Cosmos.Compras.Entidades.TipoMovimientoProveedor>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoMovimientoProveedor_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoMovimientoProveedor o = new Cosmos.Compras.Entidades.TipoMovimientoProveedor();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Consultar(int tipoMovimientoProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Consultar(Cosmos.Compras.Entidades.TipoMovimientoProveedor o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoMovimientoProveedor_Consultar", o.TipoMovimientoProveedorID);
            o = new Cosmos.Compras.Entidades.TipoMovimientoProveedor();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Guardar(int modificacionUsuarioID, int tipoMovimientoProveedorID, string tipoMovimientoProveedorClave, string nombre, string nombreCorto, int naturalezaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID, TipoMovimientoProveedorClave = tipoMovimientoProveedorClave, Nombre = nombre, NombreCorto = nombreCorto, NaturalezaID = naturalezaID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoMovimientoProveedor Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoMovimientoProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoMovimientoProveedor_Guardar", modificacionUsuarioID, o.TipoMovimientoProveedorID, o.TipoMovimientoProveedorClave, o.Nombre, o.NombreCorto, o.NaturalezaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoMovimientoProveedorID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoMovimientoProveedorID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoMovimientoProveedor() { TipoMovimientoProveedorID = tipoMovimientoProveedorID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoMovimientoProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoMovimientoProveedor_Eliminar", modificacionUsuarioID, o.TipoMovimientoProveedorID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
