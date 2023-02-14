using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class RequisitoProgramaEstudio
    {

        #region Variables

        private string _SalidaTerminalNombre;
        private string _ProgramaEstudioIDPrerrequisitoNombre;
        private string _ProgramaEstudioIDCondicionalORNombre;
        private string _ProgramaEstudioIDSimultaneaNombre;

        #endregion

        #region Propiedades

        public int RequisitoProgramaEstudioID { get; set; }
        public int SalidaTerminalProgramaEstudioID { get; set; }
        public string SalidaTerminalNombre { get { return _SalidaTerminalNombre; } }
        public int ProgramaEstudioID { get; set; }
        public int ProgramaEstudioIDPrerrequisito { get; set; }
        public string ProgramaEstudioIDPrerrequisitoNombre { get { return _ProgramaEstudioIDPrerrequisitoNombre; } }
        public int ProgramaEstudioIDCondicionalOR { get; set; }
        public string ProgramaEstudioIDCondicionalORNombre { get { return _ProgramaEstudioIDCondicionalORNombre; } }
        public int ProgramaEstudioIDSimultanea { get; set; }
        public string ProgramaEstudioIDSimultaneaNombre { get { return _ProgramaEstudioIDSimultaneaNombre; } }
        public int Creditos { get; set; }

        #endregion

        #region Constructores

        public RequisitoProgramaEstudio()
        {
            _SalidaTerminalNombre = "";
            _ProgramaEstudioIDPrerrequisitoNombre = "";
            _ProgramaEstudioIDCondicionalORNombre = "";
            _ProgramaEstudioIDSimultaneaNombre = "";

            RequisitoProgramaEstudioID = -1;
            SalidaTerminalProgramaEstudioID = -1;
            ProgramaEstudioID = -1;
            ProgramaEstudioIDPrerrequisito = -1;
            ProgramaEstudioIDCondicionalOR = -1;
            ProgramaEstudioIDSimultanea = -1;
            Creditos = -1;
        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcRequisitoProgramaEstudio";

                // RequisitoProgramaEstudioID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RequisitoProgramaEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RequisitoProgramaEstudioID = CastHelper.CInt2(dr[nombreColumna]); }

                // SalidaTerminalProgramaEstudioID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SalidaTerminalProgramaEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SalidaTerminalProgramaEstudioID = CastHelper.CInt2(dr[nombreColumna]); }

                // SalidaTerminalNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SalidaTerminalNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SalidaTerminalNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // ---------------------------

                // ProgramaEstudioID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioID = CastHelper.CInt2(dr[nombreColumna]); }

                // ProgramaEstudioIDPrerrequisito ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDPrerrequisito", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioIDPrerrequisito = CastHelper.CInt2(dr[nombreColumna]); }

                // ProgramaEstudioIDPrerrequisitoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDPrerrequisitoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._ProgramaEstudioIDPrerrequisitoNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // ---------------------------

                // ProgramaEstudioIDCondicionalOR ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDCondicionalOR", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioIDCondicionalOR = CastHelper.CInt2(dr[nombreColumna]); }

                // ProgramaEstudioIDCondicionalORNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDCondicionalORNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._ProgramaEstudioIDCondicionalORNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // ---------------------------

                // ProgramaEstudioIDSimultanea ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDSimultanea", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioIDSimultanea = CastHelper.CInt2(dr[nombreColumna]); }

                // ProgramaEstudioIDSimultaneaNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioIDSimultaneaNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._ProgramaEstudioIDSimultaneaNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // ---------------------------

                // Creditos ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Creditos", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Creditos = CastHelper.CInt2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
