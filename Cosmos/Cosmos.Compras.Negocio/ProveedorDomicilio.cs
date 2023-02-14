
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProveedorDomicilio
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProveedorDomicilio> Listado() {
            List<Cosmos.Compras.Entidades.ProveedorDomicilio> lst = new List<Cosmos.Compras.Entidades.ProveedorDomicilio>();
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorDomicilio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorDomicilio o = new Cosmos.Compras.Entidades.ProveedorDomicilio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Compras.Entidades.ProveedorDomicilio Consultar(int proveedorDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID });
        }

        public static Cosmos.Compras.Entidades.ProveedorDomicilio Consultar(Cosmos.Compras.Entidades.ProveedorDomicilio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProveedorDomicilio_Consultar", o.ProveedorDomicilioID);
            o = new Cosmos.Compras.Entidades.ProveedorDomicilio();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Compras.Entidades.ProveedorDomicilio Guardar(int modificacionUsuarioID, int proveedorDomicilioID, int proveedorID, int domicilioID, string comentario, bool predeterminado, int tipoDonicilioID) { 
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID, ProveedorID = proveedorID, DomicilioID = domicilioID, Comentario = comentario, Predeterminado = predeterminado, TipoDomicilioID = tipoDonicilioID });
        }
                public static Cosmos.Compras.Entidades.ProveedorDomicilio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorDomicilio_Guardar",  o.ProveedorDomicilioID, o.ProveedorID, o.DomicilioID, o.Comentario, o.Predeterminado, o.TipoDomicilioID );
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProveedorDomicilioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int proveedorDomicilioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProveedorDomicilio() { ProveedorDomicilioID = proveedorDomicilioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProveedorDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProveedorDomicilio_Eliminar", modificacionUsuarioID, o.ProveedorDomicilioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
