
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
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
        public bool Permiso { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "SistemaOpcion";
                
                //OpcionID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "OpcionID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.OpcionID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ModuloID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModuloID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModuloID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PadreID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PadreID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PadreID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //RecursoWebsite
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RecursoWebsite", prefijoTabla);
                if(!nombreColumna.Equals("")){this.RecursoWebsite =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Activo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Activo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Activo =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Protegido
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Protegido", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Protegido =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Popup
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Popup", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Popup =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //VisibleMenu
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VisibleMenu", prefijoTabla);
                if(!nombreColumna.Equals("")){this.VisibleMenu =  CastHelper.CBool2(dr[nombreColumna]);}   
                
                //Icono
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Icono", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Icono =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Orden
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Orden", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Orden =  CastHelper.CInt2(dr[nombreColumna]);}

                //Permiso
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Permiso", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Permiso = CastHelper.CBool2(dr[nombreColumna]); }

            }
        }
    }
}
