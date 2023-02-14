
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class PersonalDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.PersonalDomicilio> Listado() {            
            List<Cosmos.Compras.Entidades.PersonalDomicilio> lst = new List<Cosmos.Compras.Entidades.PersonalDomicilio>();            
            DataTable dt = SQLHelper.GetTable("Compras_PersonalDomicilio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.PersonalDomicilio o = new Cosmos.Compras.Entidades.PersonalDomicilio();
                    o.Load(dr);                    
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Consultar(int personalDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Consultar(Cosmos.Compras.Entidades.PersonalDomicilio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_PersonalDomicilio_Consultar", o.PersonalDomicilioID);
            o = new Cosmos.Compras.Entidades.PersonalDomicilio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Guardar(int modificacionUsuarioID, int personalDomicilioID, int personalID, int domicilioID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID, PersonalID = personalID, DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.PersonalDomicilio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalDomicilio o) {
            //primero guarda el domicilio
            Entidades.Domicilio oDomicilio = Domicilio.Guardar(modificacionUsuarioID, o.DomicilioID, o.Calle, o.NumeroExterior, o.NumeroInterior, o.EntreCalle1, o.EntreCalle2, o.CodigoPostal, o.Colonia, o.Coordenadas, o.CiudadID);
            o.DomicilioID = oDomicilio.DomicilioID;
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalDomicilio_Guardar", modificacionUsuarioID, o.PersonalDomicilioID, o.PersonalID, o.DomicilioID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PersonalDomicilioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personalDomicilioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.PersonalDomicilio() { PersonalDomicilioID = personalDomicilioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.PersonalDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_PersonalDomicilio_Eliminar", modificacionUsuarioID, o.PersonalDomicilioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
