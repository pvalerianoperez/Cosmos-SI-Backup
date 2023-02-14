using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Admision.Negocio
{
    public class Vinculo
    {

        #region CRUD

        public static List<Cosmos.Academico.Admision.Entidades.Vinculo> Listado()
        {
            List<Cosmos.Academico.Admision.Entidades.Vinculo> lst = new List<Cosmos.Academico.Admision.Entidades.Vinculo>();
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Vinculo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Admision.Entidades.Vinculo o = new Cosmos.Academico.Admision.Entidades.Vinculo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Consultar(int VinculoID)
        {
            return Consultar(new Cosmos.Academico.Admision.Entidades.Vinculo() { VinculoID = VinculoID });
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Consultar(Cosmos.Academico.Admision.Entidades.Vinculo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Admision_Vinculo_Consultar", o.VinculoID);
            o = new Cosmos.Academico.Admision.Entidades.Vinculo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Guardar(int VinculoID,
                                                                       string VinculoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string descripcion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Admision.Entidades.Vinculo()
            {
                VinculoID = VinculoID,
                VinculoClave = VinculoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Admision.Entidades.Vinculo Guardar(Cosmos.Academico.Admision.Entidades.Vinculo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Vinculo_Guardar", o.VinculoID,
                                                                                  o.VinculoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["VinculoID"]);
            }
            return o;
        }

        public static bool Eliminar(int VinculoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Admision.Entidades.Vinculo() { VinculoID = VinculoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Admision.Entidades.Vinculo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Admision_Vinculo_Eliminar", o.VinculoID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Admision_Vinculo");

            return rows;
        }
        #endregion

    }
}