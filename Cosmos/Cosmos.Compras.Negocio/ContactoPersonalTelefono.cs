
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ContactoPersonalTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> Listado() {            
            List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> lst = new List<Cosmos.Compras.Entidades.ContactoPersonalTelefono>();            
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ContactoPersonalTelefono o = new Cosmos.Compras.Entidades.ContactoPersonalTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Consultar(int contactoPersonalTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Consultar(Cosmos.Compras.Entidades.ContactoPersonalTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalTelefono_Consultar", o.ContactoPersonalTelefonoID);
            o = new Cosmos.Compras.Entidades.ContactoPersonalTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Guardar(int modificacionUsuarioID, int contactoPersonalTelefonoID, int contactoPersonalID, int telefonoID, string extension, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID, ContactoPersonalID = contactoPersonalID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalTelefono Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalTelefono_Guardar", modificacionUsuarioID, o.ContactoPersonalTelefonoID, o.ContactoPersonalID, o.TelefonoID, o.Extension, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ContactoPersonalTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int contactoPersonalTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalTelefono() { ContactoPersonalTelefonoID = contactoPersonalTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalTelefono_Eliminar", modificacionUsuarioID, o.ContactoPersonalTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
