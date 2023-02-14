using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class TipoObservacion
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.TipoObservacion> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.TipoObservacion> lst = new List<Cosmos.Academico.Admision.Entidades.TipoObservacion>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_TipoObservacion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.TipoObservacion o = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Consultar(int TipoObservacionID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.TipoObservacion() { TipoObservacionID = TipoObservacionID });
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Consultar(Cosmos.Academico.Admision.Entidades.TipoObservacion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_TipoObservacion_Consultar", o.TipoObservacionID);
            o = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Guardar(int TipoObservacionID,
                                                                       string TipoObservacionClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.TipoObservacion()
            {
                TipoObservacionID = TipoObservacionID,
                TipoObservacionClave = TipoObservacionClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.TipoObservacion Guardar(Cosmos.Academico.Admision.Entidades.TipoObservacion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_TipoObservacion_Guardar", o.TipoObservacionID,
                                                                                  o.TipoObservacionClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TipoObservacionID"]);
            }
            return o;
        }

        public static bool Eliminar(int TipoObservacionID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.TipoObservacion() { TipoObservacionID = TipoObservacionID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.TipoObservacion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_TipoObservacion_Eliminar", o.TipoObservacionID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_TipoObservacion");

            return rows;
        }
        #endregion

    }
}
