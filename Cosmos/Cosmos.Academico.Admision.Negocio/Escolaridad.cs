using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Escolaridad
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Escolaridad> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Escolaridad> lst = new List<Cosmos.Academico.Admision.Entidades.Escolaridad>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Escolaridad_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Escolaridad o = new Cosmos.Academico.Admision.Entidades.Escolaridad();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Consultar(int EscolaridadID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Escolaridad() { EscolaridadID = EscolaridadID });
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Consultar(Cosmos.Academico.Admision.Entidades.Escolaridad o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Escolaridad_Consultar", o.EscolaridadID);
            o = new Cosmos.Academico.Admision.Entidades.Escolaridad();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Guardar(int EscolaridadID,
                                                                       string EscolaridadClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Escolaridad()
            {
                EscolaridadID = EscolaridadID,
                EscolaridadClave = EscolaridadClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Escolaridad Guardar(Cosmos.Academico.Admision.Entidades.Escolaridad o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Escolaridad_Guardar", o.EscolaridadID,
                                                                                  o.EscolaridadClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["EscolaridadID"]);
            }
            return o;
        }

        public static bool Eliminar(int EscolaridadID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Escolaridad() { EscolaridadID = EscolaridadID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Escolaridad o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Escolaridad_Eliminar", o.EscolaridadID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Escolaridad");

            return rows;
        }
        #endregion

    }
}