
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class CanalComunicacion
    {
        public int CanalComunicacionID { get; set; }
        public string CanalComunicacionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        
        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaCanalComunicacion";

                //CanalComunicacionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CanalComunicacionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CanalComunicacionID = CastHelper.CInt2(dr[nombreColumna]); }

                //CanalComunicacionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CanalComunicacionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CanalComunicacionClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Activo = CastHelper.CBool2(dr[nombreColumna]); }

            }
        }
    }
}
