using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Admision.Entidades
{
    public class MotivoInteres
    {
        #region Variables
        #endregion

        #region Propiedades

        public int MotivoInteresID { get; set; }
        public string MotivoInteresClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public MotivoInteres()
        {
            MotivoInteresID = -1;
            MotivoInteresClave = "";
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
                String prefijoTabla = "AcAdmisionMotivoInteres";

                //MotivoInteresID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoInteresID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoInteresID = CastHelper.CInt2(dr[nombreColumna]); }

                //MotivoInteresClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MotivoInteresClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MotivoInteresClave = CastHelper.CStr2(dr[nombreColumna]); }

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
