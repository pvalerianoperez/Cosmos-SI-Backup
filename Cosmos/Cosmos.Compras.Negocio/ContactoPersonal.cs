
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ContactoPersonal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.ContactoPersonal> Listado() {            
            List<Cosmos.Compras.Entidades.ContactoPersonal> lst = new List<Cosmos.Compras.Entidades.ContactoPersonal>();            
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonal_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ContactoPersonal o = new Cosmos.Compras.Entidades.ContactoPersonal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Consultar(int contactoPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Consultar(Cosmos.Compras.Entidades.ContactoPersonal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ContactoPersonal_Consultar", o.ContactoPersonalID);
            o = new Cosmos.Compras.Entidades.ContactoPersonal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Guardar(int modificacionUsuarioID, int contactoPersonalID, int personalID, int personaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID, PersonalID = personalID, PersonaID = personaID  });
        }
        
        public static Cosmos.Compras.Entidades.ContactoPersonal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonal o) {
            //guarda la persona
            Entidades.Persona p = Persona.Guardar(modificacionUsuarioID, o.PersonaID, o.PersonaClave, "F", "", "", o.Nombre, o.ApellidoPaterno, o.ApellidoMaterno, o.RFC, o.CURP, o.SexoID, o.FechaNacimiento, o.CiudadNacimientoID,
            o.EstadoCivilID, o.CasadoCivil, o.CasadoIglesia, o.Iniciales, o.SobreNombre);
            //actualiza el id de persona (por si es una nueva)
            o.PersonaID = p.PersonaID;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonal_Guardar", modificacionUsuarioID, o.ContactoPersonalID, o.PersonalID, o.PersonaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {
                int contactoPersonalID = (int)dr["ContactoPersonalID"];
                o.ContactoPersonalID = contactoPersonalID;

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda mails 
                List<Cosmos.Compras.Entidades.ContactoPersonalMail> lstOriginal = Cosmos.Compras.Negocio.ContactoPersonalMail.Listado().Where(x => x.ContactoPersonalID == o.ContactoPersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ContactoPersonalMail detalleOriginal in lstOriginal)
                {
                    if (o.Mails.Where(x => x.ContactoPersonalMailID == detalleOriginal.ContactoPersonalMailID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.ContactoPersonalMail.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios
                foreach (Cosmos.Compras.Entidades.ContactoPersonalMail x in o.Mails)
                {
                    x.ContactoPersonalID = o.ContactoPersonalID;
                    ContactoPersonalMail.Guardar(modificacionUsuarioID, x);
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda telefonos
                List<Cosmos.Compras.Entidades.ContactoPersonalTelefono> lstOriginalTelefonos = Cosmos.Compras.Negocio.ContactoPersonalTelefono.Listado().Where(x => x.ContactoPersonalID == o.ContactoPersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ContactoPersonalTelefono detalleOriginal in lstOriginalTelefonos)
                {
                    if (o.Telefonos.Where(x => x.ContactoPersonalTelefonoID == detalleOriginal.ContactoPersonalTelefonoID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.ContactoPersonalTelefono.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios
                foreach (Cosmos.Compras.Entidades.ContactoPersonalTelefono x in o.Telefonos)
                {
                    x.ContactoPersonalID = o.ContactoPersonalID;
                    ContactoPersonalTelefono.Guardar(modificacionUsuarioID, x);
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda domicilios
                List<Cosmos.Compras.Entidades.ContactoPersonalDomicilio> lstOriginalDomicilios = Cosmos.Compras.Negocio.ContactoPersonalDomicilio.Listado().Where(x => x.ContactoPersonalID == o.ContactoPersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ContactoPersonalDomicilio detalleOriginal in lstOriginalDomicilios)
                {
                    if (o.Domicilios.Where(x => x.ContactoPersonalDomicilioID == detalleOriginal.ContactoPersonalDomicilioID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.ContactoPersonalDomicilio.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                foreach (Cosmos.Compras.Entidades.ContactoPersonalDomicilio x in o.Domicilios)
                {
                    x.ContactoPersonalID = o.ContactoPersonalID;
                    ContactoPersonalDomicilio.Guardar(modificacionUsuarioID, x);
                }

                o = Consultar(contactoPersonalID);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int contactoPersonalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ContactoPersonal() { ContactoPersonalID = contactoPersonalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ContactoPersonal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ContactoPersonal_Eliminar", modificacionUsuarioID, o.ContactoPersonalID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
