
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class RepresentanteProveedor:Persona
    {        
        public int RepresentanteProveedorID { get; set; }            
        public int ProveedorID { get; set; }

        public List<RepresentanteProveedorDomicilio> Domicilios { get; set; }
        public List<RepresentanteProveedorTelefono> Telefonos { get; set; }
        public List<RepresentanteProveedorMail> Mails { get; set; }

        public new  void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RepresentanteProveedorID", "RepresentanteProveedor");
                if(!nombreColumna.Equals("")){this.RepresentanteProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", "RepresentanteProveedor");
                if(!nombreColumna.Equals("")){this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}

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
