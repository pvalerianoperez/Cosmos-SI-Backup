using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Turno
    {

        #region Variables

        #endregion

        #region Propiedades
        public int TurnoID { get; set; }
        public string TurnoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        #endregion

        #region Constructores

        public Turno()
        {
            TurnoID = -1;
            TurnoClave = "";
            Nombre = "";
            NombreCorto = "";
            HoraInicio = DateTime.MinValue;
            HoraFinal = DateTime.MinValue;
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcTurno";

                //TurnoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TurnoID = CastHelper.CInt2(dr[nombreColumna]); }

                //TurnoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TurnoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TurnoClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //HoraInicio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HoraInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.HoraInicio = DateTime.MinValue.AddMinutes(CastHelper.CInt2(dr[nombreColumna])); }

                //HoraFinal
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HoraFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.HoraFinal = DateTime.MinValue.AddMinutes(CastHelper.CInt2(dr[nombreColumna])); }
            }
        }

        #endregion

    }
}
