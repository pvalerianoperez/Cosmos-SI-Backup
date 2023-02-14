using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class UltimaConsultaMensaje
    {
        public int UsuarioID { get; set; }
        public DateTime FechaUltimaConsulta { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaUltimaConsultaMensaje";

                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //FechaUltimaConsulta
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaUltimaConsulta", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaUltimaConsulta = CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
