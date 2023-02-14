using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class MotivoBaja
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.MotivoBaja> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.MotivoBaja> lst = new List<Cosmos.Academico.Admision.Entidades.MotivoBaja>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoBaja_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.MotivoBaja o = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Consultar(int MotivoBajaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.MotivoBaja() { MotivoBajaID = MotivoBajaID });
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Consultar(Cosmos.Academico.Admision.Entidades.MotivoBaja o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_MotivoBaja_Consultar", o.MotivoBajaID);
            o = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Guardar(int MotivoBajaID,
                                                                       string MotivoBajaClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.MotivoBaja()
            {
                MotivoBajaID = MotivoBajaID,
                MotivoBajaClave = MotivoBajaClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.MotivoBaja Guardar(Cosmos.Academico.Admision.Entidades.MotivoBaja o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoBaja_Guardar", o.MotivoBajaID,
                                                                                  o.MotivoBajaClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["MotivoBajaID"]);
            }
            return o;
        }

        public static bool Eliminar(int MotivoBajaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.MotivoBaja() { MotivoBajaID = MotivoBajaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.MotivoBaja o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_MotivoBaja_Eliminar", o.MotivoBajaID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_MotivoBaja");

            return rows;
        }
        #endregion

    }
}
