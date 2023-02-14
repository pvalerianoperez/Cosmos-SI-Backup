
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class OrdenCompraDetalle
    {
        public int OrdenCompraDetalleID { get; set; }
        public int OrdenCompraEncabezadoID { get; set; }
        public int RenglonID { get; set; }
        public int ProductoID { get; set; }
        public double Cantidad { get; set; }
        public int UnidadID { get; set; }
        public double Costo { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public int AltaUsuarioID { get; set; }
        public DateTime AltaFecha { get; set; }
        public int ModificacionUsuarioID { get; set; }
        public DateTime ModificacionFecha { get; set; }

        public List<OrdenCompraDesglose> Desglose { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "OrdenCompraDetalle";

                //OrdenCompraDetalleID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OrdenCompraDetalleID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OrdenCompraDetalleID = CastHelper.CInt2(dr[nombreColumna]); }

                //OrdenCompraEncabezadoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OrdenCompraEncabezadoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OrdenCompraEncabezadoID = CastHelper.CInt2(dr[nombreColumna]); }

                //RenglonID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RenglonID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RenglonID = CastHelper.CInt2(dr[nombreColumna]); }

                //ProductoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProductoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProductoID = CastHelper.CInt2(dr[nombreColumna]); }

                //Cantidad
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Cantidad", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Cantidad = CastHelper.CDbl2(dr[nombreColumna]); }

                //UnidadID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UnidadID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UnidadID = CastHelper.CInt2(dr[nombreColumna]); }

                //Costo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Costo", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Costo = CastHelper.CDbl2(dr[nombreColumna]); }

                //FechaCompromiso
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaCompromiso", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaCompromiso = CastHelper.CDate2(dr[nombreColumna]); }

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
