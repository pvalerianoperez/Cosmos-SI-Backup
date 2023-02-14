
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Calendario.Entidades
{
    public class EventoStatus
    {

        #region Variables

        #endregion

        #region Propiedades

        public int EventoStatusID { get; set; }
        public string EventoStatusClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public EventoStatus()
        {
            EventoStatusID = -1;
            EventoStatusClave = "";
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
                String prefijoTabla = "CalEventoStatus";

                //EventoStatusID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoStatusID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoStatusID = CastHelper.CInt2(dr[nombreColumna]); }

                //EventoStatusClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoStatusClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoStatusClave = CastHelper.CStr2(dr[nombreColumna]); }

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
