
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ContactoPersonalMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalMail> Listado() {            
            List<Cosmos.Compras.Entidades.ContactoPersonalMail> lst = new List<Cosmos.Compras.Entidades.ContactoPersonalMail>();            
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalMail_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ContactoPersonalMail o = new Cosmos.Compras.Entidades.ContactoPersonalMail();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Consultar(int contactoPersonalMailID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Consultar(Cosmos.Compras.Entidades.ContactoPersonalMail o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalMail_Consultar", o.ContactoPersonalMailID);
            o = new Cosmos.Compras.Entidades.ContactoPersonalMail();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Guardar(int modificacionUsuarioID, int contactoPersonalMailID, int contactoPersonalID, string email, int tipoMail, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID, ContactoPersonalID = contactoPersonalID, Email = email, TipoMail = tipoMail, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalMail Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalMail_Guardar", modificacionUsuarioID, o.ContactoPersonalMailID, o.ContactoPersonalID, o.Email, o.TipoMail, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ContactoPersonalMailID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int contactoPersonalMailID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalMail() { ContactoPersonalMailID = contactoPersonalMailID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalMail_Eliminar", modificacionUsuarioID, o.ContactoPersonalMailID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
