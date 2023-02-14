using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cosmos.Entidades.Compras
{
    public class ProveedorTelefono: Telefono
    {
        public int ProveedorTelefonoID { get; set; }
        public int ProveedorID { get; set; }
        public bool Predeterminado { get; set; }
        public String Comentarios { get; set; }

        public new void Load(DataRow dr)
        {
            if (dr != null)
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "Telefono");
                if (!nombreColumna.Equals("")) { this.TelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "LadaPais", "Telefono");
                if (!nombreColumna.Equals("")) { this.LadaPais = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroTelefonico", "Telefono");
                if (!nombreColumna.Equals("")) { this.NumeroTelefonico = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", "Telefono");
                if (!nombreColumna.Equals("")) { this.TipoTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorTelefonoID", "ProveedorTelefono");
                if (!nombreColumna.Equals("")) { this.ProveedorTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", "ProveedorTelefono");
                if (!nombreColumna.Equals("")) { this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "ProveedorTelefono");
                if (!nombreColumna.Equals("")) { this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "ProveedorTelefono");
                if (!nombreColumna.Equals("")) { this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
    }
}
