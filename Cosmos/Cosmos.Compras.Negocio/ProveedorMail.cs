
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProveedorMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorMail> Listado() {            
            List<Cosmos.Compras.Entidades.ProveedorMail> lst = new List<Cosmos.Compras.Entidades.ProveedorMail>();            
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorMail_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorMail o = new Cosmos.Compras.Entidades.ProveedorMail();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ProveedorMail Consultar(int proveedorMailID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorMail Consultar(Cosmos.Compras.Entidades.ProveedorMail o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorMail_Consultar", o.ProveedorMailID);
            o = new Cosmos.Compras.Entidades.ProveedorMail();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ProveedorMail Guardar(int modificacionUsuarioID, int proveedorMailID, int proveedorID, int tipoMailID, string mail, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID, ProveedorID = proveedorID, TipoMailID = tipoMailID, Mail = mail, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.ProveedorMail Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorMail_Guardar", modificacionUsuarioID, o.ProveedorMailID, o.ProveedorID, o.TipoMailID, o.Mail, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProveedorMailID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int proveedorMailID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorMail() { ProveedorMailID = proveedorMailID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorMail_Eliminar", modificacionUsuarioID, o.ProveedorMailID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
