
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class PersonalMail
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalMail> Listado() {            
            List<Cosmos.Compras.Entidades.PersonalMail> lst = new List<Cosmos.Compras.Entidades.PersonalMail>();            
            DataTable dt = SQLHelper.GetTable("Compras_PersonalMail_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.PersonalMail o = new Cosmos.Compras.Entidades.PersonalMail();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.PersonalMail Consultar(int personalMailID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalMail Consultar(Cosmos.Compras.Entidades.PersonalMail o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_PersonalMail_Consultar", o.PersonalMailID);
            o = new Cosmos.Compras.Entidades.PersonalMail();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.PersonalMail Guardar(int modificacionUsuarioID, int personalMailID, int personalID, string email, int tipoMailID, bool predeterminado, string comentarios) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID, PersonalID = personalID, Email = email, TipoMailID = tipoMailID, Predeterminado = predeterminado, Comentarios = comentarios  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalMail Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalMail_Guardar", modificacionUsuarioID, o.PersonalMailID, o.PersonalID, o.Email, o.TipoMailID, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PersonalMailID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personalMailID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalMail() { PersonalMailID = personalMailID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalMail_Eliminar", modificacionUsuarioID, o.PersonalMailID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
