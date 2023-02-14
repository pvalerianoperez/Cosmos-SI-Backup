using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Ciclo
    {

        #region Variables

        private string _CicloClaveAnterior;
        private string _CicloNombreAnterior;
        private string _CicloNombreCortoAnterior;
        private string _CicloTipoNombre;
        private string _CicloTipoNombreCorto;

        #endregion

        #region Propiedades

        public int CicloID { get; set; }
        public string CicloClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int CalendarioID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CicloIDAnterior { get; set; }
        public string CicloClaveAnterior { get { return _CicloClaveAnterior; } }
        public string CicloNombreAnterior { get { return _CicloNombreAnterior; } }
        public string CicloNombreCortoAnterior { get { return _CicloNombreCortoAnterior; } }
        public int CicloTipoID { get; set; }
        public string CicloTipoNombre { get { return _CicloTipoNombre; } }
        public string CicloTipoNombreCorto { get { return _CicloTipoNombreCorto; } }

        #endregion

        #region Constructores

        public Ciclo()
        {
            CicloID = -1;
            CicloClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";
            CalendarioID = -1;
            FechaInicio = DateTime.MinValue;
            FechaFinal = DateTime.MinValue;
            CicloIDAnterior = -1;
            CicloTipoID = -1;

            _CicloClaveAnterior = "";
            _CicloNombreAnterior = "";
            _CicloNombreCortoAnterior = "";
            _CicloTipoNombre = "";
            _CicloTipoNombreCorto = "";
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcCiclo";

                // CicloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloID = CastHelper.CInt2(dr[nombreColumna]); }

                // CicloClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloClave = CastHelper.CStr2(dr[nombreColumna]); }

                // Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                // NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                // CalendarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioID = CastHelper.CInt2(dr[nombreColumna]); }

                // FechaInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                // FechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaFinal = CastHelper.CDate2(dr[nombreColumna]); }

                // CicloIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloIDAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloIDAnterior = CastHelper.CInt2(dr[nombreColumna]); }

                // CicloClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloClaveAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloClaveAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombreAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombreAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombreCortoAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombreCortoAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                // CicloTipoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloTipoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloTipoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloTipoNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloTipoNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloTipoNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
