
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Compras.Entidades
{
    public class Domicilio
    {        
        public int DomicilioID { get; set; }            
        public string Calle { get; set; }            
        public string NumeroExterior { get; set; }            
        public string NumeroInterior { get; set; }            
        public string EntreCalle1 { get; set; }            
        public string EntreCalle2 { get; set; }            
        public int CodigoPostal { get; set; }            
        public string Colonia { get; set; }            
        public string Coordenadas { get; set; }            
        public int CiudadID { get; set; }
        public string DomicilioCompleto { get; set; }
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "Domicilio");
                if(!nombreColumna.Equals("")){this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Calle", "Domicilio");
                if(!nombreColumna.Equals("")){this.Calle = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroExterior", "Domicilio");
                if(!nombreColumna.Equals("")){this.NumeroExterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroInterior", "Domicilio");
                if(!nombreColumna.Equals("")){this.NumeroInterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle1", "Domicilio");
                if(!nombreColumna.Equals("")){this.EntreCalle1 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle2", "Domicilio");
                if(!nombreColumna.Equals("")){this.EntreCalle2 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CodigoPostal", "Domicilio");
                if(!nombreColumna.Equals("")){this.CodigoPostal = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Colonia", "Domicilio");
                if(!nombreColumna.Equals("")){this.Colonia = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Coordenadas", "Domicilio");
                if(!nombreColumna.Equals("")){this.Coordenadas = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadID", "Domicilio");
                if(!nombreColumna.Equals("")){this.CiudadID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioCompleto", "Domicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioCompleto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }



            }
        }
    }
}
