
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Calendario.Negocio
{
    public class Evento
    {

        #region CRUD

        public static List<Cosmos.Calendario.Entidades.Evento> Listado()
        {
            List<Cosmos.Calendario.Entidades.Evento> lst = new List<Cosmos.Calendario.Entidades.Evento>();
            DataTable dt = SQLHelper.GetTable("Calendario_Evento_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.Evento o = new Cosmos.Calendario.Entidades.Evento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Calendario.Entidades.Evento Consultar(int eventoID)
        {
            return Consultar(new Cosmos.Calendario.Entidades.Evento() { EventoID = eventoID });
        }

        public static Cosmos.Calendario.Entidades.Evento Consultar(Cosmos.Calendario.Entidades.Evento o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Calendario_Evento_Consultar", o.EventoID);
            o = new Cosmos.Calendario.Entidades.Evento();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            return o;
        }

        public static Cosmos.Calendario.Entidades.Evento Guardar(int eventoID,
                                                                 int eventoTipoID,
                                                                 DateTime fechaInicio,
                                                                 DateTime fechaFinal,
                                                                 bool todoElDia,
                                                                 string tema,
                                                                 string locacion,
                                                                 string descripcion,
                                                                 int statusID,
                                                                 int etiquetaID,
                                                                 int recursoID,
                                                                 string recursoIDs,
                                                                 string recordatorioInfo,
                                                                 string recurrenciaInfo,
                                                                 string campoPersonalizado1,
                                                                 string campoPersonalizado2,
                                                                 string campoPersonalizado3,
                                                                 string campoPersonalizado4,
                                                                 string campoPersonalizado5,
                                                                 int calendarioID,
                                                                 Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Calendario.Entidades.Evento()
            {
                EventoID = eventoID,
                EventoTipoID = eventoTipoID,
                FechaInicio = fechaInicio,
                FechaFinal = fechaFinal,
                TodoElDia = todoElDia,
                Tema = tema,
                Locacion = locacion,
                Descripcion = descripcion,
                StatusID = statusID,
                EtiquetaID = etiquetaID,
                RecursoID = recursoID,
                RecursoIDs = recursoIDs,
                RecordatorioInfo = recordatorioInfo,
                RecurrenciaInfo = recurrenciaInfo,
                CampoPersonalizado1 = campoPersonalizado1,
                CampoPersonalizado2 = campoPersonalizado2,
                CampoPersonalizado3 = campoPersonalizado3,
                CampoPersonalizado4 = campoPersonalizado4,
                CampoPersonalizado5 = campoPersonalizado5
            },
                calendarioID, oInfoForLog);
        }

        public static Cosmos.Calendario.Entidades.Evento Guardar(Cosmos.Calendario.Entidades.Evento o, int calendarioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {

            if (o.TodoElDia == false)
            {
                if (o.FechaInicio > o.FechaFinal) { throw new Exception("La fecha de inicio no puede ser posterior a la fecha final."); }
            }

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_Evento_Guardar",
                                                o.EventoID,             // 1
                                                o.EventoTipoID,         // 2
                                                o.FechaInicio,          // 3 
                                                o.FechaFinal,           // 4
                                                o.TodoElDia,            // 5
                                                o.Tema,                 // 6
                                                o.Locacion,             // 7
                                                o.Descripcion,          // 8
                                                o.StatusID,             // 9
                                                o.EtiquetaID,           // 10
                                                o.RecursoID,            // 11
                                                o.RecursoIDs,           // 12
                                                o.RecordatorioInfo,     // 13 
                                                o.RecurrenciaInfo,      // 14
                                                o.CampoPersonalizado1,  // 15
                                                o.CampoPersonalizado2,  // 16
                                                o.CampoPersonalizado3,  // 17
                                                o.CampoPersonalizado4,  // 18
                                                o.CampoPersonalizado5,  // 19
                                                calendarioID,           // 20
                                                oInfoForLog.UsuarioIDForLog,    // 21
                                                oInfoForLog.DescripcionForLog,  // 22
                                                oInfoForLog.IpAddressForLog,    // 23
                                                oInfoForLog.HostNameForLog      // 24
                                                );
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                int EventoID = (int)dr["EventoID"];
                o = Consultar(EventoID);
            }
            return o;
        }

        public static bool Eliminar(int EventoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Calendario.Entidades.Evento() { EventoID = EventoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Calendario.Entidades.Evento o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Calendario_Evento_Eliminar", o.EventoID,
                                                                                oInfoForLog.UsuarioIDForLog,
                                                                                oInfoForLog.DescripcionForLog,
                                                                                oInfoForLog.IpAddressForLog,
                                                                                oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion



        public static List<Cosmos.Calendario.Entidades.Evento> Listado_xCalendarioID(int CalendarioID)
        {
            List<Cosmos.Calendario.Entidades.Evento> lst = new List<Cosmos.Calendario.Entidades.Evento>();
            DataTable dt = SQLHelper.GetTable("Calendario_Evento_Listado_xCalendarioID", CalendarioID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Calendario.Entidades.Evento o = new Cosmos.Calendario.Entidades.Evento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

    }
}
