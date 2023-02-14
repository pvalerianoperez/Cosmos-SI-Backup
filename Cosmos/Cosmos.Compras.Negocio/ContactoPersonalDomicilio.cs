
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ContactoPersonalDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> Listado() {            
            List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> lst = new List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio>();            
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalDomicilio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ContactoPersonalDomicilio o = new Cosmos.Compras.Entidades.ContactoPersonalDomicilio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Consultar(int contactoPersonalDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Consultar(Cosmos.Compras.Entidades.ContactoPersonalDomicilio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonalDomicilio_Consultar", o.ContactoPersonalDomicilioID);
            o = new Cosmos.Compras.Entidades.ContactoPersonalDomicilio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Guardar(int modificacionUsuarioID, int contactoPersonalDomicilioID, int contactoPersonalID, int domicilioID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID, ContactoPersonalID = contactoPersonalID, DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonalDomicilio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalDomicilio_Guardar", modificacionUsuarioID, o.ContactoPersonalDomicilioID, o.ContactoPersonalID, o.DomicilioID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ContactoPersonalDomicilioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int contactoPersonalDomicilioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonalDomicilio() { ContactoPersonalDomicilioID = contactoPersonalDomicilioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonalDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonalDomicilio_Eliminar", modificacionUsuarioID, o.ContactoPersonalDomicilioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
