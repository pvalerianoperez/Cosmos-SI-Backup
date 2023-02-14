using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class NivelEducativo
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.NivelEducativo> Listado()
        {
            List<Cosmos.Academico.Entidades.NivelEducativo> lst = new List<Cosmos.Academico.Entidades.NivelEducativo>();
            DataTable dt = SQLHelper.GetTable("Academico_NivelEducativo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.NivelEducativo o = new Cosmos.Academico.Entidades.NivelEducativo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.NivelEducativo Consultar(int NivelEducativoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.NivelEducativo() { NivelEducativoID = NivelEducativoID });
        }

        public static Cosmos.Academico.Entidades.NivelEducativo Consultar(Cosmos.Academico.Entidades.NivelEducativo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_NivelEducativo_Consultar", o.NivelEducativoID);
            o = new Cosmos.Academico.Entidades.NivelEducativo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.NivelEducativo Guardar(int NivelEducativoID,
                                                                       string NivelEducativoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.NivelEducativo() { NivelEducativoID = NivelEducativoID, NivelEducativoClave = NivelEducativoClave, Nombre = nombre, NombreCorto = nombreCorto }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.NivelEducativo Guardar(Cosmos.Academico.Entidades.NivelEducativo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_NivelEducativo_Guardar", o.NivelEducativoID,
                                                                                  o.NivelEducativoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["NivelEducativoID"]);
            }
            return o;
        }

        public static bool Eliminar(int NivelEducativoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.NivelEducativo() { NivelEducativoID = NivelEducativoID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.NivelEducativo o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_NivelEducativo_Eliminar", o.NivelEducativoID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
