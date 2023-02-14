
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Class1
    {

        #region Variables

        #endregion

        #region Propiedades

        #endregion

        #region Constructores

        #endregion

        #region Load

        #endregion


        public int Class1ID { get; set; }
        public string Class1Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "Banco";

                //Class1ID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Class1ID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Class1ID = CastHelper.CInt2(dr[nombreColumna]); }

                //Class1Clave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Class1Clave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Class1Clave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //UsuarioAlta
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioAlta", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioAlta = CastHelper.CStr2(dr[nombreColumna]); }

                //FechaAlta
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaAlta", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaAlta = CastHelper.CDate2(dr[nombreColumna]); }

                //UsuarioModificacion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioModificacion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.UsuarioModificacion = CastHelper.CStr2(dr[nombreColumna]); }

                //FechaModificacion
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaModificacion", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaModificacion = CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
