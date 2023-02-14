
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class Rvoe
    {
        #region Columnas

//      [RvoeID] INT NOT NULL IDENTITY,
//      [RvoeClave]       VARCHAR(6)  NULL,
//      [Nombre] VARCHAR(80) NULL,
//      [NombreCorto] VARCHAR(15) NULL,
//      [Registro] VARCHAR(50) NULL,
//      [FechaExpedicion]

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Rvoe> Listado()
        {
            List<Cosmos.Academico.Entidades.Rvoe> lst = new List<Cosmos.Academico.Entidades.Rvoe>();
            DataTable dt = SQLHelper.GetTable("Academico_Rvoe_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Rvoe o = new Cosmos.Academico.Entidades.Rvoe();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Rvoe Consultar(int RvoeID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Rvoe() { RvoeID = RvoeID });
        }

        public static Cosmos.Academico.Entidades.Rvoe Consultar(Cosmos.Academico.Entidades.Rvoe o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Rvoe_Consultar", o.RvoeID);
            o = new Cosmos.Academico.Entidades.Rvoe();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Rvoe Guardar(int RvoeID,
                                                                       string RvoeClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string Registro,
                                                                       DateTime FechaExpedicion,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Rvoe()
            {
                RvoeID = RvoeID,
                RvoeClave = RvoeClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Registro = Registro,
                FechaExpedicion = FechaExpedicion,
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Rvoe Guardar(Cosmos.Academico.Entidades.Rvoe o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Rvoe_Guardar", o.RvoeID,
                                                                                  o.RvoeClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Registro,
                                                                                  o.FechaExpedicion,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["RvoeID"]);
            }
            return o;
        }

        public static bool Eliminar(int RvoeID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.Rvoe() { RvoeID = RvoeID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.Rvoe o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Rvoe_Eliminar", o.RvoeID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
