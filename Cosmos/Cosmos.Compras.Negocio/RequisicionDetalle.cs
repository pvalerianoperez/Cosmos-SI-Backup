
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class RequisicionDetalle
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RequisicionDetalle> Listado() {            
            List<Cosmos.Compras.Entidades.RequisicionDetalle> lst = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();            
            DataTable dt = SQLHelper.GetTable("Compras_RequisicionDetalle_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RequisicionDetalle o = new Cosmos.Compras.Entidades.RequisicionDetalle();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Consultar(int requisicionDetalleID) {
            return Consultar(new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Consultar(Cosmos.Compras.Entidades.RequisicionDetalle o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RequisicionDetalle_Consultar", o.RequisicionDetalleID);
            o = new Cosmos.Compras.Entidades.RequisicionDetalle();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Guardar(int modificacionUsuarioID, int requisicionDetalleID, int requisicionEncabezadoID, int renglon, int productoID, double cantidad, int unidadID, int almacenID, int conceptoEgresoID, int cuentaContableID, string descripcioAdicional, int estatusDocumentoID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID, RequisicionEncabezadoID = requisicionEncabezadoID, Renglon = renglon, ProductoID = productoID, Cantidad = cantidad, UnidadID = unidadID, AlmacenID = almacenID, ConceptoEgresoID = conceptoEgresoID, CuentaContableID = cuentaContableID, DescripcioAdicional = descripcioAdicional, EstatusDocumentoID = estatusDocumentoID  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionDetalle Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RequisicionDetalle o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RequisicionDetalle_Guardar", modificacionUsuarioID, o.RequisicionDetalleID, o.RequisicionEncabezadoID, o.Renglon, o.ProductoID, o.Cantidad, o.UnidadID, o.AlmacenID, o.ConceptoEgresoID, o.CuentaContableID, o.DescripcioAdicional, o.EstatusDocumentoID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["RequisicionDetalleID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int requisicionDetalleID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RequisicionDetalle() { RequisicionDetalleID = requisicionDetalleID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RequisicionDetalle o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RequisicionDetalle_Eliminar", modificacionUsuarioID, o.RequisicionDetalleID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion
        public static List<Cosmos.Compras.Entidades.RequisicionDetalle> ListadoRequisicionEncabezadoID(int requisicionEncabezadoID)
        {
            List<Cosmos.Compras.Entidades.RequisicionDetalle> lst = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();
            DataTable dt = SQLHelper.GetTable("Compras_RequisicionDetalle_ListadoRequisicionEncabezadoID", requisicionEncabezadoID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RequisicionDetalle o = new Cosmos.Compras.Entidades.RequisicionDetalle();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

    }
}
