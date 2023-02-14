using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class ListaDistribucion
    {
        public int ListaDistribucionID { get; set; }
        public string ListaDistribucionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activa { get; set; }
        public List<Cosmos.Mensajeria.Comunica.Entidades.Persona> Personas { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna = "";
                String prefijoTabla = "MsjComunicaListaDistribucionClave";

                //ListaDistribucionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ListaDistribucionID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ListaDistribucionID = CastHelper.CInt2(dr[nombreColumna]); }

                //ListaDistribucionClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ListaDistribucionClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ListaDistribucionClave = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCorto = CastHelper.CStr2(dr[nombreColumna]); }

                //Activa
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activa", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Activa = CastHelper.CBool2(dr[nombreColumna]); }

            }
        }
    }
}
