
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cosmos.Api.Entidades;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class OrdenCompraEncabezado
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> Listado()
        {
            List<Cosmos.Compras.Entidades.OrdenCompraEncabezado> lst = new List<Cosmos.Compras.Entidades.OrdenCompraEncabezado>();
            DataTable dt = SQLHelper.GetTable("Compras_OrdenCompraEncabezado_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.OrdenCompraEncabezado o = new Cosmos.Compras.Entidades.OrdenCompraEncabezado();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Consultar(int ordenCompraEncabezadoID)
        {
            return Consultar(new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Consultar(Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_OrdenCompraEncabezado_Consultar", o.OrdenCompraEncabezadoID);
            o = new Cosmos.Compras.Entidades.OrdenCompraEncabezado();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
                o.Detalles = OrdenCompraDetalle.ListadoOrdenCompraEncabezadoID(o.OrdenCompraEncabezadoID);
            }
            return o;
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Guardar(int modificacionUsuarioID, int ordenCompraEncabezadoID, int sucursalID, int tipoDocumentoID, int serieID, int folio, int proveedorID, int personalID, DateTime fecha, string referencia, string concepto, int estatusDocumentoID, bool preAutorizada, int usuarioIDPreAutoriza, DateTime fechaPreAutoriza, bool autorizada, int usuarioIDAutoriza, DateTime fechaAutoriza)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID, SucursalID = sucursalID, TipoDocumentoID = tipoDocumentoID, SerieID = serieID, Folio = folio, ProveedorID = proveedorID, PersonalID = personalID, Fecha = fecha, Referencia = referencia, Concepto = concepto, EstatusDocumentoID = estatusDocumentoID, PreAutorizada = preAutorizada, UsuarioIDPreAutoriza = usuarioIDPreAutoriza, FechaPreAutoriza = fechaPreAutoriza, Autorizada = autorizada, UsuarioIDAutoriza = usuarioIDAutoriza, FechaAutoriza = fechaAutoriza });
        }

        public static Cosmos.Compras.Entidades.OrdenCompraEncabezado Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {           
            //consulta la base de datos
            o.TipoDocumentoID = 3;
            DataRow dr = SQLHelper.GetFirstRow("Compras_OrdenCompraEncabezado_Guardar", modificacionUsuarioID, o.OrdenCompraEncabezadoID, o.SucursalID, o.TipoDocumentoID, o.SerieID, o.Folio, o.ProveedorID, o.PersonalID, o.Fecha, o.Referencia, o.Concepto, o.EstatusDocumentoID, o.PreAutorizada, o.UsuarioIDPreAutoriza, o.FechaPreAutoriza, o.Autorizada, o.UsuarioIDAutoriza, o.FechaAutoriza);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                int ordenCompraEncabezadoID = CastHelper.CInt2(dr["OrdenCompraEncabezadoID"]);
                //dame los detalles que existen actualmente en la base de datos
                List<Cosmos.Compras.Entidades.OrdenCompraDetalle> lstOriginal = Cosmos.Compras.Negocio.OrdenCompraDetalle.ListadoOrdenCompraEncabezadoID(ordenCompraEncabezadoID);
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.OrdenCompraDetalle detalleOriginal in lstOriginal)
                {
                    if (o.Detalles.Single(x => x.OrdenCompraDetalleID == detalleOriginal.OrdenCompraDetalleID) == null)
                    {
                        Cosmos.Compras.Negocio.OrdenCompraDetalle.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios de los detalles 
                foreach (Cosmos.Compras.Entidades.OrdenCompraDetalle detalle in o.Detalles)
                {
                    detalle.OrdenCompraEncabezadoID = ordenCompraEncabezadoID;
                    Cosmos.Compras.Negocio.OrdenCompraDetalle.Guardar(modificacionUsuarioID, detalle);
                }
                //carga el objeto
                o = Consultar(ordenCompraEncabezadoID);
                o.Detalles = Cosmos.Compras.Negocio.OrdenCompraDetalle.ListadoOrdenCompraEncabezadoID(ordenCompraEncabezadoID);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int ordenCompraEncabezadoID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.OrdenCompraEncabezado() { OrdenCompraEncabezadoID = ordenCompraEncabezadoID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.OrdenCompraEncabezado o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_OrdenCompraEncabezado_Eliminar", modificacionUsuarioID, o.OrdenCompraEncabezadoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static DataTable ListadoFiltros(ConsultaDocumentos parametros)
        {            
            //ejecuta la consulta
            return SQLHelper.GetTable("Compras_OrdenCompra_ListadoFiltros",
                parametros.EmpresaID,
                parametros.SucursalID,
                parametros.FechaInicial,
                parametros.FechaFinal,
                "");
        }
    }
}
