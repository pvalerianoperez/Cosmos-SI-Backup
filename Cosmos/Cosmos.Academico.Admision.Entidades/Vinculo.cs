using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class Vinculo
    {

        #region Variables
        #endregion

        #region Propiedades

        public int VinculoID { get; set; }
        public string VinculoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Vinculo()
        {
            VinculoID = -1;
            VinculoClave = "";
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
                String prefijoTabla = "AcAdmisionVinculo";

                //VinculoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VinculoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.VinculoID = CastHelper.CInt2(dr[nombreColumna]); }

                //VinculoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VinculoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.VinculoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
