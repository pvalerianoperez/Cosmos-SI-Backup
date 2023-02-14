
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class FormaPago
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.FormaPago> Listado() {            
            List<Cosmos.Compras.Entidades.FormaPago> lst = new List<Cosmos.Compras.Entidades.FormaPago>();            
            DataTable dt = SQLHelper.GetTable("Compras_FormaPago_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.FormaPago o = new Cosmos.Compras.Entidades.FormaPago();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.FormaPago Consultar(int formaPagoID) {
            return Consultar(new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID  });
        }
        
        public static Cosmos.Compras.Entidades.FormaPago Consultar(Cosmos.Compras.Entidades.FormaPago o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_FormaPago_Consultar", o.FormaPagoID);
            o = new Cosmos.Compras.Entidades.FormaPago();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.FormaPago Guardar(int modificacionUsuarioID, int formaPagoID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.FormaPago Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.FormaPago o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_FormaPago_Guardar", modificacionUsuarioID, o.FormaPagoID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["FormaPagoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int formaPagoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.FormaPago() { FormaPagoID = formaPagoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.FormaPago o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_FormaPago_Eliminar", modificacionUsuarioID, o.FormaPagoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
