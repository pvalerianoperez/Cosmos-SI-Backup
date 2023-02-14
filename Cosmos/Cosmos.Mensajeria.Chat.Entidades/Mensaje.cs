using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Mensajeria.Chat.Entidades
{
    public class Mensaje
    {
        public int MensajeID { get; set; }

        public int UsuarioID { get; set; }

        public int ConversacionID { get; set; }

        public int TipoMensajeID { get; set; }

        public string ContentMensaje { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Borrado { get; set; }

        public Boolean Consulta_sin_Fecha { get; set; }

        public bool algo { get; set; }

        public void Load(DataRow dr)
        {
            if(dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjChatMensaje";

                //MensajeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.MensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //UsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //ConversacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConversacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ConversacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //TipoMensajeID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMensajeID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.TipoMensajeID = CastHelper.CInt2(dr[nombreColumna]); }

                //Mensaje
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Mensaje", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ContentMensaje = CastHelper.CStr2(dr[nombreColumna]); }

                //Creado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Creado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Creado = CastHelper.CDate2(dr[nombreColumna]); }

                //Borrado
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Borrado", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Borrado = CastHelper.CDate2(dr[nombreColumna]); }
            }
        }
    }
}
