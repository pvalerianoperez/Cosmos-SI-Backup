
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class ClaseProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.ClaseProducto> Listado() {            
            List<Cosmos.Sistema.Entidades.ClaseProducto> lst = new List<Cosmos.Sistema.Entidades.ClaseProducto>();            
            DataTable dt = SQLHelper.GetTable("Sistema_ClaseProducto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.ClaseProducto o = new Cosmos.Sistema.Entidades.ClaseProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Consultar(int claseProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Consultar(Cosmos.Sistema.Entidades.ClaseProducto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_ClaseProducto_Consultar", o.ClaseProductoID);
            o = new Cosmos.Sistema.Entidades.ClaseProducto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Guardar(int modificacionUsuarioID, int claseProductoID, string claseProductoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID, ClaseProductoClave = claseProductoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.ClaseProducto Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.ClaseProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_ClaseProducto_Guardar", modificacionUsuarioID, o.ClaseProductoID, o.ClaseProductoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ClaseProductoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int claseProductoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.ClaseProducto() { ClaseProductoID = claseProductoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.ClaseProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_ClaseProducto_Eliminar", modificacionUsuarioID, o.ClaseProductoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
