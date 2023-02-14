
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class ContactoPersonal: Persona
    {        
        public int ContactoPersonalID { get; set; }            
        public int PersonalID { get; set; }

        public List<ContactoPersonalDomicilio> Domicilios { get; set; }
        public List<ContactoPersonalTelefono> Telefonos { get; set; }
        public List<ContactoPersonalMail> Mails { get; set; }

        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "ContactoPersonal";
                
                //ContactoPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ContactoPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ContactoPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalID =  CastHelper.CInt2(dr[nombreColumna]);}

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", "Persona");
                if (!nombreColumna.Equals("")) { this.PersonaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaClave", "Persona");
                if (!nombreColumna.Equals("")) { this.PersonaClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FisicaMoral", "Persona");
                if (!nombreColumna.Equals("")) { this.FisicaMoral = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreComercial", "Persona");
                if (!nombreColumna.Equals("")) { this.NombreComercial = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RazonSocial", "Persona");
                if (!nombreColumna.Equals("")) { this.RazonSocial = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Persona");
                if (!nombreColumna.Equals("")) { this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoPaterno", "Persona");
                if (!nombreColumna.Equals("")) { this.ApellidoPaterno = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoMaterno", "Persona");
                if (!nombreColumna.Equals("")) { this.ApellidoMaterno = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RFC", "Persona");
                if (!nombreColumna.Equals("")) { this.RFC = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CURP", "Persona");
                if (!nombreColumna.Equals("")) { this.CURP = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SexoID", "Persona");
                if (!nombreColumna.Equals("")) { this.SexoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaNacimiento", "Persona");
                if (!nombreColumna.Equals("")) { this.FechaNacimiento = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadNacimientoID", "Persona");
                if (!nombreColumna.Equals("")) { this.CiudadNacimientoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoCivilID", "Persona");
                if (!nombreColumna.Equals("")) { this.EstadoCivilID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoCivil", "Persona");
                if (!nombreColumna.Equals("")) { this.CasadoCivil = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoIglesia", "Persona");
                if (!nombreColumna.Equals("")) { this.CasadoIglesia = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Iniciales", "Persona");
                if (!nombreColumna.Equals("")) { this.Iniciales = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SobreNombre", "Persona");
                if (!nombreColumna.Equals("")) { this.SobreNombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "Persona");
                if (!nombreColumna.Equals("")) { this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "Persona");
                if (!nombreColumna.Equals("")) { this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "Persona");
                if (!nombreColumna.Equals("")) { this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "Persona");
                if (!nombreColumna.Equals("")) { this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }

            }
        }
    }
}
