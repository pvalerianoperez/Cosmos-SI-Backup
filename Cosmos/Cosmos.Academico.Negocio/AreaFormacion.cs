
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Negocio
{
    public class AreaFormacion
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.AreaFormacion> Listado()
        {
            List<Cosmos.Academico.Entidades.AreaFormacion> lst = new List<Cosmos.Academico.Entidades.AreaFormacion>();
            DataTable dt = SQLHelper.GetTable("Academico_AreaFormacion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.AreaFormacion o = new Cosmos.Academico.Entidades.AreaFormacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Consultar(int AreaFormacionID)
        {
            return Consultar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID } );
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Consultar(Cosmos.Academico.Entidades.AreaFormacion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_AreaFormacion_Consultar", o.AreaFormacionID);
            o = new Cosmos.Academico.Entidades.AreaFormacion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Guardar(int AreaFormacionID, 
                                                                       string AreaFormacionClave, 
                                                                       string nombre, 
                                                                       string nombreCorto,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID, AreaFormacionClave = AreaFormacionClave, Nombre = nombre, NombreCorto = nombreCorto }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.AreaFormacion Guardar(Cosmos.Academico.Entidades.AreaFormacion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_AreaFormacion_Guardar", o.AreaFormacionID,
                                                                                  o.AreaFormacionClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["AreaFormacionID"]);
            }
            return o;
        }

        public static bool Eliminar(int AreaFormacionID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.AreaFormacion() { AreaFormacionID = AreaFormacionID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.AreaFormacion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_AreaFormacion_Eliminar", o.AreaFormacionID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
