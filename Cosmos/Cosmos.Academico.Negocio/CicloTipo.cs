
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class CicloTipo
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.CicloTipo> Listado()
        {
            List<Cosmos.Academico.Entidades.CicloTipo> lst = new List<Cosmos.Academico.Entidades.CicloTipo>();
            DataTable dt = SQLHelper.GetTable("Academico_CicloTipo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.CicloTipo o = new Cosmos.Academico.Entidades.CicloTipo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.CicloTipo Consultar(int CicloTipoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.CicloTipo() { CicloTipoID = CicloTipoID });
        }

        public static Cosmos.Academico.Entidades.CicloTipo Consultar(Cosmos.Academico.Entidades.CicloTipo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_CicloTipo_Consultar", o.CicloTipoID);
            o = new Cosmos.Academico.Entidades.CicloTipo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.CicloTipo Guardar(int CicloTipoID,
                                                                       string CicloTipoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.CicloTipo() { CicloTipoID = CicloTipoID, CicloTipoClave = CicloTipoClave, Nombre = nombre, NombreCorto = nombreCorto }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.CicloTipo Guardar(Cosmos.Academico.Entidades.CicloTipo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_CicloTipo_Guardar", o.CicloTipoID,
                                                                                  o.CicloTipoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CicloTipoID"]);
            }
            return o;
        }

        public static bool Eliminar(int CicloTipoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.CicloTipo() { CicloTipoID = CicloTipoID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.CicloTipo o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_CicloTipo_Eliminar", o.CicloTipoID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
