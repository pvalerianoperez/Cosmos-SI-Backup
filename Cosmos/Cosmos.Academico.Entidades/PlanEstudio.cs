using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{

    public class PlanEstudio
    {

        #region Variables

        private string _SeccionClave;
        private string _SeccionNombre;
        private string _SeccionNombreCorto;

        private string _NivelEducativoClave;
        private string _NivelEducativoNombre;
        private string _NivelEducativoNombreCorto;

        #endregion

        #region Propiedades

        public int PlanEstudioID { get; set; }
        public string PlanEstudioClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int SeccionID { get; set; }

        public string SeccionClave { get { return _SeccionClave; } }
        public string SeccionNombre { get { return _SeccionNombre; } }
        public string SeccionNombreCorto { get { return _SeccionNombreCorto; } }

        public string NivelEducativoClave { get { return _NivelEducativoClave; } }
        public string NivelEducativoNombre { get { return _NivelEducativoNombre; } }
        public string NivelEducativoNombreCorto { get { return _NivelEducativoNombreCorto; } }

        public Decimal CalificacionMinimaAprobatoria { get; set; }
        public int CreditosParaAcreditar { get; set; }
        public List<ProgramaEstudio> ProgramasEstudio { get; set; }
        public List<SalidaTerminal> SalidasTerminal { get; set; }

        #endregion

        #region Constructores

        public PlanEstudio()
        {

            PlanEstudioID = -1;
            PlanEstudioClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";
            SeccionID = -1;

            _SeccionClave = "";
            _SeccionNombre = "";
            _SeccionNombreCorto = "";

            _NivelEducativoClave = "";
            _NivelEducativoNombre = "";
            _NivelEducativoNombreCorto = "";

            CalificacionMinimaAprobatoria = -1;
            CreditosParaAcreditar = -1;

            ProgramasEstudio = new List<ProgramaEstudio>();
            SalidasTerminal = new List<SalidaTerminal>();
        }


        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcPlanEstudio";

                //PlanEstudioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PlanEstudioID = CastHelper.CInt2(dr[nombreColumna]); }

                //PlanEstudioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PlanEstudioClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PlanEstudioClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //SeccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SeccionID = CastHelper.CInt2(dr[nombreColumna]); }

                //SeccionNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionClave = CastHelper.CStr2(dr[nombreColumna]); }

                //SeccionNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //SeccionNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._SeccionNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //NivelEducativoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._NivelEducativoClave = CastHelper.CStr2(dr[nombreColumna]); }

                //NivelEducativoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._NivelEducativoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NivelEducativoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._NivelEducativoNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }


                // CalificacionMinimaAprobatoria
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalificacionMinimaAprobatoria", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalificacionMinimaAprobatoria = CastHelper.CDecimal2(dr[nombreColumna]); }

                // CreditosParaAcreditar
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CreditosParaAcreditar", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CreditosParaAcreditar = CastHelper.CInt2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
