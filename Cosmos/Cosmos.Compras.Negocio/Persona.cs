
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Persona
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Persona> Listado() {            
            List<Cosmos.Compras.Entidades.Persona> lst = new List<Cosmos.Compras.Entidades.Persona>();            
            DataTable dt = SQLHelper.GetTable("Compras_Persona_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Persona o = new Cosmos.Compras.Entidades.Persona();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Persona Consultar(int personaID) {
            return Consultar(new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID  });
        }
        
        public static Cosmos.Compras.Entidades.Persona Consultar(Cosmos.Compras.Entidades.Persona o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Persona_Consultar", o.PersonaID);
            o = new Cosmos.Compras.Entidades.Persona();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Persona Guardar(int modificacionUsuarioID, int personaID, string personaClave, string fisicaMoral, string nombreComercial, string razonSocial, string nombre, string apellidoPaterno, string apellidoMaterno, string rFC, string cURP, int sexoID, DateTime fechaNacimiento, int ciudadNacimientoID, int estadoCivilID, bool casadoCivil, bool casadoIglesia, string iniciales, string sobreNombre) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID, PersonaClave = personaClave, FisicaMoral = fisicaMoral, NombreComercial = nombreComercial, RazonSocial = razonSocial, Nombre = nombre, ApellidoPaterno = apellidoPaterno, ApellidoMaterno = apellidoMaterno, RFC = rFC, CURP = cURP, SexoID = sexoID, FechaNacimiento = fechaNacimiento, CiudadNacimientoID = ciudadNacimientoID, EstadoCivilID = estadoCivilID, CasadoCivil = casadoCivil, CasadoIglesia = casadoIglesia, Iniciales = iniciales, SobreNombre = sobreNombre  });
        }
        
        public static Cosmos.Compras.Entidades.Persona Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Persona o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Persona_Guardar", modificacionUsuarioID, o.PersonaID, o.PersonaClave, o.FisicaMoral, o.NombreComercial, o.RazonSocial, o.Nombre, o.ApellidoPaterno, o.ApellidoMaterno, o.RFC, o.CURP, o.SexoID, o.FechaNacimiento, o.CiudadNacimientoID, o.EstadoCivilID, o.CasadoCivil, o.CasadoIglesia, o.Iniciales, o.SobreNombre);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PersonaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Persona o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Persona_Eliminar", modificacionUsuarioID, o.PersonaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
