using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{

    public class ProgramaEstudio
    {

        #region Variables

        private string _PlanEstudioClave;
        private string _PlanEstudioNombre;
        private string _PlanEstudioNombreCorto;
        private string _AsignaturaNombre;
        private string _ProgramaEstudioTipoNombre;
        private string _AreaFormacionNombre;
        private int _SeccionID;
        private string _SeccionNombre;
        private string _NivelEducativoNombre;

        #endregion

        #region Propiedades

        public int ProgramaEstudioID { get; set; }
        public int PlanEstudioID { get; set; }
        public string PlanEstudioClave { get { return _PlanEstudioClave; } }
        public string PlanEstudioNombre { get { return _PlanEstudioNombre; } }
        public string PlanEstudioNombreCorto { get { return _PlanEstudioNombreCorto; } }
        public int AsignaturaID { get; set; }
        public string AsignaturaNombre { get { return _AsignaturaNombre; } }
        public string Clave { get; set; }
        public int ProgramaEstudioTipoID { get; set; }
        public string ProgramaEstudioTipoNombre { get { return _ProgramaEstudioTipoNombre; } }
        public int AreaFormacionID { get; set; }
        public string AreaFormacionNombre { get { return _AreaFormacionNombre; } }
        public int HorasTeoria { get; set; }
        public int HorasPractica { get; set; }
        public int HorasTotales { get; set; }
        public int Creditos { get; set; }
        public int DuracionSemanas { get; set; }
        public int Grado { get; set; }
        public int SeccionID { get { return _SeccionID; } }
        public string SeccionNombre { get { return _SeccionNombre; } }
        public string NivelEducativoNombre { get { return _NivelEducativoNombre; } }

        public List<RequisitoProgramaEstudio> Requisitos { get; set; }

        #endregion

        #region Constructores

        public ProgramaEstudio()
        {
            _PlanEstudioClave = "";
            _PlanEstudioNombre = "";
            _PlanEstudioNombreCorto = "";
            _AsignaturaNombre = "";
            _ProgramaEstudioTipoNombre = "";
            _AreaFormacionNombre = "";
            _SeccionID = -1;
            _SeccionNombre = "";
            _NivelEducativoNombre = "";

            ProgramaEstudioID = -1;
            PlanEstudioID = -1;
            AsignaturaID = -1;
            Clave = "";
            ProgramaEstudioTipoID = -1;
            AreaFormacionID = -1;
            HorasTeoria = -1;
            HorasPractica = -1;
            HorasTotales = -1;
            Creditos = -1;
            DuracionSemanas = -1;
            Grado = -1;

            Requisitos = new List<RequisitoProgramaEstudio>();
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcProgramaEstudio";

                // ProgramaEstudioID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioID = CastHelper.CInt2(dr[nombreColumna]); }
                // -----------------------

                // PlanEstudioID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PlanEstudioID = CastHelper.CInt2(dr[nombreColumna]); }

                // PlanEstudioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlanEstudioClave = CastHelper.CStr2(dr[nombreColumna]); }

                // PlanEstudioNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlanEstudioNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // PlanEstudioNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlanEstudioNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // AsignaturaID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AsignaturaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AsignaturaID = CastHelper.CInt2(dr[nombreColumna]); }

                // AsignaturaNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AsignaturaNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._AsignaturaNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // Clave ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Clave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Clave = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // ProgramaEstudioTipoID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ProgramaEstudioTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                // ProgramaEstudioTipoNombre ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProgramaEstudioTipoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._ProgramaEstudioTipoNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // AreaFormacionID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaFormacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AreaFormacionID = CastHelper.CInt2(dr[nombreColumna]); }

                // AreaFormacionNombre ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaFormacionNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._AreaFormacionNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // HorasTeoria ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HorasTeoria", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.HorasTeoria = CastHelper.CInt2(dr[nombreColumna]); }

                // HorasPractica ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HorasPractica", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.HorasPractica = CastHelper.CInt2(dr[nombreColumna]); }

                // HorasTotales ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HorasTotales", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.HorasTotales = CastHelper.CInt2(dr[nombreColumna]); }

                // Creditos ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Creditos", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Creditos = CastHelper.CInt2(dr[nombreColumna]); }
                // -----------------------

                // DuracionSemanas ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DuracionSemanas", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.DuracionSemanas = CastHelper.CInt2(dr[nombreColumna]); }
                // -----------------------

                // Grado ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Grado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Grado = CastHelper.CInt2(dr[nombreColumna]); }
                // -----------------------

                // SeccionID ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionID = CastHelper.CInt2(dr[nombreColumna]); }

                // SeccionNombre ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------

                // _NivelEducativoNombre ----
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._NivelEducativoNombre = CastHelper.CStr2(dr[nombreColumna]); }
                // -----------------------
            }
        }

        #endregion

    }
}
