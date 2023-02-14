
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class OrdenCompraDetalle
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.OrdenCompraDetalle> Listado()
        {
            List<Cosmos.Compras.Entidades.OrdenCompraDetalle> lst = new List<Cosmos.Compras.Entidades.OrdenCompraDetalle>();
            DataTable dt = SQLHelper.GetTable("Compras_OrdenCompraDetalle_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.OrdenCompraDetalle o = new Cosmos.Compras.Entidades.OrdenCompraDetalle();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraDetalle Consultar(int ordenCompraDetalleID)
        {
            return Consultar(new Cosmos.Compras.Entidades.OrdenCompraDetalle() { OrdenCompraDetalleID = ordenCompraDetalleID });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraDetalle Consultar(Cosmos.Compras.Entidades.OrdenCompraDetalle o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_OrdenCompraDetalle_Consultar", o.OrdenCompraDetalleID);
            o = new Cosmos.Compras.Entidades.OrdenCompraDetalle();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraDetalle Guardar(int modificacionUsuarioID, int ordenCompraDetalleID, int ordenCompraEncabezadoID, int renglonID, int productoID, double cantidad, int unidadID, double costo, DateTime fechaCompromiso)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.OrdenCompraDetalle() { OrdenCompraDetalleID = ordenCompraDetalleID, OrdenCompraEncabezadoID = ordenCompraEncabezadoID, RenglonID = renglonID, ProductoID = productoID, Cantidad = cantidad, UnidadID = unidadID, Costo = costo, FechaCompromiso = fechaCompromiso });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraDetalle Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.OrdenCompraDetalle o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_OrdenCompraDetalle_Guardar", modificacionUsuarioID, o.OrdenCompraDetalleID, o.OrdenCompraEncabezadoID, o.RenglonID, o.ProductoID, o.Cantidad, o.UnidadID, o.Costo, o.FechaCompromiso);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["OrdenCompraDetalleID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int ordenCompraDetalleID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.OrdenCompraDetalle() { OrdenCompraDetalleID = ordenCompraDetalleID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.OrdenCompraDetalle o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_OrdenCompraDetalle_Eliminar", modificacionUsuarioID, o.OrdenCompraDetalleID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static List<Cosmos.Compras.Entidades.OrdenCompraDetalle> ListadoOrdenCompraEncabezadoID(int ordenCompraEncabezadoID)
        {
            List<Cosmos.Compras.Entidades.OrdenCompraDetalle> lst = new List<Cosmos.Compras.Entidades.OrdenCompraDetalle>();
            DataTable dt = SQLHelper.GetTable("Compras_OrdenCompraDetalle_ListadoOrdenCompraEncabezadoID", ordenCompraEncabezadoID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.OrdenCompraDetalle o = new Cosmos.Compras.Entidades.OrdenCompraDetalle();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }


    }
}
