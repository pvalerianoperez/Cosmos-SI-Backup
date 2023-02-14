using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class TipoMensaje
    {
        public int TipoMensajeID { get; set; }
        public string TipoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaTipoMensaje";

                //TipoMensajeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoMensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
