
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Compras.Entidades
{
    public class Personal:Persona
    {        
        public int PersonalID { get; set; }            
        public string PersonalClave { get; set; }            
        public int EmpresaID { get; set; }            
        public int PuestoID { get; set; }            
        public int ReportaAPersonalID { get; set; }            
        public int AreaID { get; set; }            
        public int CentroCostoID { get; set; }            
        public int HorarioPersonalID { get; set; }            
        public int EstatusPersonalID { get; set; }            
       
        public List<PersonalDomicilio> Domicilios { get; set; }
        public List<PersonalMail> Mails { get; set; }

        public List<PersonalTelefono> Telefonos { get; set; }

        public List<ContactoPersonal> Contactos { get; set; }


        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna="";
                String prefijoTabla = "Personal";
                
                //PersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PersonalClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonalClave", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PersonalClave =  CastHelper.CStr2(dr[nombreColumna]);}   
                
                //EmpresaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EmpresaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //PuestoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PuestoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.PuestoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //ReportaAPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ReportaAPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.ReportaAPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //AreaID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AreaID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.AreaID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //CentroCostoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CentroCostoID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.CentroCostoID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //HorarioPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "HorarioPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.HorarioPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}   
                
                //EstatusPersonalID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstatusPersonalID", prefijoTabla);
                if(!nombreColumna.Equals("")){this.EstatusPersonalID =  CastHelper.CInt2(dr[nombreColumna]);}



              
                //PersonaClave
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "PersonaClave", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.PersonaClave = CastHelper.CStr2(dr[nombreColumna]); }

                //FisicaMoral
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FisicaMoral", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FisicaMoral = CastHelper.CStr2(dr[nombreColumna]); }

                //NombreComercial
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreComercial", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreComercial = CastHelper.CStr2(dr[nombreColumna]); }

                //RazonSocial
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RazonSocial", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RazonSocial = CastHelper.CStr2(dr[nombreColumna]); }

                //Nombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Nombre = CastHelper.CStr2(dr[nombreColumna]); }

                //ApellidoPaterno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoPaterno", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ApellidoPaterno = CastHelper.CStr2(dr[nombreColumna]); }

                //ApellidoMaterno
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ApellidoMaterno", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ApellidoMaterno = CastHelper.CStr2(dr[nombreColumna]); }

                //RFC
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "RFC", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.RFC = CastHelper.CStr2(dr[nombreColumna]); }

                //CURP
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CURP", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CURP = CastHelper.CStr2(dr[nombreColumna]); }

                //SexoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SexoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SexoID = CastHelper.CInt2(dr[nombreColumna]); }

                //FechaNacimiento
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "FechaNacimiento", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.FechaNacimiento = CastHelper.CDate2(dr[nombreColumna]); }

                //CiudadNacimientoID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CiudadNacimientoID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CiudadNacimientoID = CastHelper.CInt2(dr[nombreColumna]); }

                //EstadoCivilID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EstadoCivilID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.EstadoCivilID = CastHelper.CInt2(dr[nombreColumna]); }

                //CasadoCivil
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoCivil", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CasadoCivil = CastHelper.CBool2(dr[nombreColumna]); }

                //CasadoIglesia
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "CasadoIglesia", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.CasadoIglesia = CastHelper.CBool2(dr[nombreColumna]); }

                //Iniciales
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Iniciales", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.Iniciales = CastHelper.CStr2(dr[nombreColumna]); }

                //SobreNombre
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SobreNombre", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.SobreNombre = CastHelper.CStr2(dr[nombreColumna]); }

                //AltaUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AltaUsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //AltaFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.AltaFecha = CastHelper.CDate2(dr[nombreColumna]); }

                //ModificacionUsuarioID
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ModificacionUsuarioID = CastHelper.CInt2(dr[nombreColumna]); }

                //ModificacionFecha
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.ModificacionFecha = CastHelper.CDate2(dr[nombreColumna]); }

                //NombreCompleto
                nombreColumna = EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCompleto", prefijoTabla);
                if (!nombreColumna.Equals("")) { this.NombreCompleto = CastHelper.CStr2(dr[nombreColumna]); }

            }
        }
    }
}
