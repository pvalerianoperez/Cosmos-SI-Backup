
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Chat.Entidades
{
    public class PermisoConversacion
    {
        public int PermisoConversacionID { get; set; }
        public string PermisoConversacionNombre { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjChatPermisoConversacion";

                //PermisoConversacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PermisoConversacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PermisoConversacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //PermisoConversacionNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersmisoCoversacionNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PermisoConversacionNombre = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }

    }
}
