using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Zona
    {

        #region Variables
        #endregion

        #region Propiedades

        public int ZonaID { get; set; }
        public string ZonaClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Zona()
        {
            ZonaID = -1;
            ZonaClave = "";
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
                String prefijoTabla = "AcAdmisionZona";

                //ZonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ZonaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ZonaID = CastHelper.CInt2(dr[nombreColumna]); }

                //ZonaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ZonaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ZonaClave = CastHelper.CStr2(dr[nombreColumna]); }

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
