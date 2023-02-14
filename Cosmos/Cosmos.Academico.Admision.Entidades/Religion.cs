using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Religion
    {

        #region Variables
        #endregion

        #region Propiedades

        public int ReligionID { get; set; }
        public string ReligionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Religion()
        {
            ReligionID = -1;
            ReligionClave = "";
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
                String prefijoTabla = "AcAdmisionReligion";

                //ReligionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ReligionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ReligionID = CastHelper.CInt2(dr[nombreColumna]); }

                //ReligionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ReligionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ReligionClave = CastHelper.CStr2(dr[nombreColumna]); }

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
