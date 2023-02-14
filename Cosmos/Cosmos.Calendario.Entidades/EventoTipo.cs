
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Calendario.Entidades
{
    public class EventoTipo
    {

        #region Variables

        #endregion

        #region Propiedades

        public int EventoTipoID { get; set; }
        public string EventoTipoClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion

        #region Constructores

        public EventoTipo()
        {
            EventoTipoID = -1;
            EventoTipoClave = "";
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
                String prefijoTabla = "CalEventoTipo";

                //EventoTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                //EventoTipoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoTipoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoTipoClave = CastHelper.CStr2(dr[nombreColumna]); }

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
