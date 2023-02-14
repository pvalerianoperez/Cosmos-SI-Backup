
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class DatoFacturacion
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.DatoFacturacion> Listado() {            
            List<Cosmos.Compras.Entidades.DatoFacturacion> lst = new List<Cosmos.Compras.Entidades.DatoFacturacion>();            
            DataTable dt = SQLHelper.GetTable("Compras_DatoFacturacion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.DatoFacturacion o = new Cosmos.Compras.Entidades.DatoFacturacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Consultar(int datoFacturacionID) {
            return Consultar(new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID  });
        }
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Consultar(Cosmos.Compras.Entidades.DatoFacturacion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_DatoFacturacion_Consultar", o.DatoFacturacionID);
            o = new Cosmos.Compras.Entidades.DatoFacturacion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Guardar(int modificacionUsuarioID, int datoFacturacionID, int personaID, string rFC, int domicilioID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID, PersonaID = personaID, RFC = rFC, DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.DatoFacturacion Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.DatoFacturacion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_DatoFacturacion_Guardar", modificacionUsuarioID, o.DatoFacturacionID, o.PersonaID, o.RFC, o.DomicilioID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["DatoFacturacionID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int datoFacturacionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.DatoFacturacion() { DatoFacturacionID = datoFacturacionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.DatoFacturacion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_DatoFacturacion_Eliminar", modificacionUsuarioID, o.DatoFacturacionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
