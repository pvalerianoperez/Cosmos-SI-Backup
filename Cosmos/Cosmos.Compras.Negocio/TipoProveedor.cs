
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoProveedor
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoProveedor> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoProveedor() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.TipoProveedor> Listado(Cosmos.Compras.Entidades.TipoProveedor entidad) {            
            List<Cosmos.Compras.Entidades.TipoProveedor> lst = new List<Cosmos.Compras.Entidades.TipoProveedor>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoProveedor_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoProveedor o = new Cosmos.Compras.Entidades.TipoProveedor();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoProveedor Consultar(int tipoProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProveedor Consultar(Cosmos.Compras.Entidades.TipoProveedor o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoProveedor_Consultar", o.TipoProveedorID);
            o = new Cosmos.Compras.Entidades.TipoProveedor();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoProveedor Guardar(int modificacionUsuarioID, int tipoProveedorID, string tipoProveedorClave, string nombre, string nombreCorto, int empresaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID, TipoProveedorClave = tipoProveedorClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProveedor Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoProveedor_Guardar", modificacionUsuarioID, o.TipoProveedorID, o.TipoProveedorClave, o.Nombre, o.NombreCorto, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoProveedorID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoProveedorID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoProveedor() { TipoProveedorID = tipoProveedorID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoProveedor_Eliminar", modificacionUsuarioID, o.TipoProveedorID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
