
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Calendario.Negocio
{
    public class Calendario
    {

        #region CRUD

        public static List<Cosmos.Calendario.Entidades.Calendario> Listado(bool conBorrados = false)
        {
            List<Cosmos.Calendario.Entidades.Calendario> lst = new List<Cosmos.Calendario.Entidades.Calendario>();
            DataTable dt = SQLHelper.GetTable("Calendario_Calendario_Listado", conBorrados);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.Calendario o = new Cosmos.Calendario.Entidades.Calendario();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Calendario.Entidades.Calendario> Mis_Calendarios(int PersonaID)
        {
            List<Cosmos.Calendario.Entidades.Calendario> lst = new List<Cosmos.Calendario.Entidades.Calendario>();
            DataTable dt = SQLHelper.GetTable("Calendario_Calendario_Consultar_xPersonaID", PersonaID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.Calendario o = new Cosmos.Calendario.Entidades.Calendario();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }


        public static Cosmos.Calendario.Entidades.Calendario Consultar(int CalendarioID)
        {
            return Consultar(new Cosmos.Calendario.Entidades.Calendario() { CalendarioID = CalendarioID });
        }

        public static Cosmos.Calendario.Entidades.Calendario Consultar(Cosmos.Calendario.Entidades.Calendario o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Calendario_Calendario_Consultar", o.CalendarioID);
            o = new Cosmos.Calendario.Entidades.Calendario();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
                o.Eventos = Cosmos.Calendario.Negocio.Evento.Listado_xCalendarioID(o.CalendarioID);
            }

            return o;
        }

        public static Cosmos.Calendario.Entidades.Calendario Guardar(int calendarioID,
                                                                     string calendarioClave,
                                                                     string nombre,
                                                                     string nombreCorto,
                                                                     int calendarioTipoID,
                                                                     bool borrado,
                                                                     int calendarioPersonaID = -1,
                                                                     int personaID = -1,
                                                                     int calendarioPermisoInt = -1,
                                                                     bool dueno = false,
                                                                     Cosmos.Seguridad.Entidades.DataForLog oInfoForLog = null)
        {
            return Guardar(new Cosmos.Calendario.Entidades.Calendario()
            {
                CalendarioID = calendarioID,
                CalendarioClave = calendarioClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                CalendarioTipoID = calendarioTipoID,
                Borrado = borrado,
                CalendarioPersonaID = calendarioPersonaID,
                PersonaID = personaID,
                CalendarioPermisoInt = calendarioPermisoInt,
                Dueno = dueno,
            }, oInfoForLog);
        }

        public static Cosmos.Calendario.Entidades.Calendario Guardar(Cosmos.Calendario.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_Calendario_Guardar",
                                                o.CalendarioID,
                                                o.CalendarioClave,
                                                o.Nombre,
                                                o.NombreCorto,
                                                o.CalendarioTipoID,
                                                o.Borrado,
                                                o.CalendarioPersonaID,
                                                o.PersonaID,
                                                o.Dueno,
                                                o.CalendarioPermisoInt,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CalendarioID"]);

                if (o.Eventos.Count > 0)
                {
                    //**********************************************************************
                    // Guarda eventos 
                    List<Cosmos.Calendario.Entidades.Evento> lstOriginal = Cosmos.Calendario.Negocio.Evento.Listado_xCalendarioID(o.CalendarioID);

                    // Elimina todos los eventos que no se mantienen
                    foreach (Cosmos.Calendario.Entidades.Evento evntoOriginal in lstOriginal)
                    {
                        bool found = false;
                        foreach (Cosmos.Calendario.Entidades.Evento eventoPropuesto in o.Eventos)
                        {
                            if (evntoOriginal.EventoID == eventoPropuesto.EventoID) { found = true; }
                        }

                        if (!found) Cosmos.Calendario.Negocio.Evento.Eliminar(evntoOriginal, oInfoForLog);
                    }

                    // Guarda los cambios
                    foreach (Cosmos.Calendario.Entidades.Evento x in o.Eventos)
                    {
                        Evento.Guardar(x, o.CalendarioID, oInfoForLog);
                    }
                }
            }
            return o;
        }



        public static Cosmos.Calendario.Entidades.Calendario Compartir(int calendarioPersonaID, 
                                                                       int calendarioID,
                                                                       int personaID,
                                                                       int calendarioPermisoInt,
                                                                       bool dueno,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Compartir(new Cosmos.Calendario.Entidades.Calendario()
            {
                CalendarioPersonaID = calendarioPersonaID,
                CalendarioID = calendarioID,
                PersonaID = personaID,
                CalendarioPermisoInt = calendarioPermisoInt,
                Dueno = dueno,
            }, oInfoForLog);
        }


        public static Cosmos.Calendario.Entidades.Calendario Compartir(Cosmos.Calendario.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_CalendarioPersona_Guardar",
                                                o.CalendarioPersonaID,
                                                o.CalendarioID,
                                                o.PersonaID,
                                                o.CalendarioPermisoInt,
                                                o.Dueno,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar(o.CalendarioID);
            }
            return o;
        }




        public static Cosmos.Calendario.Entidades.Calendario DesCompartir(int calendarioPersonaID,
                                                                          Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Compartir(new Cosmos.Calendario.Entidades.Calendario()
            {
                CalendarioPersonaID = calendarioPersonaID,
            }, oInfoForLog);
        }


        public static Cosmos.Calendario.Entidades.Calendario DesCompartir(Cosmos.Calendario.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_CalendarioPersona_Eliminar",
                                                o.CalendarioPersonaID,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar(o.CalendarioID);
            }
            return o;
        }






        public static bool Eliminar(int CalendarioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Calendario.Entidades.Calendario() { CalendarioID = CalendarioID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Calendario.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_Calendario_Eliminar", o.CalendarioID,
                                                                                oInfoForLog.UsuarioIDForLog,
                                                                                oInfoForLog.DescripcionForLog,
                                                                                oInfoForLog.IpAddressForLog,
                                                                                oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
