using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Calendario.Entidades
{
    public class Calendario
    {

        #region Variables

        private string _CalendarioTipoClave;
        private string _CalendarioTipoNombre;
        private string _CalendarioTipoNombreCorto;
        private string _DuenoNombre;
        private string _DuenoApellidoPaterno;
        private string _DuenoApellidoMaterno;

        #endregion

        #region Propiedades

        public int CalendarioID { get; set; }
        public string CalendarioClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int CalendarioTipoID { get; set; }
        public string CalendarioTipoClave { get { return _CalendarioTipoClave; } }
        public string CalendarioTipoNombre { get { return _CalendarioTipoNombre; } }
        public string CalendarioTipoNombreCorto { get { return _CalendarioTipoNombreCorto; } }
        public bool Borrado { get; set; }

        /* Campos para Calendario Personal */
        public int CalendarioPersonaID { get; set; }
        public int PersonaID { get; set; }
        public bool Dueno { get; set; }
        public string DuenoNombre { get { return _DuenoNombre + " " + _DuenoApellidoPaterno + " " + _DuenoApellidoMaterno; } }
        public int CalendarioPermisoInt { get; set; }
        /************************************/

        public List<Cosmos.Calendario.Entidades.Evento> Eventos { get; set; }
        #endregion

        #region Constructores

        public Calendario()
        {

            CalendarioID = -1;
            CalendarioClave = "";
            Nombre = "";
            NombreCorto = "";
            CalendarioTipoID = -1;
            _CalendarioTipoClave = "";
            _CalendarioTipoNombre = "";
            _CalendarioTipoNombreCorto = "";
            Borrado = false;

            /* Campos para Calendario Personal */
            CalendarioPersonaID = -1;
            PersonaID = -1;
            Dueno = false;
            _DuenoNombre = "";
            CalendarioPermisoInt = -1;
            /************************************/

            Eventos = new List<Evento>();
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "CalCalendario";

                //CalendarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //CalendarioClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //CalendarioTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                // CalendarioTipoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioTipoClave = CastHelper.CStr2(dr[nombreColumna]); }

                // CalendarioTipoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioTipoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // CalendarioTipoNombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioTipoNombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._CalendarioTipoNombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Borrado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Borrado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Borrado = CastHelper.CBool2(dr[nombreColumna]); }

                /* Campos para Calendario Personal */

                // CalendarioPersonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioPersonaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioPersonaID = CastHelper.CInt2(dr[nombreColumna]); }

                // PersonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PersonaID = CastHelper.CInt2(dr[nombreColumna]); }

                // Dueno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Dueno", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Dueno = CastHelper.CBool2(dr[nombreColumna]); }

                // _DuenoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "_DuenoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._DuenoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                // _DuenoApellidoPaterno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "_DuenoApellidoPaterno", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._DuenoApellidoPaterno = CastHelper.CStr2(dr[nombreColumna]); }

                // _DuenoApellidoMaterno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "_DuenoApellidoMaterno", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._DuenoApellidoMaterno = CastHelper.CStr2(dr[nombreColumna]); }

                // CalendarioPermisoInt
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioPermisoInt", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioPermisoInt = CastHelper.CInt2(dr[nombreColumna]); }

            }
        }

        #endregion

    }
}
