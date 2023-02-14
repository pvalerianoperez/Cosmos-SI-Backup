using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class MotivoCancelacionServicio
    {
        #region Variables
        #endregion

        #region Propiedades

        public int MotivoCancelacionServicioID { get; set; }
        public string MotivoCancelacionServicioClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public MotivoCancelacionServicio()
        {
            MotivoCancelacionServicioID = -1;
            MotivoCancelacionServicioClave = "";
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
                String prefijoTabla = "AcAdmisionMotivoCancelacionServicio";

                //MotivoCancelacionServicioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoCancelacionServicioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoCancelacionServicioID = CastHelper.CInt2(dr[nombreColumna]); }

                //MotivoCancelacionServicioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoCancelacionServicioClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoCancelacionServicioClave = CastHelper.CStr2(dr[nombreColumna]); }

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
