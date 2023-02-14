
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class TipoOpcionAccion
    {
        public int TipoOpcionID { get; set; }
        public int AccionID { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "SistemaTipoOpcionAccion";

                //TipoOpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoOpcionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoOpcionID = CastHelper.CInt2(dr[nombreColumna]); }

                //AccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AccionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AccionID = CastHelper.CInt2(dr[nombreColumna]); }

            }
        }
    }
}
