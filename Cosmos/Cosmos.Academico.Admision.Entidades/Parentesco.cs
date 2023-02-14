using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Parentesco
    {

        #region Variables
        #endregion

        #region Propiedades

        public int ParentescoID { get; set; }
        public string ParentescoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Parentesco()
        {
            ParentescoID = -1;
            ParentescoClave = "";
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
                String prefijoTabla = "AcAdmisionParentesco";

                //ParentescoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ParentescoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ParentescoID = CastHelper.CInt2(dr[nombreColumna]); }

                //ParentescoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ParentescoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ParentescoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
