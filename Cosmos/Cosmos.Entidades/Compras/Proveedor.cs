
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Entidades.Compras
{
    public class Proveedor:Persona
    {        
        public int ProveedorID { get; set; }                    
        public string NombreCorto { get; set; }            
        public int TipoProveedorID { get; set; }            
        public int GiroEmpresaID { get; set; }            
        public int MedioContactoID { get; set; }            
        public int VinculoID { get; set; }            
           
        public void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", "Proveedor");
                if(!nombreColumna.Equals("")){this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Proveedor");
                if(!nombreColumna.Equals("")){this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "TipoProveedorID", "Proveedor");
                if(!nombreColumna.Equals("")){this.TipoProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "GiroEmpresaID", "Proveedor");
                if(!nombreColumna.Equals("")){this.GiroEmpresaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "MedioContactoID", "Proveedor");
                if(!nombreColumna.Equals("")){this.MedioContactoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "VinculoID", "Proveedor");
                if(!nombreColumna.Equals("")){this.VinculoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]);}                

                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.PersonaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaClave", "Proveedor");
                if (!nombreColumna.Equals("")) { this.PersonaClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FisicaMoral", "Proveedor");
                if (!nombreColumna.Equals("")) { this.FisicaMoral = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreComercial", "Proveedor");
                if (!nombreColumna.Equals("")) { this.NombreComercial = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RazonSocial", "Proveedor");
                if (!nombreColumna.Equals("")) { this.RazonSocial = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Proveedor");
                if (!nombreColumna.Equals("")) { this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoPaterno", "Proveedor");
                if (!nombreColumna.Equals("")) { this.ApellidoPaterno = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoMaterno", "Proveedor");
                if (!nombreColumna.Equals("")) { this.ApellidoMaterno = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RFC", "Proveedor");
                if (!nombreColumna.Equals("")) { this.RFC = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CURP", "Proveedor");
                if (!nombreColumna.Equals("")) { this.CURP Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SexoID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.SexoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaNacimiento", "Proveedor");
                if (!nombreColumna.Equals("")) { this.FechaNacimiento = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadNacimientoID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.CiudadNacimientoID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoCivilID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.EstadoCivilID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoCivil", "Proveedor");
                if (!nombreColumna.Equals("")) { this.CasadoCivil = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoIglesia", "Proveedor");
                if (!nombreColumna.Equals("")) { this.CasadoIglesia = Cosmos.Framework.CastHelper.CBool2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Iniciales", "Proveedor");
                if (!nombreColumna.Equals("")) { this.Iniciales = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SobreNombre", "Proveedor");
                if (!nombreColumna.Equals("")) { this.SobreNombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "Proveedor");
                if (!nombreColumna.Equals("")) { this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "Proveedor");
                if (!nombreColumna.Equals("")) { this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "Proveedor");
                if (!nombreColumna.Equals("")) { this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
            }
        }

       
        public List<ProveedorDomicilio> Domicilios { get; set; }
        public List<ProveedorSucursal> Sucursales { get; set; }
        public List<ProveedorTelefono> Telefonos { get; set; }
        public List<ProveedorMail> Mails { get; set; }
        public List<RepresentanteProveedor> Representantes { get; set; }

       
        
    }
}
