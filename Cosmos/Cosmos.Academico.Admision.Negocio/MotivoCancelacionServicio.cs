using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class MotivoCancelacionServicio
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> lst = new List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoCancelacionServicio_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Consultar(int MotivoCancelacionServicioID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio() { MotivoCancelacionServicioID = MotivoCancelacionServicioID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Consultar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoCancelacionServicio_Consultar", o.MotivoCancelacionServicioID);
            o = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Guardar(int MotivoCancelacionServicioID,
                                                                       string MotivoCancelacionServicioClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio()
            {
                MotivoCancelacionServicioID = MotivoCancelacionServicioID,
                MotivoCancelacionServicioClave = MotivoCancelacionServicioClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio Guardar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoCancelacionServicio_Guardar", o.MotivoCancelacionServicioID,
                                                                                  o.MotivoCancelacionServicioClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["MotivoCancelacionServicioID"]);
            }
            return o;
        }

        public static bool Eliminar(int MotivoCancelacionServicioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio() { MotivoCancelacionServicioID = MotivoCancelacionServicioID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoCancelacionServicio_Eliminar", o.MotivoCancelacionServicioID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_MotivoCancelacionServicio");

            return rows;
        }
        #endregion

    }
}
