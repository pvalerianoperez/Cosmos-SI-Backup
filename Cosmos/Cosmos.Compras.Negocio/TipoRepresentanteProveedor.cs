
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoRepresentanteProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> Listado() {            
            List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor> lst = new List<Cosmos.Compras.Entidades.TipoRepresentanteProveedor>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoRepresentanteProveedor_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoRepresentanteProveedor o = new Cosmos.Compras.Entidades.TipoRepresentanteProveedor();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Consultar(int tipoRepresentanteProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Consultar(Cosmos.Compras.Entidades.TipoRepresentanteProveedor o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoRepresentanteProveedor_Consultar", o.TipoRepresentanteProveedorID);
            o = new Cosmos.Compras.Entidades.TipoRepresentanteProveedor();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Guardar(int modificacionUsuarioID, int tipoRepresentanteProveedorID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.TipoRepresentanteProveedor Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoRepresentanteProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoRepresentanteProveedor_Guardar", modificacionUsuarioID, o.TipoRepresentanteProveedorID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoRepresentanteProveedorID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoRepresentanteProveedorID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoRepresentanteProveedor() { TipoRepresentanteProveedorID = tipoRepresentanteProveedorID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoRepresentanteProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoRepresentanteProveedor_Eliminar", modificacionUsuarioID, o.TipoRepresentanteProveedorID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
