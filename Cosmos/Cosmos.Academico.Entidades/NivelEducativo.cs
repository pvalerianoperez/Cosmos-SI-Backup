using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class NivelEducativo
    {

        #region Variables

        #endregion

        #region Propiedades

        public int NivelEducativoID { get; set; }
        public string NivelEducativoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public NivelEducativo()
        {
            NivelEducativoID = -1;
            NivelEducativoClave = "";
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
                String prefijoTabla = "AcNivelEducativo";

                //NivelEducativoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NivelEducativoID = CastHelper.CInt2(dr[nombreColumna]); }

                //NivelEducativoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NivelEducativoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
