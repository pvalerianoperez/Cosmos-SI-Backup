using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class TipoRepresentanteFamilia
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> lst = new List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_TipoRepresentanteFamilia_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Consultar(int TipoRepresentanteFamiliaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia() { TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Consultar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_TipoRepresentanteFamilia_Consultar", o.TipoRepresentanteFamiliaID);
            o = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Guardar(int TipoRepresentanteFamiliaID,
                                                                       string TipoRepresentanteFamiliaClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia()
            {
                TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID,
                TipoRepresentanteFamiliaClave = TipoRepresentanteFamiliaClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia Guardar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_TipoRepresentanteFamilia_Guardar", o.TipoRepresentanteFamiliaID,
                                                                                  o.TipoRepresentanteFamiliaClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TipoRepresentanteFamiliaID"]);
            }
            return o;
        }

        public static bool Eliminar(int TipoRepresentanteFamiliaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia() { TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_TipoRepresentanteFamilia_Eliminar", o.TipoRepresentanteFamiliaID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_TipoRepresentanteFamilia");

            return rows;
        }
        #endregion

    }
}