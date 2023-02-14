using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Zona
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Zona> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Zona> lst = new List<Cosmos.Academico.Admision.Entidades.Zona>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Zona_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Zona o = new Cosmos.Academico.Admision.Entidades.Zona();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Zona Consultar(int ZonaID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Zona() { ZonaID = ZonaID });
        }

        public static Cosmos.Academico.Admision.Entidades.Zona Consultar(Cosmos.Academico.Admision.Entidades.Zona o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Zona_Consultar", o.ZonaID);
            o = new Cosmos.Academico.Admision.Entidades.Zona();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Zona Guardar(int zonaID,
                                                                       string zonaClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Zona()
            {
                ZonaID = zonaID,
                ZonaClave = zonaClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            },  oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Zona Guardar(Cosmos.Academico.Admision.Entidades.Zona o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Zona_Guardar", o.ZonaID,
                                                                                  o.ZonaClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["ZonaID"]);
            }
            return o;
        }

        public static bool Eliminar(int ZonaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Zona() { ZonaID = ZonaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Zona o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Zona_Eliminar", o.ZonaID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Zona");

            return rows;
        }
        #endregion

    }
}