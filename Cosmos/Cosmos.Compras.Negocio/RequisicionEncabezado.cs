
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using System.Linq;
using Cosmos.Api.Entidades;

namespace Cosmos.Compras.Negocio
{
    public partial class RequisicionEncabezado
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RequisicionEncabezado> Listado() {            
            List<Cosmos.Compras.Entidades.RequisicionEncabezado> lst = new List<Cosmos.Compras.Entidades.RequisicionEncabezado>();            
            DataTable dt = SQLHelper.GetTable("Compras_RequisicionEncabezado_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RequisicionEncabezado o = new Cosmos.Compras.Entidades.RequisicionEncabezado();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(int requisicionEncabezadoID) {
            return Consultar(new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(Cosmos.Compras.Entidades.RequisicionEncabezado o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RequisicionEncabezado_Consultar", o.RequisicionEncabezadoID);
            o = new Cosmos.Compras.Entidades.RequisicionEncabezado();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
                o.Detalles = RequisicionDetalle.ListadoRequisicionEncabezadoID(o.RequisicionEncabezadoID);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Guardar(int modificacionUsuarioID, int requisicionEncabezadoID, int tipoDocumentoID, int serieID, int sucursalID, int folio, DateTime fecha, string referencia, int personalID, int centroCostoID, int areaID, string concepto, int estatusDocumentoID, int explosionID, bool preAutorizada, int usuarioIDPreAutoriza, DateTime fechaPreAutoriza, bool autorizada, int usuarioIDAutoriza, DateTime fechaAutoriza) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID, TipoDocumentoID = tipoDocumentoID, SerieID = serieID, SucursalID = sucursalID, Folio = folio, Fecha = fecha, Referencia = referencia, PersonalID = personalID, CentroCostoID = centroCostoID, AreaID = areaID, Concepto = concepto, EstatusDocumentoID = estatusDocumentoID, ExplosionID = explosionID, PreAutorizada = preAutorizada, UsuarioIDPreAutoriza = usuarioIDPreAutoriza, FechaPreAutoriza = fechaPreAutoriza, Autorizada = autorizada, UsuarioIDAutoriza = usuarioIDAutoriza, FechaAutoriza = fechaAutoriza  });
        }
        
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RequisicionEncabezado o) {
            //consulta la base de datos
            o.TipoDocumentoID = 1;
            DataRow dr = SQLHelper.GetFirstRow("Compras_RequisicionEncabezado_Guardar", modificacionUsuarioID, o.RequisicionEncabezadoID, o.TipoDocumentoID, o.SerieID, o.SucursalID, o.Folio, o.Fecha, o.Referencia, o.PersonalID, o.CentroCostoID, o.AreaID, o.Concepto, o.EstatusDocumentoID, o.ExplosionID, o.PreAutorizada, o.UsuarioIDPreAutoriza, o.FechaPreAutoriza, o.Autorizada, o.UsuarioIDAutoriza, o.FechaAutoriza);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {
                int requisicionEncabezadoID =CastHelper.CInt2(dr["RequisicionEncabezadoID"]);        
                //dame los detalles que existen actualmente en la base de datos
                List<Cosmos.Compras.Entidades.RequisicionDetalle> lstOriginal = Cosmos.Compras.Negocio.RequisicionDetalle.ListadoRequisicionEncabezadoID(requisicionEncabezadoID);
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.RequisicionDetalle detalleOriginal in lstOriginal)
                {
                    if (o.Detalles.Single(x => x.RequisicionDetalleID == detalleOriginal.RequisicionDetalleID) == null) {
                        Cosmos.Compras.Negocio.RequisicionDetalle.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios de los detalles 
                foreach (Cosmos.Compras.Entidades.RequisicionDetalle detalle in o.Detalles)
                {
                    detalle.RequisicionEncabezadoID = requisicionEncabezadoID;
                    Cosmos.Compras.Negocio.RequisicionDetalle.Guardar(modificacionUsuarioID, detalle);
                }
                //carga el objeto
                o = Consultar(requisicionEncabezadoID);
                o.Detalles = Cosmos.Compras.Negocio.RequisicionDetalle.ListadoRequisicionEncabezadoID(requisicionEncabezadoID);                
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int requisicionEncabezadoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RequisicionEncabezado o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RequisicionEncabezado_Eliminar", modificacionUsuarioID, o.RequisicionEncabezadoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion
        public static DataTable ListadoFiltros(ConsultaDocumentos parametros)
        {
            //string s = Cosmos.Framework.StringHelper.IntListToCSV(parametros.EstatusDocumentoID, ",");
            //ejecuta la consulta
            return SQLHelper.GetTable("Compras_Requisicion_ListadoFiltros",
                parametros.EmpresaID,
                parametros.SucursalID,
                parametros.FechaInicial,
                parametros.FechaFinal,
                "");
        }

    }
}
