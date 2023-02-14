
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ConceptoEgreso
    {        
        public int ConceptoEgresoID { get; set; }
        public int EmpresaID { get; set; }
        public string ConceptoEgresoClave { get; set; }            
        public string Nombre { get; set; }            
        public string NombreCorto { get; set; }            
        public string CompraFactura { get; set; }            
        public string Desglosar { get; set; }            
        public int AltaUsuarioID { get; set; }            
        public DateTime AltaFecha { get; set; }            
        public int ModificacionUsuarioID { get; set; }            
        public DateTime ModificacionFecha { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ConceptoEgreso";
                
                //ConceptoEgresoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConceptoEgresoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ConceptoEgresoID =  CastHelper.CInt2(dr[nombreColumna]);}

                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EmpresaID = CastHelper.CInt2(dr[nombreColumna]); }

                //ConceptoEgresoClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ConceptoEgresoClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ConceptoEgresoClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Nombre =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //NombreCorto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", prefijoTabla);
                if(!nombreColumna.Equals("")){this.NombreCorto =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //CompraFactura
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CompraFactura", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CompraFactura =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //Desglosar
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Desglosar", prefijoTabla);
                if(!nombreColumna.Equals("")){this.Desglosar =  CastHelper.CStr2(dr[nombreColumna]);}   
                
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
                
            }
        }
    }
}
