
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
{
    public class Opcion
    {        
        public int OpcionID { get; set; }            
        public int ModuloID { get; set; }            
        public int PadreID { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public string RecursoWebsite { get; set; }            
        public bool Activo { get; set; }            
        public bool Protegido { get; set; }            
        public bool Popup { get; set; }            
        public bool VisibleMenu { get; set; }            
        public string Icono { get; set; }            
        public int Orden { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.OpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.ModuloID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PadreID", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.PadreID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecursoWebsite", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.RecursoWebsite = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Activo = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Protegido", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Protegido = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Popup", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Popup = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VisibleMenu", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.VisibleMenu = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Icono", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Icono = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Orden", "SistemaOpcion");
                if(!nombreColumna.Equals("")){this.Orden = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
