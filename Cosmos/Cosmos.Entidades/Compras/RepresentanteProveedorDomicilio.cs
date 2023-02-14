
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class RepresentanteProveedorDomicilio:Domicilio
    {        
        public int RepresentanteProveedorDomicilioID { get; set; }            
        public int RepresentanteProveedorID { get; set; }   
        public string Nombre { get; set; }         
           
        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorDomicilioID", "RepresentanteProveedorDomicilio");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorDomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorID", "RepresentanteProveedorDomicilio");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Calle", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Calle = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroExterior", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.NumeroExterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroInterior", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.NumeroInterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle1", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.EntreCalle1 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle2", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.EntreCalle2 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CodigoPostal", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.CodigoPostal = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Colonia", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Colonia = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Coordenadas", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.Coordenadas = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadID", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.CiudadID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioCompleto", "RepresentanteProveedorDomicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioCompleto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
            }
        }
    }
}
