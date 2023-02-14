
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;


namespace Cosmos.Academico.Entidades
{
    public class InstitucionEducativa
    {

        #region Variables

        #endregion

        #region Propiedades
        public int InstitucionEducativaID { get; set; }
        public string InstitucionEducativaClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string ExtraTexto1 { get; set; }
        public string ExtraTexto2 { get; set; }
        public string ExtraTexto3 { get; set; }
        public DateTime ExtraFecha1 { get; set; }
        public DateTime ExtraFecha2 { get; set; }
        public Decimal ExtraDecimal1 { get; set; }
        public Decimal ExtraDecimal2 { get; set; }
        public Decimal ExtraDecimal3 { get; set; }
        #endregion

        #region Constructores

        public InstitucionEducativa()
        {
            InstitucionEducativaID = -1;
            InstitucionEducativaClave = "";
            Nombre = "";
            NombreCorto = "";
            ExtraTexto1 = "";
            ExtraTexto2 = "";
            ExtraTexto3 = "";
            ExtraFecha1 = DateTime.MinValue;
            ExtraFecha2 = DateTime.MinValue;
            ExtraDecimal1 = -1;
            ExtraDecimal2 = -1;
            ExtraDecimal3 = -1;
        }

        #endregion

        #region Load
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcInstitucionEducativa";

                //BancoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "InstitucionEducativaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.InstitucionEducativaID = CastHelper.CInt2(dr[nombreColumna]); }

                //BancoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "InstitucionEducativaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.InstitucionEducativaClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //ExtraTexto1
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraTexto1", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraTexto1 = CastHelper.CStr2(dr[nombreColumna]); }

                //ExtraTexto2
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraTexto2", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraTexto2 = CastHelper.CStr2(dr[nombreColumna]); }

                //ExtraTexto3
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraTexto3", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraTexto3 = CastHelper.CStr2(dr[nombreColumna]); }

                //ExtraFecha1
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraFecha1", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraFecha1 = CastHelper.CDate2(dr[nombreColumna]); }

                //ExtraFecha2
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraFecha2", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraFecha2 = CastHelper.CDate2(dr[nombreColumna]); }

                //ExtraDecimal1
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraDecimal1", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraDecimal1 = CastHelper.CDecimal2(dr[nombreColumna]); }

                //ExtraDecimal2
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraDecimal2", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraDecimal2 = CastHelper.CDecimal2(dr[nombreColumna]); }

                //ExtraDecimal3
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ExtraDecimal3", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ExtraDecimal3 = CastHelper.CDecimal2(dr[nombreColumna]); }

            }
        }

        #endregion

    }
}
