using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class TipoDocumento
    {

        #region Variables
        #endregion

        #region Propiedades

        public int TipoDocumentoID { get; set; }
        public string TipoDocumentoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public TipoDocumento()
        {
            TipoDocumentoID = -1;
            TipoDocumentoClave = "";
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
                String prefijoTabla = "AcTipoDocumento";

                //TipoDocumentoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoDocumentoID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoDocumentoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDocumentoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoDocumentoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
