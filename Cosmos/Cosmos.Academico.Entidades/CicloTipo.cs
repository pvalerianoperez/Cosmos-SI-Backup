using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class CicloTipo
    {

        #region Variables

        #endregion

        #region Propiedades

        public int CicloTipoID { get; set; }
        public string CicloTipoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public CicloTipo()
        {
            CicloTipoID = -1;
            CicloTipoClave = "";
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
                String prefijoTabla = "AcCicloTipo";

                //CicloTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                //CicloTipoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloTipoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloTipoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
