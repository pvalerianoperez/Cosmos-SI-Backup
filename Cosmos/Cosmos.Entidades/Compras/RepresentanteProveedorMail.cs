
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class RepresentanteProveedorMail
    {        
        public int RepresentanteProveedorMailID { get; set; }            
        public int RepresentanteProveedorID { get; set; }            
        public string Mail { get; set; }            
        public int TipoMailID { get; set; }            
        public bool Predeterminado { get; set; }            
        public string Comentarios { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorMailID", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorMailID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorID", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Mail", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.Mail = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoMailID", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.TipoMailID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Predeterminado", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.Predeterminado = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Comentarios", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.Comentarios = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "RepresentanteProveedorMail");
                if(!nombreColumna.Equals("")){this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
            }
        }
    }
}
