
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Chat.Entidades
{
    public class TipoMensaje
    {
        public int TipoMensajeID { get; set; }
        public string TipoNombre { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "SistemaModulo";

                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoMensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoNombre = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}