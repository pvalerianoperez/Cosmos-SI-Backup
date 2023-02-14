
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Calendario.Entidades
{
    public class Evento
    {

        #region Variables

        private string _EventoTipoNombre;
        private string _StatusNombre;
        private string _EtiquetaNombre;
        private string _RecursoNombre;

        #endregion

        #region Propiedades

        public int EventoID { get; set; }
        public int EventoTipoID { get; set; }
        public string EventoTipoNombre { get { return _EventoTipoNombre; } }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool TodoElDia { get; set; }
        public string Tema { get; set; }
        public string Locacion { get; set; }
        public string Descripcion { get; set; }
        public int StatusID { get; set; }
        public string StatusNombre { get { return _StatusNombre; } }
        public int EtiquetaID { get; set; }
        public string EtiquetaNombre { get { return _EtiquetaNombre; } }
        public int RecursoID { get; set; }
        public string RecursoNombre { get { return _RecursoNombre; } }
        public string RecursoIDs { get; set; }
        public string RecordatorioInfo { get; set; }
        public string RecurrenciaInfo { get; set; }
        public string CampoPersonalizado1 { get; set; }
        public string CampoPersonalizado2 { get; set; }
        public string CampoPersonalizado3 { get; set; }
        public string CampoPersonalizado4 { get; set; }
        public string CampoPersonalizado5 { get; set; }


        public int CalendarioID { get; set; }

        #endregion

        #region Constructores

        public Evento()
        {
            EventoID = -1;
            EventoTipoID = -1;
            _EventoTipoNombre = "";
            FechaInicio = DateTime.MinValue;
            FechaFinal = DateTime.MinValue;
            TodoElDia = false;
            Tema = "";
            Locacion = "";
            Descripcion = "";
            StatusID = -1;
            _StatusNombre = "";
            EtiquetaID = -1;
            _EtiquetaNombre = "";
            RecursoID = -1;
            _RecursoNombre = "";
            RecursoIDs = "";
            RecordatorioInfo = "";
            RecurrenciaInfo = "";
            CampoPersonalizado1 = "";
            CampoPersonalizado2 = "";
            CampoPersonalizado3 = "";
            CampoPersonalizado4 = "";
            CampoPersonalizado5 = "";


            CalendarioID = -1;
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "CalEvento";

                //EventoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoID = CastHelper.CInt2(dr[nombreColumna]); }

                //EventoTipoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoTipoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EventoTipoID = CastHelper.CInt2(dr[nombreColumna]); }

                // _EventoTipoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EventoTipoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._EventoTipoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //  FechaInicio           SMALLDATETIME NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaInicio", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaInicio = CastHelper.CDate2(dr[nombreColumna]); }

                //  FechaFinal            SMALLDATETIME NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaFinal", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaFinal = CastHelper.CDate2(dr[nombreColumna]); }

                //  TodoElDia             BIT NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TodoElDia", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TodoElDia = CastHelper.CBool2(dr[nombreColumna]); }

                //  Tema                  NVARCHAR(50)  NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Tema", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Tema = CastHelper.CStr2(dr[nombreColumna]); }

                //  Locacion              NVARCHAR(50)  NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Locacion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Locacion = CastHelper.CStr2(dr[nombreColumna]); }

                //  Descripcion           NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Descripcion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Descripcion = CastHelper.CStr2(dr[nombreColumna]); }

                //  StatusID              INT NOT NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "StatusID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.StatusID = CastHelper.CInt2(dr[nombreColumna]); }

                //  StatusNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "StatusNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._StatusNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //  EtiquetaID            INT NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EtiquetaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EtiquetaID = CastHelper.CInt2(dr[nombreColumna]); }

                //  _EtiquetaNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EtiquetaNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._EtiquetaNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //  RecursoID             INT NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecursoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RecursoID = CastHelper.CInt2(dr[nombreColumna]); }

                //  _RecursoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecursoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._RecursoNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //  RecursoIDs            NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecursoIDs", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RecursoIDs = CastHelper.CStr2(dr[nombreColumna]); }

                //  RecordatorioInfo      NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecordatorioInfo", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RecordatorioInfo = CastHelper.CStr2(dr[nombreColumna]); }

                //  RecurrenciaInfo       NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecurrenciaInfo", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RecurrenciaInfo = CastHelper.CStr2(dr[nombreColumna]); }

                //  CampoPersonalizado1 NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CampoPersonalizado1", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CampoPersonalizado1 = CastHelper.CStr2(dr[nombreColumna]); }

                //  CampoPersonalizado2 NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CampoPersonalizado2", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CampoPersonalizado2 = CastHelper.CStr2(dr[nombreColumna]); }

                //  CampoPersonalizado3 NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CampoPersonalizado3", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CampoPersonalizado3 = CastHelper.CStr2(dr[nombreColumna]); }

                //  CampoPersonalizado4 NVARCHAR(MAX) NULL,
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CampoPersonalizado4", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CampoPersonalizado4 = CastHelper.CStr2(dr[nombreColumna]); }

                //  CampoPersonalizado5 NVARCHAR(MAX) NULL, 
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CampoPersonalizado5", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CampoPersonalizado5 = CastHelper.CStr2(dr[nombreColumna]); }

                //CalendarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CalendarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CalendarioID = CastHelper.CInt2(dr[nombreColumna]); }

            }
        }

        #endregion





    }
}
