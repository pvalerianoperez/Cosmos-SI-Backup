
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Calendario.Negocio
{
    public class CalendarioTipo
    {

        #region CRUD

        public static List<Cosmos.Calendario.Entidades.CalendarioTipo> Listado()
        {
            List<Cosmos.Calendario.Entidades.CalendarioTipo> lst = new List<Cosmos.Calendario.Entidades.CalendarioTipo>();
            DataTable dt = SQLHelper.GetTable("Calendario_CalendarioTipo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.CalendarioTipo o = new Cosmos.Calendario.Entidades.CalendarioTipo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Calendario.Entidades.CalendarioTipo Consultar(int CalendarioTipoID)
        {
            return Consultar(new Cosmos.Calendario.Entidades.CalendarioTipo() { CalendarioTipoID = CalendarioTipoID });
        }

        public static Cosmos.Calendario.Entidades.CalendarioTipo Consultar(Cosmos.Calendario.Entidades.CalendarioTipo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Calendario_CalendarioTipo_Consultar", o.CalendarioTipoID);
            o = new Cosmos.Calendario.Entidades.CalendarioTipo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            return o;
        }

        public static Cosmos.Calendario.Entidades.CalendarioTipo Guardar(int calendarioTipoID,
                                                                         string calendarioTipoClave,
                                                                         string nombre,
                                                                         string nombreCorto,
                                                                         Cosmos.Seguridad.Entidades.DataForLog oInfoForLog = null)
        {
            return Guardar(new Cosmos.Calendario.Entidades.CalendarioTipo()
            {
                CalendarioTipoID = calendarioTipoID,
                CalendarioTipoClave = calendarioTipoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto
            }, oInfoForLog);
        }

        public static Cosmos.Calendario.Entidades.CalendarioTipo Guardar(Cosmos.Calendario.Entidades.CalendarioTipo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_CalendarioTipo_Guardar",
                                                o.CalendarioTipoID,
                                                o.CalendarioTipoClave,
                                                o.Nombre,
                                                o.NombreCorto,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CalendarioTipoID"]);
            }
            return o;
        }

        public static bool Eliminar(int CalendarioTipoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Calendario.Entidades.CalendarioTipo() { CalendarioTipoID = CalendarioTipoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Calendario.Entidades.CalendarioTipo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_CalendarioTipo_Eliminar", o.CalendarioTipoID,
                                                                                     oInfoForLog.UsuarioIDForLog,
                                                                                     oInfoForLog.DescripcionForLog,
                                                                                     oInfoForLog.IpAddressForLog,
                                                                                     oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
