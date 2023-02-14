using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Idioma
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Idioma> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Idioma> lst = new List<Cosmos.Academico.Admision.Entidades.Idioma>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Idioma_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Idioma o = new Cosmos.Academico.Admision.Entidades.Idioma();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Idioma Consultar(int IdiomaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Idioma() { IdiomaID = IdiomaID });
        }

        public static Cosmos.Academico.Admision.Entidades.Idioma Consultar(Cosmos.Academico.Admision.Entidades.Idioma o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Idioma_Consultar", o.IdiomaID);
            o = new Cosmos.Academico.Admision.Entidades.Idioma();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Idioma Guardar(int IdiomaID,
                                                                       string IdiomaClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Idioma()
            {
                IdiomaID = IdiomaID,
                IdiomaClave = IdiomaClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Idioma Guardar(Cosmos.Academico.Admision.Entidades.Idioma o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Idioma_Guardar", o.IdiomaID,
                                                                                  o.IdiomaClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["IdiomaID"]);
            }
            return o;
        }

        public static bool Eliminar(int IdiomaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Idioma() { IdiomaID = IdiomaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Idioma o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Idioma_Eliminar", o.IdiomaID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Idioma");

            return rows;
        }
        #endregion

    }
}