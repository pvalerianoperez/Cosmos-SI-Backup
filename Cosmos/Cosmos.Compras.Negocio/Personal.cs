
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Personal
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.Personal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Personal() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.Personal> Listado(Cosmos.Compras.Entidades.Personal entidad) {            
            List<Cosmos.Compras.Entidades.Personal> lst = new List<Cosmos.Compras.Entidades.Personal>();            
            DataTable dt = SQLHelper.GetTable("Compras_Personal_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Personal o = new Cosmos.Compras.Entidades.Personal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Personal Consultar(int personalID) {
            return Consultar(new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID  });
        }
        
        public static Cosmos.Compras.Entidades.Personal Consultar(Cosmos.Compras.Entidades.Personal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Personal_Consultar", o.PersonalID);
            o = new Cosmos.Compras.Entidades.Personal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
                DataRow drPersona = SQLHelper.GetFirstRow("Compras_Persona_Consultar", o.PersonaID);
                if (drPersona != null) { o.Load(drPersona); }

                o.Mails = Negocio.PersonalMail.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                o.Telefonos = Negocio.PersonalTelefono.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                o.Domicilios = Negocio.PersonalDomicilio.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                o.Contactos = Negocio.ContactoPersonal.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Personal Guardar(int modificacionUsuarioID, int personalID, int personaID, string personalClave, int empresaID, int puestoID, int reportaAPersonalID, int areaID, int centroCostoID, int horarioPersonalID, int estatusPersonalID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID, PersonaID = personaID, PersonalClave = personalClave, EmpresaID = empresaID, PuestoID = puestoID, ReportaAPersonalID = reportaAPersonalID, AreaID = areaID, CentroCostoID = centroCostoID, HorarioPersonalID = horarioPersonalID, EstatusPersonalID = estatusPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.Personal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Personal o) {
            //guarda la persona
            Entidades.Persona p = Persona.Guardar(modificacionUsuarioID, o.PersonaID, o.PersonaClave, "F", "", "", o.Nombre, o.ApellidoPaterno, o.ApellidoMaterno, o.RFC, o.CURP, o.SexoID, o.FechaNacimiento, o.CiudadNacimientoID,
            o.EstadoCivilID, o.CasadoCivil, o.CasadoIglesia, o.Iniciales, o.SobreNombre);
            //actualiza el id de persona (por si es una nueva)
            o.PersonaID = p.PersonaID;
            //guarda los datos de personal
            DataRow dr = SQLHelper.GetFirstRow("Compras_Personal_Guardar", modificacionUsuarioID, o.PersonalID, o.PersonaID, o.PersonalClave, o.EmpresaID, o.PuestoID, o.ReportaAPersonalID, o.AreaID, o.CentroCostoID, o.HorarioPersonalID, o.EstatusPersonalID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {
                o.PersonalID = (int)dr["PersonalID"];

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda mails 
                List<Cosmos.Compras.Entidades.PersonalMail> lstOriginal = Cosmos.Compras.Negocio.PersonalMail.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.PersonalMail detalleOriginal in lstOriginal)
                {
                    if (o.Mails.Where(x => x.PersonalMailID == detalleOriginal.PersonalMailID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.PersonalMail.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios
                foreach (Cosmos.Compras.Entidades.PersonalMail x in o.Mails)
                {
                    x.PersonalID = o.PersonalID;
                    PersonalMail.Guardar(modificacionUsuarioID, x);
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda telefonos
                List<Cosmos.Compras.Entidades.PersonalTelefono> lstOriginalTelefonos = Cosmos.Compras.Negocio.PersonalTelefono.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.PersonalTelefono detalleOriginal in lstOriginalTelefonos)
                {
                    if (o.Telefonos.Where(x => x.PersonalTelefonoID == detalleOriginal.PersonalTelefonoID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.PersonalTelefono.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                //guarda los cambios
                foreach (Cosmos.Compras.Entidades.PersonalTelefono x in o.Telefonos)
                {
                    x.PersonalID = o.PersonalID;
                    PersonalTelefono.Guardar(modificacionUsuarioID, x);
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda domicilios
                List<Cosmos.Compras.Entidades.PersonalDomicilio> lstOriginalDomicilios = Cosmos.Compras.Negocio.PersonalDomicilio.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.PersonalDomicilio detalleOriginal in lstOriginalDomicilios)
                {
                    if (o.Domicilios.Where(x => x.PersonalDomicilioID == detalleOriginal.PersonalDomicilioID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.PersonalDomicilio.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                foreach (Cosmos.Compras.Entidades.PersonalDomicilio x in o.Domicilios)
                {
                    x.PersonalID = o.PersonalID;
                    PersonalDomicilio.Guardar(modificacionUsuarioID, x);
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //guarda contactos               
                List<Cosmos.Compras.Entidades.ContactoPersonal> lstOriginalContactos = Cosmos.Compras.Negocio.ContactoPersonal.Listado().Where(x => x.PersonalID == o.PersonalID).ToList();
                //elimina todos los detalles que no se mantienen
                foreach (Cosmos.Compras.Entidades.ContactoPersonal detalleOriginal in lstOriginalContactos)
                {
                    if (o.Contactos.Where(x => x.ContactoPersonalID == detalleOriginal.ContactoPersonalID).ToList().Count == 0)
                    {
                        Cosmos.Compras.Negocio.ContactoPersonal.Eliminar(modificacionUsuarioID, detalleOriginal);
                    }
                }
                foreach (Cosmos.Compras.Entidades.ContactoPersonal x in o.Contactos)
                {
                    x.PersonalID = o.PersonalID;
                    ContactoPersonal.Guardar(modificacionUsuarioID, x);
                }

                //vuelve a cargar el objeto para regresarlo
                o = Consultar((int)dr["PersonalID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Personal() { PersonalID = personalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Personal o) {                        
            bool ok = false;
            //intenta eliminar la persona relacionada
            try
            {
                o = Consultar(o);
                DataRow dr = SQLHelper.GetFirstRow("Compras_Personal_Eliminar", modificacionUsuarioID, o.PersonalID);
                ok = !SQLHelper.ErrorRespuestaSQL(dr);
                if (ok && o.PersonaID> 0)
                {
                    ok = Persona.Eliminar(modificacionUsuarioID, o.PersonaID);
                }
            }
            catch (Exception exEliminar) {
                throw exEliminar;
            }
            return ok;
        }



        #endregion

       

    }
}
