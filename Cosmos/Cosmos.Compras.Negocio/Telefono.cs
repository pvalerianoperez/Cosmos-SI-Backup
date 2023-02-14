
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Telefono
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Telefono> Listado() {            
            List<Cosmos.Compras.Entidades.Telefono> lst = new List<Cosmos.Compras.Entidades.Telefono>();            
            DataTable dt = SQLHelper.GetTable("Compras_Telefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Telefono o = new Cosmos.Compras.Entidades.Telefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Telefono Consultar(int telefonoID) {
            return Consultar(new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.Telefono Consultar(Cosmos.Compras.Entidades.Telefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Telefono_Consultar", o.TelefonoID);
            o = new Cosmos.Compras.Entidades.Telefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Telefono Guardar(int modificacionUsuarioID, int telefonoID, string ladaPais, string numeroTelefonico, int tipoTelefonoID, int estatusTelefonoID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID, LadaPais = ladaPais, NumeroTelefonico = numeroTelefonico, TipoTelefonoID = tipoTelefonoID, EstatusTelefonoID = estatusTelefonoID  });
        }
        
        public static Cosmos.Compras.Entidades.Telefono Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Telefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Telefono_Guardar", modificacionUsuarioID, o.TelefonoID, o.LadaPais, o.NumeroTelefonico, o.EstatusTelefonoID, o.TipoTelefonoID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int telefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Telefono() { TelefonoID = telefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Telefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Telefono_Eliminar", modificacionUsuarioID, o.TelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
