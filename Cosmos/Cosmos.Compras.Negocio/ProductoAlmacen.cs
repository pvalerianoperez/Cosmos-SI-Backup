
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProductoAlmacen
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProductoAlmacen> Listado() {            
            List<Cosmos.Compras.Entidades.ProductoAlmacen> lst = new List<Cosmos.Compras.Entidades.ProductoAlmacen>();            
            DataTable dt = SQLHelper.GetTable("Compras_ProductoAlmacen_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProductoAlmacen o = new Cosmos.Compras.Entidades.ProductoAlmacen();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Consultar(int productoAlmacenID) {
            return Consultar(new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = productoAlmacenID });
        }
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Consultar(Cosmos.Compras.Entidades.ProductoAlmacen o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProductoAlmacen_Consultar", o.ProductoAlmacenID);
            o = new Cosmos.Compras.Entidades.ProductoAlmacen();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Guardar(int modificacionUsuarioID, int controlProductoAlmacenID, int productoID, int almacenID, decimal maximo, decimal minimo, decimal reorden, decimal costoPromedio, decimal ultimoCosto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = controlProductoAlmacenID, ProductoID = productoID, AlmacenID = almacenID, Maximo = maximo, Minimo = minimo, Reorden = reorden, CostoPromedio = costoPromedio, UltimoCosto = ultimoCosto  });
        }
        
        public static Cosmos.Compras.Entidades.ProductoAlmacen Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProductoAlmacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProductoAlmacen_Guardar", modificacionUsuarioID, o.ProductoAlmacenID, o.ProductoID, o.AlmacenID, o.Maximo, o.Minimo, o.Reorden, o.CostoPromedio, o.UltimoCosto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProductoAlmacenID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int controlProductoAlmacenID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProductoAlmacen() { ProductoAlmacenID = controlProductoAlmacenID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProductoAlmacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProductoAlmacen_Eliminar", modificacionUsuarioID, o.ProductoAlmacenID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
