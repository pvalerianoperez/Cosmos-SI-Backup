using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Escolaridad
    {
        #region Variables
        #endregion

        #region Propiedades

        public int EscolaridadID { get; set; }
        public string EscolaridadClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Escolaridad()
        {
            EscolaridadID = -1;
            EscolaridadClave = "";
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
                String prefijoTabla = "AcAdmisionEscolaridad";

                //EscolaridadID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EscolaridadID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EscolaridadID = CastHelper.CInt2(dr[nombreColumna]); }

                //EscolaridadClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EscolaridadClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EscolaridadClave = CastHelper.CStr2(dr[nombreColumna]); }

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
