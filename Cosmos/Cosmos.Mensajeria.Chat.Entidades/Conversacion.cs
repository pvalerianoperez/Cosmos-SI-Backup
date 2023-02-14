
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Mensajeria.Chat.Entidades
{
    public class Conversacion
    {
        public int ConversacionID { get; set; }
        public string Nombre { get; set; }
        public bool Borrada { get; set; }
        public List<Cosmos.Mensajeria.Chat.Entidades.Participante> Participantes { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjChatConversacion";

                //ConversacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConversacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ConversacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //Borrada
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Borrada", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Borrada = CastHelper.CBool2(dr[nombreColumna]); }

                // MsjChatConversacion_Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MsjChatConversacion_Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
