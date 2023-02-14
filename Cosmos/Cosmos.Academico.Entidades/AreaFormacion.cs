using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class AreaFormacion
    {

        #region Variables

        #endregion

        #region Propiedades

        public int AreaFormacionID { get; set; }
        public string AreaFormacionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public AreaFormacion()
        {
            AreaFormacionID = -1;
            AreaFormacionClave = "";
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
                String prefijoTabla = "AcAreaFormacion";

                //AreaFormacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaFormacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AreaFormacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //AreaFormacionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaFormacionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AreaFormacionClave = CastHelper.CStr2(dr[nombreColumna]); }

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
