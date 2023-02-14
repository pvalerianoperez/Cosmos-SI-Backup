
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class EstatusProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusProducto> Listado() {            
            List<Cosmos.Sistema.Entidades.EstatusProducto> lst = new List<Cosmos.Sistema.Entidades.EstatusProducto>();            
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusProducto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.EstatusProducto o = new Cosmos.Sistema.Entidades.EstatusProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Consultar(int estatusProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Consultar(Cosmos.Sistema.Entidades.EstatusProducto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusProducto_Consultar", o.EstatusProductoID);
            o = new Cosmos.Sistema.Entidades.EstatusProducto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Guardar(int modificacionUsuarioID, int estatusProductoID, string estatusProductoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID, EstatusProductoClave = estatusProductoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusProducto Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusProducto_Guardar", modificacionUsuarioID, o.EstatusProductoID, o.EstatusProductoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstatusProductoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estatusProductoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusProducto() { EstatusProductoID = estatusProductoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusProducto_Eliminar", modificacionUsuarioID, o.EstatusProductoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
