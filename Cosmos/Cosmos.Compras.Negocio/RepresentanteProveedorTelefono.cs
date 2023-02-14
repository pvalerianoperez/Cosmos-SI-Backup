
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class RepresentanteProveedorTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> Listado() {            
            List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono> lst = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();            
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Consultar(int representanteProveedorTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorTelefono_Consultar", o.RepresentanteProveedorTelefonoID);
            o = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Guardar(int modificacionUsuarioID, int representanteProveedorTelefonoID, int representanteProveedorID, int telefonoID, string extension, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID, RepresentanteProveedorID = representanteProveedorID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorTelefono Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorTelefono_Guardar", modificacionUsuarioID, o.RepresentanteProveedorTelefonoID, o.RepresentanteProveedorID, o.TelefonoID, o.Extension, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["RepresentanteProveedorTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int representanteProveedorTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono() { RepresentanteProveedorTelefonoID = representanteProveedorTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorTelefono_Eliminar", modificacionUsuarioID, o.RepresentanteProveedorTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
