
using Cosmos.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Cosmos.Compras.Negocio
{
    public class Producto
    {
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Producto> Listado()
        {
            List<Cosmos.Compras.Entidades.Producto> lst = new List<Cosmos.Compras.Entidades.Producto>();
            DataTable dt = SQLHelper.GetTable("Compras_Producto_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Producto o = new Cosmos.Compras.Entidades.Producto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Compras.Entidades.Producto Consultar(int productoID)
        {
            return Consultar(new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID });
        }

        public static Cosmos.Compras.Entidades.Producto Consultar(Cosmos.Compras.Entidades.Producto o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Producto_Consultar", o.ProductoID);
            o = new Cosmos.Compras.Entidades.Producto();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
                o.Empresas = Negocio.ProductoEmpresa.Listado().Where(x => x.ProductoID == o.ProductoID).ToList();
                o.Almacenes = Negocio.ProductoAlmacen.Listado().Where(x => x.ProductoID == o.ProductoID).ToList();
            }
            return o;
        }

        public static Cosmos.Compras.Entidades.Producto Guardar(int modificacionUsuarioID, int productoID, int marcaID, string nombre, string nombreCorto, int unidadID, int claseProductoID, int tipoProductoID, int nivelProductoID, int metodoCosteoID, bool manejaLotes, bool manejaSeries, decimal reorden, int familiaProductoID, int estatusProductoID)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID, MarcaID = marcaID, Nombre = nombre, NombreCorto = nombreCorto, UnidadID = unidadID, ClaseProductoID = claseProductoID, TipoProductoID = tipoProductoID, NivelProductoID = nivelProductoID, MetodoCosteoID = metodoCosteoID, ManejaLotes = manejaLotes, ManejaSeries = manejaSeries, Reorden = reorden, FamiliaProductoID = familiaProductoID, EstatusProductoID = estatusProductoID });
        }

        public static Cosmos.Compras.Entidades.Producto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Producto o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Producto_Guardar", modificacionUsuarioID, o.ProductoID, o.MarcaID, o.Nombre, o.NombreCorto, o.UnidadID, o.ClaseProductoID, o.TipoProductoID, o.NivelProductoID, o.MetodoCosteoID, o.ManejaLotes, o.ManejaSeries, o.Reorden, o.FamiliaProductoID, o.EstatusProductoID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                int id = CastHelper.CInt2(dr["ProductoID"]);
                
                //EMPRESAS (CODIGOS)
                //dame los detalles que existen actualmente en la base de datos
                List<Cosmos.Compras.Entidades.ProductoEmpresa> lstOriginal = Cosmos.Compras.Negocio.ProductoEmpresa.Listado().Where(x=> x.ProductoID ==id).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ProductoEmpresa detalleOriginal in lstOriginal)
                {
                    if (o.Empresas.Where(x => x.ProductoEmpresaID == detalleOriginal.ProductoEmpresaID).ToList().Count==0)
                    {
                        Cosmos.Compras.Negocio.ProductoEmpresa.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios de los detalles 
                foreach (Cosmos.Compras.Entidades.ProductoEmpresa detalle in o.Empresas)
                {
                    detalle.ProductoID = id;
                    Cosmos.Compras.Negocio.ProductoEmpresa.Guardar(modificacionUsuarioID, detalle);
                }

                //ALMACENES (MAXIMOS Y MINIMOS)
                //dame los detalles que existen actualmente en la base de datos
                List<Cosmos.Compras.Entidades.ProductoAlmacen> lstOriginalAlmacen = Cosmos.Compras.Negocio.ProductoAlmacen.Listado().Where(x => x.ProductoID == id).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ProductoAlmacen detalleOriginal in lstOriginalAlmacen)
                {
                    if (o.Almacenes.Where(x => x.ProductoAlmacenID == detalleOriginal.ProductoAlmacenID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.ProductoAlmacen.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios de los detalles 
                foreach (Cosmos.Compras.Entidades.ProductoAlmacen detalle in o.Almacenes)
                {
                    detalle.ProductoID = id;
                    Cosmos.Compras.Negocio.ProductoAlmacen.Guardar(modificacionUsuarioID, detalle);
                }

                //carga el objeto
                o = Consultar(id);
                o.Empresas = Cosmos.Compras.Negocio.ProductoEmpresa.Listado().Where(x => x.ProductoID == id).ToList();                
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int productoID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Producto() { ProductoID = productoID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Producto o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Producto_Eliminar", modificacionUsuarioID, o.ProductoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static DataTable ListadoFamiliaProducto(int familiaproductoID)
        {
            List<Entidades.Producto> lst = new List<Entidades.Producto>();
            DataTable dt = SQLHelper.GetTable("Compras_Producto_ListadoFamiliaProducto", familiaproductoID);
            //if (dt != null)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        Entidades.Producto o = new Entidades.Producto();
            //        o.Load(dr);
            //        lst.Add(o);
            //    }
            //}
            //return lst;
            return dt;
        }

       

    }
}
