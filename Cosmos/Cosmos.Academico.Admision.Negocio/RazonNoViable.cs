using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class RazonNoViable
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.RazonNoViable> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.RazonNoViable> lst = new List<Cosmos.Academico.Admision.Entidades.RazonNoViable>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_RazonNoViable_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.RazonNoViable o = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Consultar(int RazonNoViableID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.RazonNoViable() { RazonNoViableID = RazonNoViableID });
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Consultar(Cosmos.Academico.Admision.Entidades.RazonNoViable o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_RazonNoViable_Consultar", o.RazonNoViableID);
            o = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Guardar(int RazonNoViableID,
                                                                       string RazonNoViableClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.RazonNoViable()
            {
                RazonNoViableID = RazonNoViableID,
                RazonNoViableClave = RazonNoViableClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.RazonNoViable Guardar(Cosmos.Academico.Admision.Entidades.RazonNoViable o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_RazonNoViable_Guardar", o.RazonNoViableID,
                                                                                  o.RazonNoViableClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["RazonNoViableID"]);
            }
            return o;
        }

        public static bool Eliminar(int RazonNoViableID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.RazonNoViable() { RazonNoViableID = RazonNoViableID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.RazonNoViable o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_RazonNoViable_Eliminar", o.RazonNoViableID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

        #region InitTests
        public static int InitTests()
        {

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_RazonNoViable");

            return rows;
        }
        #endregion

    }
}