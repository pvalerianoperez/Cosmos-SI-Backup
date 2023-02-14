using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cosmos.Entidades.Compras
{
    public class ProveedorMail
    {
        public int ProveedorMailID { get; set; }
        public int ProveedorID { get; set; }
        public int TipoMailID { get; set; }
        public String Mail { get; set; }
        public bool Predeterminado { get; set; }
        public String Comentarios { get; set; }

        public void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorMailID", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.ProveedorMailID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMailID", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.TipoMailID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Mail", "ProveedorMail");
                if (!nombreColumna.Equals("")) { this.Mail = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
    }
}
