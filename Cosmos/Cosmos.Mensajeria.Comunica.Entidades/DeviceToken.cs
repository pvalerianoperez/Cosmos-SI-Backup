using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class DeviceToken
    {
        public int DeviceTokenID { get; set; }
        public string Token { get; set; }
        public string OS { get; set; }
        public string VersionOS { get; set; }
        public string VersionApp { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaDeviceToken";

                //DeviceTokenID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DeviceTokenID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.DeviceTokenID = CastHelper.CInt2(dr[nombreColumna]); }

                //DeviceToken
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DeviceToken", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Token = CastHelper.CStr2(dr[nombreColumna]); }

                //OS
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OS", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.OS = CastHelper.CStr2(dr[nombreColumna]); }

                //VersionOS
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VersionOS", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.VersionOS = CastHelper.CStr2(dr[nombreColumna]); }

                //VersionApp
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VersionApp", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.VersionApp = CastHelper.CStr2(dr[nombreColumna]); }

                //Descripcion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //FechaRegistro
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaRegistro", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaRegistro = CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
