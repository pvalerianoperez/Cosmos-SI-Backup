
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class RepresentanteProveedorDomicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> Listado() {            
            List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio> lst = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();            
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorDomicilio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Consultar(int representanteProveedorDomicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Consultar(Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedorDomicilio_Consultar", o.RepresentanteProveedorDomicilioID);
            o = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Guardar(int modificacionUsuarioID, int representanteProveedorDomicilioID, int representanteProveedorID, int domicilioID, string nombre) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID, RepresentanteProveedorID = representanteProveedorID, DomicilioID = domicilioID, Nombre = nombre  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorDomicilio_Guardar", modificacionUsuarioID, o.RepresentanteProveedorDomicilioID, o.RepresentanteProveedorID, o.DomicilioID, o.Nombre);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["RepresentanteProveedorDomicilioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int representanteProveedorDomicilioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio() { RepresentanteProveedorDomicilioID = representanteProveedorDomicilioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedorDomicilio_Eliminar", modificacionUsuarioID, o.RepresentanteProveedorDomicilioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
