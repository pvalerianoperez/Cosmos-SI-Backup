
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class RepresentanteProveedorTelefono:Telefono
    {        
        public int RepresentanteProveedorTelefonoID { get; set; }            
        public int RepresentanteProveedorID { get; set; }            
        
        public string Extension { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
                   
           
        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorTelefonoID", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorID", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.TelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Extension", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.Extension = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "RepresentanteProveedorTelefono");
                if(!nombreColumna.Equals("")){this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                

                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TelefonoID", "Telefono");
                if (!nombreColumna.Equals("")) { this.TelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "LadaPais", "Telefono");
                if (!nombreColumna.Equals("")) { this.LadaPais = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroTelefonico", "Telefono");
                if (!nombreColumna.Equals("")) { this.NumeroTelefonico = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoTelefonoID", "Telefono");
                if (!nombreColumna.Equals("")) { this.TipoTelefonoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }


            }
        }
    }
}
