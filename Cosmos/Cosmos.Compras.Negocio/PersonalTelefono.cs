
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class PersonalTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalTelefono> Listado() {            
            List<Cosmos.Compras.Entidades.PersonalTelefono> lst = new List<Cosmos.Compras.Entidades.PersonalTelefono>();            
            DataTable dt = SQLHelper.GetTable("Compras_PersonalTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.PersonalTelefono o = new Cosmos.Compras.Entidades.PersonalTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Consultar(int personalTelefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Consultar(Cosmos.Compras.Entidades.PersonalTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_PersonalTelefono_Consultar", o.PersonalTelefonoID);
            o = new Cosmos.Compras.Entidades.PersonalTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Guardar(int modificacionUsuarioID, int personalTelefonoID, int personalID, int telefonoID, string extension, bool predeterminado, string comentarios, int estatusTelefonoID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID, PersonalID = personalID, TelefonoID = telefonoID, Extension = extension, Predeterminado = predeterminado, Comentarios = comentarios, EstatusTelefonoID = estatusTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalTelefono Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalTelefono o) {
            //primero guarda el telefono
            Entidades.Telefono oTelefono =  Telefono.Guardar(modificacionUsuarioID, o.TelefonoID, o.LadaPais, o.NumeroTelefonico, o.EstatusTelefonoID, o.TipoTelefonoID);
            o.TelefonoID = oTelefono.TelefonoID;
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalTelefono_Guardar", modificacionUsuarioID, o.PersonalTelefonoID, o.PersonalID, o.TelefonoID, o.Extension, o.Predeterminado, o.Comentarios);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PersonalTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personalTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalTelefono() { PersonalTelefonoID = personalTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalTelefono_Eliminar", modificacionUsuarioID, o.PersonalTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
