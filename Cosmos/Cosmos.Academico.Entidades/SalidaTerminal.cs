using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class SalidaTerminal
    {

        #region Variables

        private string _PlanEstudioClave;
        private string _PlanEstudioNombre;
        private string _PlanEstudioNombreCorto;

        #endregion

        #region Propiedades

        public int SalidaTerminalID { get; set; }
        public string SalidaTerminalClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        public int PlanEstudioID { get; set; }
        public string PlanEstudioClave { get { return _PlanEstudioClave; } }
        public string PlanEstudioNombre { get { return _PlanEstudioNombre; } }
        public string PlanEstudioNombreCorto { get { return _PlanEstudioNombreCorto; } }

        public bool Activa { get; set; }

        public List<ProgramaEstudio> ProgramasEstudio { get; set; }

        #endregion

        #region Constructores

        public SalidaTerminal()
        {
            SalidaTerminalID = -1;
            SalidaTerminalClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";

            PlanEstudioID = -1;
            _PlanEstudioClave = "";
            _PlanEstudioNombre = "";
            _PlanEstudioNombreCorto = "";
            Activa = false;

            ProgramasEstudio = new List<ProgramaEstudio>();
        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcSalidaTerminal";

                //SalidaTerminalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SalidaTerminalID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SalidaTerminalID = CastHelper.CInt2(dr[nombreColumna]); }

                //SalidaTerminalClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SalidaTerminalClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SalidaTerminalClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //PlanEstudioID
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

                //Activa
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activa", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Activa = CastHelper.CBool2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}