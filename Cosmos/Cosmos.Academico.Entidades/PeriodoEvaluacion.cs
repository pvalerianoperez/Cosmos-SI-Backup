using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class PeriodoEvaluacion
    {

        #region Variables

        private string _CicloClave;
        private string _CicloNombre;
        private string _CicloNombreCorto;

        private string _PeriodoEvaluacionClaveAnterior;
        private string _PeriodoEvaluacionNombreAnterior;
        private string _PeriodoEvaluacionNombreCortoAnterior;

        #endregion

        #region Propiedades


        public int PeriodoEvaluacionID { get; set; }
        public string PeriodoEvaluacionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        public int PeriodoEvaluacionIDAnterior { get; set; }
        public string PeriodoEvaluacionClaveAnterior { get { return _PeriodoEvaluacionClaveAnterior; } }
        public string PeriodoEvaluacionNombreAnterior { get { return _PeriodoEvaluacionNombreAnterior; } }
        public string PeriodoEvaluacionNombreCortoAnterior { get { return _PeriodoEvaluacionNombreCortoAnterior; } }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public int CicloID { get; set; }
        public string CicloClave { get { return _CicloClave; } }
        public string CicloNombre { get { return _CicloNombre; } }
        public string CicloNombreCorto { get { return _CicloNombreCorto; } }


        #endregion

        #region Constructores

        public PeriodoEvaluacion()
        {
            PeriodoEvaluacionID = -1;
            PeriodoEvaluacionClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion =  "";

            PeriodoEvaluacionIDAnterior = -1;
            _PeriodoEvaluacionClaveAnterior = "";
            _PeriodoEvaluacionNombreAnterior = "";
            _PeriodoEvaluacionNombreCortoAnterior = "";

            FechaInicio = DateTime.MinValue;
            FechaFinal = DateTime.MinValue;
            CicloID = -1;

            _CicloClave = "";
            _CicloNombre = "";
            _CicloNombreCorto = "";
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcPeriodoEvaluacion";

                //PeriodoEvaluacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoEvaluacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //PeriodoEvaluacionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoEvaluacionClave = CastHelper.CStr2(dr[nombreColumna]); }

                // Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                // NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }



                // PeriodoEvaluacionIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionIDAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoEvaluacionIDAnterior = CastHelper.CInt2(dr[nombreColumna]); }

                // PeriodoEvaluacionIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionClaveAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PeriodoEvaluacionClaveAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                // PeriodoEvaluacionIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionNombreAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PeriodoEvaluacionNombreAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                // PeriodoEvaluacionIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PeriodoEvaluacionNombreCortoAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._PeriodoEvaluacionNombreCortoAnterior = CastHelper.CStr2(dr[nombreColumna]); }



                // FechaInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                // FechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaFinal = CastHelper.CDate2(dr[nombreColumna]); }



                // CicloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PeriodoEvaluacionID = CastHelper.CInt2(dr[nombreColumna]); }

                // CicloClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloClave = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // CicloNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }



        #endregion

    }
}
