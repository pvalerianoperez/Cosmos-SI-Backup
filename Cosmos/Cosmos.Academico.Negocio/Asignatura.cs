
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Negocio
{
    public class Asignatura
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Asignatura> Listado()
        {
            List<Cosmos.Academico.Entidades.Asignatura> lst = new List<Cosmos.Academico.Entidades.Asignatura>();
            DataTable dt = SQLHelper.GetTable("Academico_Asignatura_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Asignatura o = new Cosmos.Academico.Entidades.Asignatura();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Asignatura Consultar(int AsignaturaID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Asignatura() { AsignaturaID = AsignaturaID });
        }

        public static Cosmos.Academico.Entidades.Asignatura Consultar(Cosmos.Academico.Entidades.Asignatura o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Asignatura_Consultar", o.AsignaturaID);
            o = new Cosmos.Academico.Entidades.Asignatura();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Asignatura Guardar(int AsignaturaID,
                                                                    string nombre,
                                                                    Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Asignatura() { AsignaturaID = AsignaturaID, Nombre = nombre }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Asignatura Guardar(Cosmos.Academico.Entidades.Asignatura o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Asignatura_Guardar", o.AsignaturaID,
                                                                                  o.Nombre,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["AsignaturaID"]);
            }
            return o;
        }

        public static bool Eliminar(int AsignaturaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.Asignatura() { AsignaturaID = AsignaturaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.Asignatura o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Asignatura_Eliminar", o.AsignaturaID,
                                                                                oInfoForLog.UsuarioIDForLog,
                                                                                oInfoForLog.DescripcionForLog,
                                                                                oInfoForLog.IpAddressForLog,
                                                                                oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
