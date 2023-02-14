
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Compras.Entidades
{
    public class ProveedorDomicilio
    {        
        public int ProveedorDomicilioID { get; set; }            
        public int ProveedorID { get; set; }
        public int DomicilioID { get; set; }
        public string Comentario { get; set; }
        public Boolean Predeterminado { get; set; }
        public int     TipoDomicilioID { get; set; }


        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PpalProveedorDomicilioID", "PpalProveedorDomicilio");
                if(!nombreColumna.Equals("")){this.ProveedorDomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PpalProveedorID", "PpalProveedorDomicilio");
                if(!nombreColumna.Equals("")){this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EspDomiciliID", "PpalProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentario", "PpalProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Comentario = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "PpalProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoDomiciliID", "PpalProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.TipoDomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }

            }
        }
    }
}
