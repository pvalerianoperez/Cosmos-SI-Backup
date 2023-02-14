
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Calendario.Negocio
{
    public class EventoStatus
    {

        #region CRUD

        public static List<Cosmos.Calendario.Entidades.EventoStatus> Listado()
        {
            List<Cosmos.Calendario.Entidades.EventoStatus> lst = new List<Cosmos.Calendario.Entidades.EventoStatus>();
            DataTable dt = SQLHelper.GetTable("Calendario_EventoStatus_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.EventoStatus o = new Cosmos.Calendario.Entidades.EventoStatus();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Calendario.Entidades.EventoStatus Consultar(int EventoStatusID)
        {
            return Consultar(new Cosmos.Calendario.Entidades.EventoStatus() { EventoStatusID = EventoStatusID });
        }

        public static Cosmos.Calendario.Entidades.EventoStatus Consultar(Cosmos.Calendario.Entidades.EventoStatus o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Calendario_EventoStatus_Consultar", o.EventoStatusID);
            o = new Cosmos.Calendario.Entidades.EventoStatus();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            return o;
        }

        public static Cosmos.Calendario.Entidades.EventoStatus Guardar(int EventoStatusID,
                                                                         string EventoStatusClave,
                                                                         string nombre,
                                                                         string nombreCorto,
                                                                         Cosmos.Seguridad.Entidades.DataForLog oInfoForLog = null)
        {
            return Guardar(new Cosmos.Calendario.Entidades.EventoStatus()
            {
                EventoStatusID = EventoStatusID,
                EventoStatusClave = EventoStatusClave,
                Nombre = nombre,
                NombreCorto = nombreCorto
            }, oInfoForLog);
        }

        public static Cosmos.Calendario.Entidades.EventoStatus Guardar(Cosmos.Calendario.Entidades.EventoStatus o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_EventoStatus_Guardar",
                                                o.EventoStatusID,
                                                o.EventoStatusClave,
                                                o.Nombre,
                                                o.NombreCorto,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["EventoStatusID"]);
            }
            return o;
        }

        public static bool Eliminar(int EventoStatusID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Calendario.Entidades.EventoStatus() { EventoStatusID = EventoStatusID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Calendario.Entidades.EventoStatus o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_EventoStatus_Eliminar", o.EventoStatusID,
                                                                                     oInfoForLog.UsuarioIDForLog,
                                                                                     oInfoForLog.DescripcionForLog,
                                                                                     oInfoForLog.IpAddressForLog,
                                                                                     oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
