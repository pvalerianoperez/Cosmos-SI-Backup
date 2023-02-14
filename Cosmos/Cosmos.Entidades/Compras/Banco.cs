
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class Banco
    {        
        public int BancoID { get; set; }            
        public string BancoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public string UsuarioAlta { get; set; }            
        public DateTime FechaAlta { get; set; }            
        public string UsuarioModificacion { get; set; }            
        public DateTime FechaModificacion { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BancoID", "Banco");
                if(!nombreColumna.Equals("")){this.BancoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BancoClave", "Banco");
                if(!nombreColumna.Equals("")){this.BancoClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Banco");
                if(!nombreColumna.Equals("")){this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Banco");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioAlta", "Banco");
                if(!nombreColumna.Equals("")){this.UsuarioAlta = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaAlta", "Banco");
                if(!nombreColumna.Equals("")){this.FechaAlta = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioModificacion", "Banco");
                if(!nombreColumna.Equals("")){this.UsuarioModificacion = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaModificacion", "Banco");
                if(!nombreColumna.Equals("")){this.FechaModificacion = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
            }
        }
    }
}
