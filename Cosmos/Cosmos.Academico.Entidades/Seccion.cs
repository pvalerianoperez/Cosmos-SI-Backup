using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Academico.Entidades
{
    public class Seccion
    {

        #region Variables

        private string _NivelEducativoNombre;

        #endregion

        #region Propiedades

        public int SeccionID { get; set; }
        public string SeccionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int NivelEducativoID { get; set; }
        public string NivelEducativoNombre { get { return _NivelEducativoNombre; } }

        public List<PlanEstudio> PlanesEstudio;

        #endregion

        #region Constructores

        public Seccion()
        {
            _NivelEducativoNombre = "";

            SeccionID = -1;
            SeccionClave = "";
            Nombre = "";
            NombreCorto = "";
            Descripcion = "";
            NivelEducativoID = -1;

            PlanesEstudio = new List<PlanEstudio>();
        }

        #endregion

        #region Load

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "AcSeccion";

                //SeccionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SeccionID = CastHelper.CInt2(dr[nombreColumna]); }

                //SeccionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SeccionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SeccionClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //NivelEducativoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NivelEducativoID = CastHelper.CInt2(dr[nombreColumna]); }

                //NivelEducativoNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NivelEducativoNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this._NivelEducativoNombre = CastHelper.CStr2(dr[nombreColumna]); }
            }
        }


        #endregion

    }
}
