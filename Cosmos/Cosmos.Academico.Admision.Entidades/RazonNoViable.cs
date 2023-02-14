using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class RazonNoViable
    {
        #region Variables
        #endregion

        #region Propiedades

        public int RazonNoViableID { get; set; }
        public string RazonNoViableClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public RazonNoViable()
        {
            RazonNoViableID = -1;
            RazonNoViableClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcAdmisionRazonNoViable";

                //RazonNoViableID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RazonNoViableID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RazonNoViableID = CastHelper.CInt2(dr[nombreColumna]); }

                //RazonNoViableClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RazonNoViableClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RazonNoViableClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }

        #endregion
    }
}
