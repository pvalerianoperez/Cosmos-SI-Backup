
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class Turno
    {
        #region Columnas

        //[TurnoID] INT NOT NULL IDENTITY,
        //[TurnoClave]  VARCHAR(6)   NULL,
        //[Nombre] VARCHAR(80)  NULL,
        //[NombreCorto] VARCHAR(15)  NULL,
        //[HoraInicio]
        //[HoraFinal]   SMALLINT NULL,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Turno> Listado()
        {
            List<Cosmos.Academico.Entidades.Turno> lst = new List<Cosmos.Academico.Entidades.Turno>();
            DataTable dt = SQLHelper.GetTable("Academico_Turno_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Turno o = new Cosmos.Academico.Entidades.Turno();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Turno Consultar(int TurnoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Turno() { TurnoID = TurnoID });
        }

        public static Cosmos.Academico.Entidades.Turno Consultar(Cosmos.Academico.Entidades.Turno o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Turno_Consultar", o.TurnoID);
            o = new Cosmos.Academico.Entidades.Turno();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Turno Guardar(int TurnoID,
                                                                       string TurnoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       DateTime HoraInicio,
                                                                       DateTime HoraFinal,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Turno()
            {
                TurnoID = TurnoID,
                TurnoClave = TurnoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                HoraInicio = HoraInicio,
                HoraFinal = HoraFinal,
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Turno Guardar(Cosmos.Academico.Entidades.Turno o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            int MinutosHoraInicio = o.HoraInicio.Hour * 60 + o.HoraInicio.Minute;
            int MinutosHoraFinal = o.HoraFinal.Hour * 60 + o.HoraFinal.Minute;

            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Turno_Guardar", o.TurnoID,
                                                                                  o.TurnoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  MinutosHoraInicio,
                                                                                  MinutosHoraFinal,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TurnoID"]);
            }
            return o;
        }

        public static bool Eliminar(int TurnoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.Turno() { TurnoID = TurnoID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.Turno o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Turno_Eliminar", o.TurnoID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
