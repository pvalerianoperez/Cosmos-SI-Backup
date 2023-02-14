using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class TipoRepresentanteFamilia
    {

        #region Variables
        #endregion

        #region Propiedades

        public int TipoRepresentanteFamiliaID { get; set; }
        public string TipoRepresentanteFamiliaClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public TipoRepresentanteFamilia()
        {
            TipoRepresentanteFamiliaID = -1;
            TipoRepresentanteFamiliaClave = "";
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
                String prefijoTabla = "AcAdmisionTipoRepresentanteFamilia";

                //TipoRepresentanteFamiliaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoRepresentanteFamiliaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoRepresentanteFamiliaID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoRepresentanteFamiliaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoRepresentanteFamiliaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoRepresentanteFamiliaClave = CastHelper.CStr2(dr[nombreColumna]); }

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
