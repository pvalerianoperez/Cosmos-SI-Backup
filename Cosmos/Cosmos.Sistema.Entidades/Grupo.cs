
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Sistema.Entidades
{
    public class Grupo
    {        
        public int SistemaGrupoID { get; set; }            
        public string Nombre { get; set; }            
        public int ModuloID { get; set; }            
        public bool Activo { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaGrupo";
                
                //SistemaGrupoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SistemaGrupoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.SistemaGrupoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activo =  CastHelper.CBool2(dr[nombreColumna]);}   
                
            }
        }
    }
}
