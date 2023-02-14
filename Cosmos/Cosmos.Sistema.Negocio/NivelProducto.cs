
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class NivelProducto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.NivelProducto> Listado() {            
            List<Cosmos.Sistema.Entidades.NivelProducto> lst = new List<Cosmos.Sistema.Entidades.NivelProducto>();            
            DataTable dt = SQLHelper.GetTable("Sistema_NivelProducto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.NivelProducto o = new Cosmos.Sistema.Entidades.NivelProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.NivelProducto Consultar(int nivelProductoID) {
            return Consultar(new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID  });
        }
        
        public static Cosmos.Sistema.Entidades.NivelProducto Consultar(Cosmos.Sistema.Entidades.NivelProducto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_NivelProducto_Consultar", o.NivelProductoID);
            o = new Cosmos.Sistema.Entidades.NivelProducto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.NivelProducto Guardar(int modificacionUsuarioID, int nivelProductoID, string nivelProductoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID, NivelProductoClave = nivelProductoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.NivelProducto Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.NivelProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_NivelProducto_Guardar", modificacionUsuarioID, o.NivelProductoID, o.NivelProductoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["NivelProductoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int nivelProductoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.NivelProducto() { NivelProductoID = nivelProductoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.NivelProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_NivelProducto_Eliminar", modificacionUsuarioID, o.NivelProductoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
