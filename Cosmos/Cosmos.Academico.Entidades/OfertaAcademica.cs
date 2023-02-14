using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class OfertaAcademica
    {

        #region Variables

        private string _CicloClave;
        private string _CicloNombre;
        private string _CicloNombreCorto;
        private DateTime _CicloFechaInicio;
        private DateTime _CicloFechaFinal;

        private string _PlantelClave;
        private string _PlantelNombre;
        private string _PlantelNombreCorto;

        private string _SeccionClave;
        private string _SeccionNombre;
        private string _SeccionNombreCorto;

        #endregion

        #region Propiedades

        public int OfertaAcademicaID { get; set; }

        public int CicloID { get; set; }
        public string CicloClave { get { return _CicloClave; } }
        public string CicloNombre { get { return _CicloNombre; } }
        public string CicloNombreCorto { get { return _CicloNombreCorto; } }
        public DateTime CicloFechaInicio { get { return _CicloFechaInicio; } }
        public DateTime CicloFechaFinal { get { return _CicloFechaFinal; } }

        public int PlantelID { get; set; }
        public string PlantelClave { get { return _PlantelClave; } }
        public string PlantelNombre { get { return _PlantelNombre; } }
        public string PlantelNombreCorto { get { return _PlantelNombreCorto; } }

        public int SeccionID { get; set; }
        public string SeccionClave { get { return _SeccionClave; } }
        public string SeccionNombre { get { return _SeccionNombre; } }
        public string SeccionNombreCorto { get { return _SeccionNombreCorto; } }

        public List<PlanEstudioTurno> PlanEstudioTurnos { get; set; }

        #endregion

        #region Constructores

        public OfertaAcademica()
        {
            OfertaAcademicaID = -1;

            CicloID = -1;
            _CicloClave = "";
            _CicloNombre = "";
            _CicloNombreCorto = "";
            _CicloFechaInicio = DateTime.MinValue;
            _CicloFechaFinal = DateTime.MinValue;

            PlantelID = -1;
            _PlantelClave = "";
            _PlantelNombre = "";
            _PlantelNombreCorto = "";

            SeccionID = -1;
            _SeccionClave = "";
            _SeccionNombre = "";
            _SeccionNombreCorto = "";

            PlanEstudioTurnos = new List<PlanEstudioTurno>();
        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcOfertaAcademica";

                // OfertaAcademicaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OfertaAcademicaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OfertaAcademicaID = CastHelper.CInt2(dr[nombreColumna]); }

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

                // FechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloFechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloFechaFinal = CastHelper.CDate2(dr[nombreColumna]); }



                // PlantelID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlantelID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PlantelID = CastHelper.CInt2(dr[nombreColumna]); }

                // PlantelClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlantelClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlantelClave = CastHelper.CStr2(dr[nombreColumna]); }

                // PlantelNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlantelNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlantelNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // PlantelNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlantelNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PlantelNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }



                // SeccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SeccionID = CastHelper.CInt2(dr[nombreColumna]); }

                // SeccionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionClave = CastHelper.CStr2(dr[nombreColumna]); }

                // SeccionNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //SeccionNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
        #endregion

    }
}
