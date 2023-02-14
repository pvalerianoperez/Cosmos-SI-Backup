using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class Mensaje
    {
        public int MensajeID { get; set; }
        public int CanalComunicacionID { get; set; }
        public string CanalComunicacion_Nombre { get; }
        public int TipoMensajeID { get; set; }
        public string TipoMensaje_Nombre { get; }
        public int RemitenteID { get; set; }
        public Persona oRemitente { get; set; }
        public int DestinatarioID { get; set; }
        public Persona oDestinatario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaProgramadaEnvio { get; set; }
        public bool ProgramadoParaEnviarse { get; set; }
        public DateTime FechaEnviado { get; set; }
        public DateTime FechaLeido { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string Tema { get; set; }
        public string Body { get; set; }
        public bool RequiereAcuse { get; set; }
        public bool Acusado { get; set; }
        public string Error { get; set; }

        public Mensaje()
        {
            this.ProgramadoParaEnviarse = false;
        }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaMensaje";

                //MensajeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //CanalComunicacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CanalComunicacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CanalComunicacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoMensajeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoMensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //RemmitenteID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RemmitenteID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RemitenteID = CastHelper.CInt2(dr[nombreColumna]); }

                //DestinatarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DestinatarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.DestinatarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //FechaRegistro
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaRegistro", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaRegistro = CastHelper.CDate2(dr[nombreColumna]); }

                //FechaProgramadaEnvio
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaProgramadaEnvio", prefijoTabla);
                if (!nombreColumna.Equals("")) {
                    this.FechaProgramadaEnvio = CastHelper.CDate2(dr[nombreColumna]);
                    this.ProgramadoParaEnviarse = true;
                }

                //FechaEnviado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaEnviado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaEnviado = CastHelper.CDate2(dr[nombreColumna]); }

                //FechaLeido
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaLeido", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaLeido = CastHelper.CDate2(dr[nombreColumna]); }

                //FechaBorrado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaBorrado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaBorrado = CastHelper.CDate2(dr[nombreColumna]); }

                //Tema
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Tema", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Tema = CastHelper.CStr2(dr[nombreColumna]); }

                //Mensaje
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Mensaje", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Body = CastHelper.CStr2(dr[nombreColumna]); }

                //RequiereAcuse
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RequiereAcuse", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RequiereAcuse = CastHelper.CBool2(dr[nombreColumna]); }

                //Acusado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Acusado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Acusado = CastHelper.CBool2(dr[nombreColumna]); }
            }
        }
    }
}

