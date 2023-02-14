
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class DiaAsueto
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.DiaAsueto> Listado()
        {
            List<Cosmos.Academico.Entidades.DiaAsueto> lst = new List<Cosmos.Academico.Entidades.DiaAsueto>();
            DataTable dt = SQLHelper.GetTable("Academico_DiaAsueto_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.DiaAsueto o = new Cosmos.Academico.Entidades.DiaAsueto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.DiaAsueto Consultar(int DiaAsuetoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.DiaAsueto() { DiaAsuetoID = DiaAsuetoID });
        }

        public static Cosmos.Academico.Entidades.DiaAsueto Consultar(Cosmos.Academico.Entidades.DiaAsueto o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_DiaAsueto_Consultar", o.DiaAsuetoID);
            o = new Cosmos.Academico.Entidades.DiaAsueto();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.DiaAsueto Guardar(int DiaAsuetoID,
                                                                       string DiaAsuetoClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.DiaAsueto() { DiaAsuetoID = DiaAsuetoID, DiaAsuetoClave = DiaAsuetoClave, Nombre = nombre, NombreCorto = nombreCorto }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.DiaAsueto Guardar(Cosmos.Academico.Entidades.DiaAsueto o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_DiaAsueto_Guardar", o.DiaAsuetoID,
                                                                                  o.DiaAsuetoClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["DiaAsuetoID"]);
            }
            return o;
        }

        public static bool Eliminar(int DiaAsuetoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.DiaAsueto() { DiaAsuetoID = DiaAsuetoID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.DiaAsueto o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_DiaAsueto_Eliminar", o.DiaAsuetoID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
