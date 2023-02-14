
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
{
    public class UsuarioOpcionBitacora
    {        
        public int UsuarioID { get; set; }            
        public DateTime Fecha { get; set; }            
        public int EmpresaID { get; set; }            
        public int ModuloID { get; set; }            
        public int OpcionID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", "SistemaUsuarioOpcionBitacora");
                if(!nombreColumna.Equals("")){this.UsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Fecha", "SistemaUsuarioOpcionBitacora");
                if(!nombreColumna.Equals("")){this.Fecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", "SistemaUsuarioOpcionBitacora");
                if(!nombreColumna.Equals("")){this.EmpresaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", "SistemaUsuarioOpcionBitacora");
                if(!nombreColumna.Equals("")){this.ModuloID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", "SistemaUsuarioOpcionBitacora");
                if(!nombreColumna.Equals("")){this.OpcionID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
