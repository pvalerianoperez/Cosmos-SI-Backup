using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Religion
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Religion> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Religion> lst = new List<Cosmos.Academico.Admision.Entidades.Religion>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Religion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Religion o = new Cosmos.Academico.Admision.Entidades.Religion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Consultar(int ReligionID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Religion() { ReligionID = ReligionID });
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Consultar(Cosmos.Academico.Admision.Entidades.Religion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Religion_Consultar", o.ReligionID);
            o = new Cosmos.Academico.Admision.Entidades.Religion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Guardar(int ReligionID,
                                                                       string ReligionClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Religion()
            {
                ReligionID = ReligionID,
                ReligionClave = ReligionClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Religion Guardar(Cosmos.Academico.Admision.Entidades.Religion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Religion_Guardar", o.ReligionID,
                                                                                  o.ReligionClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["ReligionID"]);
            }
            return o;
        }

        public static bool Eliminar(int ReligionID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Religion() { ReligionID = ReligionID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Religion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Religion_Eliminar", o.ReligionID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Religion");

            return rows;
        }
        #endregion

    }
}