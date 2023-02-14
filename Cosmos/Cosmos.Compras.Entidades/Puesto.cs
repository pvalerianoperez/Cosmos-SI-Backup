
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Puesto
    {        
        public int PuestoID { get; set; }
        public int EmpresaID { get; set; }
        public string PuestoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public decimal Sueldo { get; set; }            
        public string BaseNeto { get; set; }            
        public string Tipo { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
        public string Objetivo { get; set; }            
        public string ReqAcademicos { get; set; }            
        public int TiempoDesempeno { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Puesto";
                
                //PuestoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PuestoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PuestoID =  CastHelper.CInt2(dr[nombreColumna]);}

                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EmpresaID = CastHelper.CInt2(dr[nombreColumna]); }

                //PuestoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PuestoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PuestoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Sueldo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Sueldo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Sueldo =  CastHelper.CDecimal2(dr[nombreColumna]);}   
                
                //BaseNeto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "BaseNeto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.BaseNeto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Tipo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Tipo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Tipo =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //AltaUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AltaUsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AltaFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AltaFecha =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //ModificacionUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModificacionUsuarioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ModificacionFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ModificacionFecha =  CastHelper.CDate2(dr[nombreColumna]);}   
                
                //Objetivo
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Objetivo", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Objetivo =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //ReqAcademicos
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ReqAcademicos", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ReqAcademicos =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //TiempoDesempeno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TiempoDesempeno", prefijoTabla);
                if(!nombreColumna.Equals("")){this.TiempoDesempeno =  CastHelper.CInt2(dr[nombreColumna]);}   
                
            }
        }
    }
}
