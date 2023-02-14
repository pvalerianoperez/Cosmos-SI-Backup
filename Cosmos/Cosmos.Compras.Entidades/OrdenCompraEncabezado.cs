
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class OrdenCompraEncabezado
    {
        public int OrdenCompraEncabezadoID { get; set; }
        public int SucursalID { get; set; }
        public int TipoDocumentoID { get; set; }
        public int SerieID { get; set; }
        public int Folio { get; set; }
        public int ProveedorID { get; set; }
        public int PersonalID { get; set; }
        public DateTime Fecha { get; set; }
        public string Referencia { get; set; }
        public string Concepto { get; set; }
        public int EstatusDocumentoID { get; set; }
        public bool PreAutorizada { get; set; }
        public int UsuarioIDPreAutoriza { get; set; }
        public DateTime FechaPreAutoriza { get; set; }
        public bool Autorizada { get; set; }
        public int UsuarioIDAutoriza { get; set; }
        public DateTime FechaAutoriza { get; set; }
        public int AltaUsuarioID { get; set; }
        public DateTime AltaFecha { get; set; }
        public int ModificacionUsuarioID { get; set; }
        public DateTime ModificacionFecha { get; set; }

        public List<OrdenCompraDetalle> Detalles { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "OrdenCompraEncabezado";

                //OrdenCompraEncabezadoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OrdenCompraEncabezadoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OrdenCompraEncabezadoID = CastHelper.CInt2(dr[nombreColumna]); }

                //SucursalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SucursalID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoDocumentoID = CastHelper.CInt2(dr[nombreColumna]); }

                //SerieID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SerieID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SerieID = CastHelper.CInt2(dr[nombreColumna]); }

                //Folio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Folio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Folio = CastHelper.CInt2(dr[nombreColumna]); }

                //ProveedorID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProveedorID = CastHelper.CInt2(dr[nombreColumna]); }

                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PersonalID = CastHelper.CInt2(dr[nombreColumna]); }

                //Fecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Fecha = CastHelper.CDate2(dr[nombreColumna]); }

                //Referencia
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Referencia", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Referencia = CastHelper.CStr2(dr[nombreColumna]); }

                //Concepto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Concepto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Concepto = CastHelper.CStr2(dr[nombreColumna]); }

                //EstatusDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusDocumentoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EstatusDocumentoID = CastHelper.CInt2(dr[nombreColumna]); }

                //PreAutorizada
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PreAutorizada", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PreAutorizada = CastHelper.CBool2(dr[nombreColumna]); }

                //UsuarioIDPreAutoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioIDPreAutoriza", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioIDPreAutoriza = CastHelper.CInt2(dr[nombreColumna]); }

                //FechaPreAutoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaPreAutoriza", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaPreAutoriza = CastHelper.CDate2(dr[nombreColumna]); }

                //Autorizada
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Autorizada", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Autorizada = CastHelper.CBool2(dr[nombreColumna]); }

                //UsuarioIDAutoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioIDAutoriza", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioIDAutoriza = CastHelper.CInt2(dr[nombreColumna]); }

                //FechaAutoriza
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaAutoriza", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaAutoriza = CastHelper.CDate2(dr[nombreColumna]); }

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
