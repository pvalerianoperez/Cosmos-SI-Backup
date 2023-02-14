
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class Calendario
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Calendario> Listado()
        {
            List<Cosmos.Academico.Entidades.Calendario> lst = new List<Cosmos.Academico.Entidades.Calendario>();
            DataTable dt = SQLHelper.GetTable("Academico_Calendario_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Calendario o = new Cosmos.Academico.Entidades.Calendario();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Calendario Consultar(int CalendarioID, bool ConCiclos)
        {
            return Consultar(new Cosmos.Academico.Entidades.Calendario() { CalendarioID = CalendarioID }, ConCiclos);
        }

        public static Cosmos.Academico.Entidades.Calendario Consultar(Cosmos.Academico.Entidades.Calendario o, bool ConCiclos)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Calendario_Consultar", o.CalendarioID);
            o = new Cosmos.Academico.Entidades.Calendario();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            if (ConCiclos)
            {
                o.Ciclos = Cosmos.Academico.Negocio.Ciclo.Listado_xCalendarioID(o.CalendarioID);
            }

            return o;
        }
        
        public static Cosmos.Academico.Entidades.Calendario Guardar(int CalendarioID, 
                                                                    string CalendarioClave,
                                                                    string nombre,
                                                                    string nombreCorto,
                                                                    string Descripcion,
                                                                    DateTime FechaInicio,
                                                                    DateTime FechaFinal,
                                                                    int CalendarioIDAnterior, 
                                                                    Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Calendario() { CalendarioID = CalendarioID,
                                                                                                CalendarioClave = CalendarioClave,
                                                                                                Nombre = nombre,
                                                                                                NombreCorto = nombreCorto,
                                                                                                Descripcion = Descripcion,
                                                                                                FechaInicio = FechaInicio,
                                                                                                FechaFinal = FechaFinal,
                                                                                                CalendarioIDAnterior = CalendarioIDAnterior}, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Calendario Guardar(Cosmos.Academico.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Calendario_Guardar", 
                                                o.CalendarioID, 
                                                o.CalendarioClave, 
                                                o.Nombre, 
                                                o.NombreCorto,
                                                o.Descripcion,
                                                o.FechaInicio,
                                                o.FechaFinal,
                                                o.CalendarioIDAnterior,
                                                oInfoForLog.UsuarioIDForLog,
                                                oInfoForLog.DescripcionForLog,
                                                oInfoForLog.IpAddressForLog,
                                                oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CalendarioID"], true);
            }
            return o;
        }

        public static bool Eliminar(int CalendarioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.Calendario() { CalendarioID = CalendarioID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.Calendario o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Calendario_Eliminar", o.CalendarioID,
                                                                                oInfoForLog.UsuarioIDForLog,
                                                                                oInfoForLog.DescripcionForLog,
                                                                                oInfoForLog.IpAddressForLog,
                                                                                oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static Cosmos.Academico.Entidades.Ciclo AgregarCiclo(Cosmos.Academico.Entidades.Ciclo oCiclo, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            Cosmos.Academico.Entidades.Ciclo oCicloRegreso;
            oCicloRegreso = Cosmos.Academico.Negocio.Ciclo.Guardar(oCiclo, oInfoForLog);

            return oCiclo;
        }

    }
}
