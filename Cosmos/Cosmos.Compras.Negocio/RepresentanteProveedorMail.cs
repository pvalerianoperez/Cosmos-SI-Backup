
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class RepresentanteProveedorMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> Listado() {            
            List<Cosmos.Compras.Entidades.RepresentanteProveedorMail> lst = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();            
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorMail_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorMail o = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Consultar(int representanteProveedorMailID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorMail o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorMail_Consultar", o.RepresentanteProveedorMailID);
            o = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Guardar(int modificacionUsuarioID, int representanteProveedorMailID, int representanteProveedorID, string mail, int tipoMailID, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID, RepresentanteProveedorID = representanteProveedorID, Mail = mail, TipoMailID = tipoMailID, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorMail Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorMail_Guardar", modificacionUsuarioID, o.RepresentanteProveedorMailID, o.RepresentanteProveedorID, o.Mail, o.TipoMailID, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["RepresentanteProveedorMailID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int representanteProveedorMailID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorMail() { RepresentanteProveedorMailID = representanteProveedorMailID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorMail_Eliminar", modificacionUsuarioID, o.RepresentanteProveedorMailID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
