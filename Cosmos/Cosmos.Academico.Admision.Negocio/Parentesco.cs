using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Parentesco
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Parentesco> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Parentesco> lst = new List<Cosmos.Academico.Admision.Entidades.Parentesco>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Parentesco_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Parentesco o = new Cosmos.Academico.Admision.Entidades.Parentesco();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Consultar(int ParentescoID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Parentesco() { ParentescoID = ParentescoID });
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Consultar(Cosmos.Academico.Admision.Entidades.Parentesco o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Parentesco_Consultar", o.ParentescoID);
            o = new Cosmos.Academico.Admision.Entidades.Parentesco();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Guardar(int ParentescoID,
                                                                       string ParentescoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Parentesco()
            {
                ParentescoID = ParentescoID,
                ParentescoClave = ParentescoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Parentesco Guardar(Cosmos.Academico.Admision.Entidades.Parentesco o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Parentesco_Guardar", o.ParentescoID,
                                                                                  o.ParentescoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["ParentescoID"]);
            }
            return o;
        }

        public static bool Eliminar(int ParentescoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Parentesco() { ParentescoID = ParentescoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Parentesco o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Parentesco_Eliminar", o.ParentescoID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Parentesco");

            return rows;
        }
        #endregion

    }
}