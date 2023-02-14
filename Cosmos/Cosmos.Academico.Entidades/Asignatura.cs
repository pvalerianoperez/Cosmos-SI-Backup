using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Asignatura
    {

        #region Variables

        #endregion

        #region Propiedades

        public int AsignaturaID { get; set; }
        public string Nombre { get; set; }

        #endregion

        #region Constructores

        public Asignatura()
        {
            AsignaturaID = -1;
            Nombre = "";
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcAsignatura";

                //AsignaturaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AsignaturaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AsignaturaID = CastHelper.CInt2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
        #endregion

    }
}
