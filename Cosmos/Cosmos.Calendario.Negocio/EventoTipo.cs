
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Calendario.Negocio
{
    public class EventoTipo
    {

        #region CRUD

        public static List<Cosmos.Calendario.Entidades.EventoTipo> Listado()
        {
            List<Cosmos.Calendario.Entidades.EventoTipo> lst = new List<Cosmos.Calendario.Entidades.EventoTipo>();
            DataTable dt = SQLHelper.GetTable("Calendario_EventoTipo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.EventoTipo o = new Cosmos.Calendario.Entidades.EventoTipo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Calendario.Entidades.EventoTipo Consultar(int EventoTipoID)
        {
            return Consultar(new Cosmos.Calendario.Entidades.EventoTipo() { EventoTipoID = EventoTipoID });
        }

        public static Cosmos.Calendario.Entidades.EventoTipo Consultar(Cosmos.Calendario.Entidades.EventoTipo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Calendario_EventoTipo_Consultar", o.EventoTipoID);
            o = new Cosmos.Calendario.Entidades.EventoTipo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            return o;
        }

        public static Cosmos.Calendario.Entidades.EventoTipo Guardar(int EventoTipoID,
                                                                         string EventoTipoClave,
                                                                         string nombre,
                                                                         string nombreCorto,
                                                                         Cosmos.Seguridad.Entidades.DataForLog oInfoForLog = null)
        {
            return Guardar(new Cosmos.Calendario.Entidades.EventoTipo()
            {
                EventoTipoID = EventoTipoID,
                EventoTipoClave = EventoTipoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto
            }, oInfoForLog);
        }

        public static Cosmos.Calendario.Entidades.EventoTipo Guardar(Cosmos.Calendario.Entidades.EventoTipo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_EventoTipo_Guardar",
                                                o.EventoTipoID,
                                                o.EventoTipoClave,
                                                o.Nombre,
                                                o.NombreCorto,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["EventoTipoID"]);
            }
            return o;
        }

        public static bool Eliminar(int EventoTipoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Calendario.Entidades.EventoTipo() { EventoTipoID = EventoTipoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Calendario.Entidades.EventoTipo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_EventoTipo_Eliminar", o.EventoTipoID,
                                                                                     oInfoForLog.UsuarioIDForLog,
                                                                                     oInfoForLog.DescripcionForLog,
                                                                                     oInfoForLog.IpAddressForLog,
                                                                                     oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
