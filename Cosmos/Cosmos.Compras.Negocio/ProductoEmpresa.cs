
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ProductoEmpresa
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ProductoEmpresa> Listado() {            
            List<Cosmos.Compras.Entidades.ProductoEmpresa> lst = new List<Cosmos.Compras.Entidades.ProductoEmpresa>();            
            DataTable dt = SQLHelper.GetTable("Compras_ProductoEmpresa_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ProductoEmpresa o = new Cosmos.Compras.Entidades.ProductoEmpresa();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Consultar(int productoEmpresaID) {
            return Consultar(new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID  });
        }
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Consultar(Cosmos.Compras.Entidades.ProductoEmpresa o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ProductoEmpresa_Consultar", o.ProductoEmpresaID);
            o = new Cosmos.Compras.Entidades.ProductoEmpresa();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Guardar(int modificacionUsuarioID, int productoEmpresaID, int empresaID, int productoID, string productoClave) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID, EmpresaID = empresaID, ProductoID = productoID, ProductoClave = productoClave  });
        }
        
        public static Cosmos.Compras.Entidades.ProductoEmpresa Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProductoEmpresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProductoEmpresa_Guardar", modificacionUsuarioID, o.ProductoEmpresaID, o.EmpresaID, o.ProductoID, o.ProductoClave);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProductoEmpresaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int productoEmpresaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ProductoEmpresa() { ProductoEmpresaID = productoEmpresaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ProductoEmpresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ProductoEmpresa_Eliminar", modificacionUsuarioID, o.ProductoEmpresaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
