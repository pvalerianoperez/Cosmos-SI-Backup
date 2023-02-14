using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class MotivoBaja
    {
        #region Variables
        #endregion

        #region Propiedades

        public int MotivoBajaID { get; set; }
        public string MotivoBajaClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public MotivoBaja()
        {
            MotivoBajaID = -1;
            MotivoBajaClave = "";
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
                String prefijoTabla = "AcAdmisionMotivoBaja";

                //MotivoBajaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoBajaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoBajaID = CastHelper.CInt2(dr[nombreColumna]); }

                //MotivoBajaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoBajaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoBajaClave = CastHelper.CStr2(dr[nombreColumna]); }

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
