using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Calendario.Entidades
{
    public class CalendarioTipo
    {

        #region Variables

        #endregion

        #region Propiedades

        public int CalendarioTipoID { get; set; }
        public string CalendarioTipoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public CalendarioTipo()
        {
            CalendarioTipoID = -1;
            CalendarioTipoClave = "";
            Nombre = "";
            NombreCorto = "";
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "CalCalendarioTipo";

                //CalendarioTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                //CalendarioTipoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioTipoClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }

        #endregion



    }
}
