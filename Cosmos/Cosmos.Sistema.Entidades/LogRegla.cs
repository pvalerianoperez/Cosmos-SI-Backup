using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class LogRegla
    {
        public int SistemaLogReglaID { get; set; }
        public int UserID { get; set; }
        public string TablaNombre { get; set; }
        public Boolean C { get; set; }
        public Boolean R { get; set; }
        public Boolean U { get; set; }
        public Boolean D { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "SistemaLogRegla";

                //SistemaLogReglaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaLogReglaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SistemaLogReglaID = CastHelper.CInt2(dr[nombreColumna]); }

                //UserID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UserID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UserID = CastHelper.CInt2(dr[nombreColumna]); }

                //TablaNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TablaNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TablaNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //C
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "C", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.C = CastHelper.CBool2(dr[nombreColumna]); }

                //R
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "R", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.R = CastHelper.CBool2(dr[nombreColumna]); }

                //U
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "U", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.U = CastHelper.CBool2(dr[nombreColumna]); }

                //D
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "D", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.D = CastHelper.CBool2(dr[nombreColumna]); }

            }
        }
    }
}
