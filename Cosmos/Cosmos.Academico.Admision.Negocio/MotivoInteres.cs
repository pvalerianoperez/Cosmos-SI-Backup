using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class MotivoInteres
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoInteres> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.MotivoInteres> lst = new List<Cosmos.Academico.Admision.Entidades.MotivoInteres>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoInteres_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.MotivoInteres o = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Consultar(int MotivoInteresID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoInteres() { MotivoInteresID = MotivoInteresID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Consultar(Cosmos.Academico.Admision.Entidades.MotivoInteres o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoInteres_Consultar", o.MotivoInteresID);
            o = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Guardar(int MotivoInteresID,
                                                                       string MotivoInteresClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoInteres()
            {
                MotivoInteresID = MotivoInteresID,
                MotivoInteresClave = MotivoInteresClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoInteres Guardar(Cosmos.Academico.Admision.Entidades.MotivoInteres o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoInteres_Guardar", o.MotivoInteresID,
                                                                                  o.MotivoInteresClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["MotivoInteresID"]);
            }
            return o;
        }

        public static bool Eliminar(int MotivoInteresID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoInteres() { MotivoInteresID = MotivoInteresID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoInteres o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoInteres_Eliminar", o.MotivoInteresID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_MotivoInteres");

            return rows;
        }
        #endregion

    }
}
