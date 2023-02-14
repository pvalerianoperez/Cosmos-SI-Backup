
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProveedorTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorTelefono> Listado() {            
            List<Cosmos.Compras.Entidades.ProveedorTelefono> lst = new List<Cosmos.Compras.Entidades.ProveedorTelefono>();            
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorTelefono o = new Cosmos.Compras.Entidades.ProveedorTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Consultar(int proveedorTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Consultar(Cosmos.Compras.Entidades.ProveedorTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorTelefono_Consultar", o.ProveedorTelefonoID);
            o = new Cosmos.Compras.Entidades.ProveedorTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Guardar(int modificacionUsuarioID, int proveedorTelefonoID, int proveedorID, int telefonoID, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID, ProveedorID = proveedorID, TelefonoID = telefonoID, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorTelefono Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorTelefono_Guardar", modificacionUsuarioID, o.ProveedorTelefonoID, o.ProveedorID, o.TelefonoID, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProveedorTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int proveedorTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorTelefono() { ProveedorTelefonoID = proveedorTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorTelefono_Eliminar", modificacionUsuarioID, o.ProveedorTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
