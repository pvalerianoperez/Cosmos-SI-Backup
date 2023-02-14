using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{

    public class DiaAsueto
    {

        #region Variables

        private string _CicloClave;
        private string _CicloNombre;
        private string _CicloNombreCorto;

        #endregion

        #region Propiedades

        public int DiaAsuetoID { get; set; }
        public string DiaAsuetoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int CicloID { get; set; }
        public string CicloClave { get { return _CicloClave; } }
        public string CicloNombre { get { return _CicloNombre; } }
        public string CicloNombreCorto { get { return _CicloNombreCorto; } }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        #endregion

        #region Constructores

        public DiaAsueto()
        {
            DiaAsuetoID = -1;
            DiaAsuetoClave = "";
            Nombre = "";
            CicloID = -1;

            _CicloClave = "";
            _CicloNombre = "";
            _CicloNombreCorto = "";

            Descripcion = "";
            Fecha = DateTime.MinValue;
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcDiaAsueto";

                //DiaAsuetoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DiaAsuetoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.DiaAsuetoID = CastHelper.CInt2(dr[nombreColumna]); }

                //DiaAsuetoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DiaAsuetoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.DiaAsuetoClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //CicloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CicloID = CastHelper.CInt2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //Fecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Fecha = CastHelper.CDate2(dr[nombreColumna]); }

                //CicloClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloClave = CastHelper.CStr2(dr[nombreColumna]); }

                //CicloNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //CicloNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CicloNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CicloNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }

        #endregion

    }
}
