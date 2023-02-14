
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class PersonalDomicilio:Domicilio
    {        
        public int PersonalDomicilioID { get; set; }            
        public int PersonalID { get; set; }            
              
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "PersonalDomicilio";
                
                //PersonalDomicilioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalDomicilioID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalDomicilioID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalID =  CastHelper.CInt2(dr[nombreColumna]);}

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "Domicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Calle", "Domicilio");
                if (!nombreColumna.Equals("")) { this.Calle = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroExterior", "Domicilio");
                if (!nombreColumna.Equals("")) { this.NumeroExterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NumeroInterior", "Domicilio");
                if (!nombreColumna.Equals("")) { this.NumeroInterior = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle1", "Domicilio");
                if (!nombreColumna.Equals("")) { this.EntreCalle1 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EntreCalle2", "Domicilio");
                if (!nombreColumna.Equals("")) { this.EntreCalle2 = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CodigoPostal", "Domicilio");
                if (!nombreColumna.Equals("")) { this.CodigoPostal = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Colonia", "Domicilio");
                if (!nombreColumna.Equals("")) { this.Colonia = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Coordenadas", "Domicilio");
                if (!nombreColumna.Equals("")) { this.Coordenadas = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadID", "Domicilio");
                if (!nombreColumna.Equals("")) { this.CiudadID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioCompleto", "Domicilio");
                if (!nombreColumna.Equals("")) { this.DomicilioCompleto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
