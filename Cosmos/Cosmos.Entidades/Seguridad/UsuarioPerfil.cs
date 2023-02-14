
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Seguridad
{
    public class UsuarioPerfil
    {        
        public int UsuarioID { get; set; }            
        public int PerfilID { get; set; }            
        public int EmpresaID { get; set; }

        public string CompositeKey{
            get {
                return string.Format("{0}-{1}-{2}", this.UsuarioID.ToString(), this.PerfilID.ToString(), this.EmpresaID.ToString());
            }
            set {

            }
        }         
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "UsuarioID", "SistemaUsuarioPerfil");
                if(!nombreColumna.Equals("")){this.UsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PerfilID", "SistemaUsuarioPerfil");
                if(!nombreColumna.Equals("")){this.PerfilID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", "SistemaUsuarioPerfil");
                if(!nombreColumna.Equals("")){this.EmpresaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
            }
        }
    }
}
