using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Rvoe
    {

        #region Variables

        #endregion

        #region Propiedades

        public int RvoeID { get; set; }
        public string RvoeClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Registro { get; set; }
        public DateTime FechaExpedicion { get; set; }

        #endregion

        #region Constructores

        public Rvoe()
        {
            RvoeID = -1;
            RvoeClave = "";
            Nombre = "";
            NombreCorto = "";
            Registro = "";
            FechaExpedicion = DateTime.MinValue;
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcRvoe";

                // RvoeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RvoeID = CastHelper.CInt2(dr[nombreColumna]); }

                // RvoeClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RvoeClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RvoeClave = CastHelper.CStr2(dr[nombreColumna]); }

                // Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                // NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                // Registro
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Registro", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Registro = CastHelper.CStr2(dr[nombreColumna]); }

                // FechaExpedicion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaExpedicion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaExpedicion = CastHelper.CDate2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}