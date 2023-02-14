
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoProducto
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoProducto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoProducto() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.TipoProducto> Listado(Cosmos.Compras.Entidades.TipoProducto entidad) {            
            List<Cosmos.Compras.Entidades.TipoProducto> lst = new List<Cosmos.Compras.Entidades.TipoProducto>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoProducto_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoProducto o = new Cosmos.Compras.Entidades.TipoProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoProducto Consultar(int tipoProductoID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProducto Consultar(Cosmos.Compras.Entidades.TipoProducto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoProducto_Consultar", o.TipoProductoID);
            o = new Cosmos.Compras.Entidades.TipoProducto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoProducto Guardar(int modificacionUsuarioID, int tipoProductoID, string tipoProductoClave, string nombre, string nombreCorto, int empresaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID, TipoProductoClave = tipoProductoClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoProducto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoProducto_Guardar", modificacionUsuarioID, o.TipoProductoID, o.TipoProductoClave, o.Nombre, o.NombreCorto, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoProductoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoProductoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoProducto() { TipoProductoID = tipoProductoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoProducto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoProducto_Eliminar", modificacionUsuarioID, o.TipoProductoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
