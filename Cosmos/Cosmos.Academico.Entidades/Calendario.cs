using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Calendario
    {

        #region Variables

        private string _CalendarioClaveAnterior;
        private string _CalendarioNombreAnterior;
        private string _CalendarioNombreCortoAnterior;

        #endregion

        #region Propiedades

        public int CalendarioID { get; set; }
        public string CalendarioClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CalendarioIDAnterior { get; set; }
        public string CalendarioClaveAnterior { get { return _CalendarioClaveAnterior; } }
        public string CalendarioNombreAnterior { get { return _CalendarioNombreAnterior; } }
        public string CalendarioNombreCortoAnterior { get { return _CalendarioNombreCortoAnterior; } }

        public List<Ciclo> Ciclos { get; set; }

        #endregion

        #region Constructores

        public Calendario()
        {
            CalendarioID = -1;
            CalendarioClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";
            FechaInicio = DateTime.MinValue;
            FechaFinal = DateTime.MinValue;
            CalendarioIDAnterior = -1;

            _CalendarioClaveAnterior = "";
            _CalendarioNombreAnterior = "";
            _CalendarioNombreCortoAnterior = "";

            Ciclos = new List<Ciclo>();
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcCalendario";

                //CalendarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //CalendarioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //FechaInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                //FechaFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaFinal = CastHelper.CDate2(dr[nombreColumna]); }

                //CalendarioIDAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioIDAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioIDAnterior = CastHelper.CInt2(dr[nombreColumna]); }

                //CalendarioClaveAnterior = "";
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioClaveAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioClaveAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                //CalendarioNombreAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioNombreAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioNombreAnterior = CastHelper.CStr2(dr[nombreColumna]); }

                //CalendarioNombreCortoAnterior
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioNombreCortoAnterior", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioNombreCortoAnterior = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
