
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class OrdenCompraDesglose
    {
        public int OrdenCompraDesgloseID { get; set; }
        public int OrdenCompraDetalleID { get; set; }
        public int RenglonID { get; set; }
        public int SucursalID { get; set; }
        public int CentroCostoID { get; set; }
        public int AreaID { get; set; }
        public int AlmacenID { get; set; }
        public int ConceptoEgresoID { get; set; }
        public int CuentaContableID { get; set; }
        public double Cantidad { get; set; }
        public int RequisicionDetalleID { get; set; }
        public int AltaUsuarioID { get; set; }
        public DateTime AltaFecha { get; set; }
        public int ModificacionUsuarioID { get; set; }
        public DateTime ModificacionFecha { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "OrdenCompraDesglose";

                //OrdenCompraDesgloseID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OrdenCompraDesgloseID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OrdenCompraDesgloseID = CastHelper.CInt2(dr[nombreColumna]); }

                //OrdenCompraDetalleID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OrdenCompraDetalleID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OrdenCompraDetalleID = CastHelper.CInt2(dr[nombreColumna]); }

                //RenglonID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RenglonID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RenglonID = CastHelper.CInt2(dr[nombreColumna]); }

                //SucursalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SucursalID = CastHelper.CInt2(dr[nombreColumna]); }

                //CentroCostoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CentroCostoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CentroCostoID = CastHelper.CInt2(dr[nombreColumna]); }

                //AreaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AreaID = CastHelper.CInt2(dr[nombreColumna]); }

                //AlmacenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AlmacenID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AlmacenID = CastHelper.CInt2(dr[nombreColumna]); }

                //ConceptoEgresoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConceptoEgresoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ConceptoEgresoID = CastHelper.CInt2(dr[nombreColumna]); }

                //CuentaContableID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CuentaContableID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CuentaContableID = CastHelper.CInt2(dr[nombreColumna]); }

                //Cantidad
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Cantidad", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Cantidad = CastHelper.CDbl2(dr[nombreColumna]); }

                //RequisicionDetalleID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RequisicionDetalleID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RequisicionDetalleID = CastHelper.CInt2(dr[nombreColumna]); }

                //AltaUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AltaUsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //AltaFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AltaFecha = CastHelper.CDate2(dr[nombreColumna]); }

                //ModificacionUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ModificacionUsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //ModificacionFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ModificacionFecha = CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
