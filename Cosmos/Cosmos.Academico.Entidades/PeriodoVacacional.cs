using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class PeriodoVacacional
    {

        #region Variables

        private string _CicloClave;
        private string _CicloNombre;
        private string _CicloNombreCorto;
        private DateTime _CicloFechaInicio;
        private DateTime _CicloFechaFinal;

        #endregion

        #region Propiedades

        public int PeriodoVacacionalID { get; set; }
        public string PeriodoVacacionalClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        public int CicloID { get; set; }
        public string CicloClave { get { return _CicloClave; } }
        public string CicloNombre { get { return _CicloNombre; } }
        public string CicloNombreCorto { get { return _CicloNombreCorto; } }
        public DateTime CicloFechaInicio { get { return _CicloFechaInicio; } }
        public DateTime CicloFechaFinal { get { return _CicloFechaFinal; } }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        #endregion

        #region Constructores

        public PeriodoVacacional()
        {
            PeriodoVacacionalID = -1;
            PeriodoVacacionalClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";

            CicloID = -1;
            _CicloClave = "";
            _CicloNombre = "";
            _CicloNombreCorto = "";
            _CicloFechaInicio = DateTime.MinValue;
            _CicloFechaFinal = DateTime.MinValue;

            FechaInicio = DateTime.MinValue;
            FechaFinal = DateTime.MinValue;
        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcPeriodoVacacional";

                // PeriodoVacacionalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoVacacionalID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoVacacionalID = CastHelper.CInt2(dr[nombreColumna]); }

                // PeriodoVacacionalClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoVacacionalClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoVacacionalClave = CastHelper.CStr2(dr[nombreColumna]); }

                // Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                // NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloID = CastHelper.CInt2(dr[nombreColumna]); }

                // CicloClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloClave = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloFechaInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloFechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloFechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                // CicloFechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloFechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloFechaFinal = CastHelper.CDate2(dr[nombreColumna]); }

                // FechaInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                // FechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaFinal = CastHelper.CDate2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
