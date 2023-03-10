using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Idioma
    {
        #region Variables
        #endregion

        #region Propiedades

        public int IdiomaID { get; set; }
        public string IdiomaClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Idioma()
        {
            IdiomaID = -1;
            IdiomaClave = "";
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
                String prefijoTabla = "AcAdmisionIdioma";

                //IdiomaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "IdiomaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.IdiomaID = CastHelper.CInt2(dr[nombreColumna]); }

                //IdiomaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "IdiomaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.IdiomaClave = CastHelper.CStr2(dr[nombreColumna]); }

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
