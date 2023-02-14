using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class ReporteEnvio
    {
        public int ReporteEnvioID { get; set; }
        public int RemitenteID { get; set; }
        public string Tema { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaReporteEnvio";

                //ReporteEnvioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ReporteEnvioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ReporteEnvioID = CastHelper.CInt2(dr[nombreColumna]); }

                //RemitenteID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RemitenteID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RemitenteID = CastHelper.CInt2(dr[nombreColumna]); }

                //Tema
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Tema", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Tema = CastHelper.CStr2(dr[nombreColumna]); }

                //Fecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Fecha = CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
