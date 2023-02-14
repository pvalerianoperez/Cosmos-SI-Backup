
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class CuentaContable
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.CuentaContable> Listado() {            
            List<Cosmos.Compras.Entidades.CuentaContable> lst = new List<Cosmos.Compras.Entidades.CuentaContable>();            
            DataTable dt = SQLHelper.GetTable("Compras_CuentaContable_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.CuentaContable o = new Cosmos.Compras.Entidades.CuentaContable();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.CuentaContable Consultar(int cuentaContableID) {
            return Consultar(new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID  });
        }
        
        public static Cosmos.Compras.Entidades.CuentaContable Consultar(Cosmos.Compras.Entidades.CuentaContable o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_CuentaContable_Consultar", o.CuentaContableID);
            o = new Cosmos.Compras.Entidades.CuentaContable();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.CuentaContable Guardar(int modificacionUsuarioID, int cuentaContableID, string cuentaContableClave, string nombre, int perteneceCuentaContableID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID, CuentaContableClave = cuentaContableClave, Nombre = nombre, PerteneceCuentaContableID = perteneceCuentaContableID  });
        }
        
        public static Cosmos.Compras.Entidades.CuentaContable Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.CuentaContable o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_CuentaContable_Guardar", modificacionUsuarioID, o.CuentaContableID, o.CuentaContableClave, o.Nombre, o.PerteneceCuentaContableID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["CuentaContableID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int cuentaContableID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.CuentaContable() { CuentaContableID = cuentaContableID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.CuentaContable o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_CuentaContable_Eliminar", modificacionUsuarioID, o.CuentaContableID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
