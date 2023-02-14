
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Sistema
{
    public class Sexo
    {        
        public int SexoID { get; set; }            
        public string SexoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SexoID", "Sexo");
                if(!nombreColumna.Equals("")){this.SexoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SexoClave", "Sexo");
                if(!nombreColumna.Equals("")){this.SexoClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Sexo");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Sexo");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "Sexo");
                if(!nombreColumna.Equals("")){this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "Sexo");
                if(!nombreColumna.Equals("")){this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "Sexo");
                if(!nombreColumna.Equals("")){this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "Sexo");
                if(!nombreColumna.Equals("")){this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
            }
        }
    }
}
