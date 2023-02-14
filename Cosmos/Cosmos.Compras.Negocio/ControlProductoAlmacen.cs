
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ControlProductoAlmacen
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ControlProductoAlmacen> Listado() {            
            List<Cosmos.Compras.Entidades.ControlProductoAlmacen> lst = new List<Cosmos.Compras.Entidades.ControlProductoAlmacen>();            
            DataTable dt = SQLHelper.GetTable("Compras_ControlProductoAlmacen_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ControlProductoAlmacen o = new Cosmos.Compras.Entidades.ControlProductoAlmacen();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Consultar(int controlProductoAlmacenID) {
            return Consultar(new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID  });
        }
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Consultar(Cosmos.Compras.Entidades.ControlProductoAlmacen o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ControlProductoAlmacen_Consultar", o.ControlProductoAlmacenID);
            o = new Cosmos.Compras.Entidades.ControlProductoAlmacen();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Guardar(int modificacionUsuarioID, int controlProductoAlmacenID, int productoID, int almacenID, decimal maximo, decimal minimo, decimal reorden, decimal costoPromedio, decimal ultimoCosto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID, ProductoID = productoID, AlmacenID = almacenID, Maximo = maximo, Minimo = minimo, Reorden = reorden, CostoPromedio = costoPromedio, UltimoCosto = ultimoCosto  });
        }
        
        public static Cosmos.Compras.Entidades.ControlProductoAlmacen Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ControlProductoAlmacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ControlProductoAlmacen_Guardar", modificacionUsuarioID, o.ControlProductoAlmacenID, o.ProductoID, o.AlmacenID, o.Maximo, o.Minimo, o.Reorden, o.CostoPromedio, o.UltimoCosto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ControlProductoAlmacenID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int controlProductoAlmacenID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ControlProductoAlmacen() { ControlProductoAlmacenID = controlProductoAlmacenID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ControlProductoAlmacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ControlProductoAlmacen_Eliminar", modificacionUsuarioID, o.ControlProductoAlmacenID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
