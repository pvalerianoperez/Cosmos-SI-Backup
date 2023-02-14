using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class PlanEstudioTurno
    {

        #region Variables

        private string _PlanEstudioClave;
        private string _PlanEstudioNombre;
        private string _PlanEstudioNombreCorto;

        private string _TurnoClave;
        private string _TurnoNombre;
        private string _TurnoNombreCorto;

        private string _RvoeClave;
        private string _RvoeNombre;
        private string _RvoeNombreCorto;
        private string _RvoeRegistro;

        #endregion

        #region Propiedades


        public int OfertaAcademicaPlanEstudioTurnoID { get; set; }
        public int OfertaAcademicaID { get; set; }

        public int PlanEstudioID { get; set; }
        public string PlanEstudioClave { get { return _PlanEstudioClave; } }
        public string PlanEstudioNombre { get { return _PlanEstudioNombre; } }
        public string PlanEstudioNombreCorto { get { return _PlanEstudioNombreCorto; } }

        public int TurnoID { get; set; }
        public string TurnoClave { get { return _TurnoClave; } }
        public string TurnoNombre { get { return _TurnoNombre; } }
        public string TurnoNombreCorto { get { return _TurnoNombreCorto; } }


        public int RveoID { get; set; }
        public string RvoeClave { get { return _RvoeClave; } }
        public string RvoeNombre { get { return _RvoeNombre; } }
        public string RvoeNombreCorto { get { return _RvoeNombreCorto; } }
        public string RvoeRegistro { get { return _RvoeRegistro; } }

        #endregion

        #region Constructores

        public PlanEstudioTurno()
        {
            OfertaAcademicaPlanEstudioTurnoID = -1;
            OfertaAcademicaID = -1;

            PlanEstudioID = -1;
            _PlanEstudioClave = "";
            _PlanEstudioNombre = "";
            _PlanEstudioNombreCorto = "";

            TurnoID = -1;
            _TurnoClave = "";
            _TurnoNombre = "";
            _TurnoNombreCorto = "";

            RveoID = -1;
            _RvoeClave = "";
            _RvoeNombre = "";
            _RvoeNombreCorto = "";
            _RvoeRegistro = "";

        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcOfertaAcademicaPlanEstudioTurno";

                // OfertaAcademicaPlanEstudioTurnoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OfertaAcademicaPlanEstudioTurnoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OfertaAcademicaPlanEstudioTurnoID = CastHelper.CInt2(dr[nombreColumna]); }

                // OfertaAcademicaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OfertaAcademicaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OfertaAcademicaID = CastHelper.CInt2(dr[nombreColumna]); }

                // PlanEstudioID
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


                // TurnoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TurnoID = CastHelper.CInt2(dr[nombreColumna]); }

                // TurnoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._TurnoClave = CastHelper.CStr2(dr[nombreColumna]); }

                // TurnoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._TurnoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // TurnoNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._TurnoNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }


                // RveoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RveoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RveoID = CastHelper.CInt2(dr[nombreColumna]); }

                // RvoeClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._RvoeClave = CastHelper.CStr2(dr[nombreColumna]); }

                // RvoeNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._RvoeNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // RvoeNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._RvoeNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // RvoeRegistro
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeRegistro", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._RvoeRegistro = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }

        #endregion

    }
}
