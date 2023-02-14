
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class PeriodoVacacional
    {
        #region Columnas

        //[PeriodoVacacionalID] INT NOT NULL IDENTITY,
        //[PeriodoVacacionalClave] VARCHAR(6)  NULL,
        //[Nombre] VARCHAR(80) NOT NULL,
        //[NombreCorto]            VARCHAR(15) NULL,
        //[Descripcion] VARCHAR(150) NULL,
        //[CicloID] INT NOT NULL,
        //[FechaInicio] DATETIME NOT NULL,
        //[FechaFinal] DATETIME NOT NULL,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.PeriodoVacacional> Listado()
        {
            List<Cosmos.Academico.Entidades.PeriodoVacacional> lst = new List<Cosmos.Academico.Entidades.PeriodoVacacional>();
            DataTable dt = SQLHelper.GetTable("Academico_PeriodoVacacional_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.PeriodoVacacional o = new Cosmos.Academico.Entidades.PeriodoVacacional();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.PeriodoVacacional Consultar(int PeriodoVacacionalID)
        {
            return Consultar(new Cosmos.Academico.Entidades.PeriodoVacacional() { PeriodoVacacionalID = PeriodoVacacionalID });
        }

        public static Cosmos.Academico.Entidades.PeriodoVacacional Consultar(Cosmos.Academico.Entidades.PeriodoVacacional o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_PeriodoVacacional_Consultar", o.PeriodoVacacionalID);
            o = new Cosmos.Academico.Entidades.PeriodoVacacional();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.PeriodoVacacional Guardar(int PeriodoVacacionalID,
                                                                           string PeriodoVacacionalClave,
                                                                           string nombre,
                                                                           string nombreCorto,
                                                                           string descripcion,
                                                                           int CicloID,
                                                                           DateTime FechaInicio,
                                                                           DateTime FechaFinal,
                                                                           Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.PeriodoVacacional() { PeriodoVacacionalID = PeriodoVacacionalID,
                                                                                PeriodoVacacionalClave = PeriodoVacacionalClave,
                                                                                Nombre = nombre,
                                                                                NombreCorto = nombreCorto,
                                                                                Descripcion = descripcion,
                                                                                CicloID = CicloID,
                                                                                FechaInicio = FechaInicio,
                                                                                FechaFinal = FechaFinal,
                                                                            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.PeriodoVacacional Guardar(Cosmos.Academico.Entidades.PeriodoVacacional o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PeriodoVacacional_Guardar", o.PeriodoVacacionalID,
                                                                                  o.PeriodoVacacionalClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  o.CicloID,
                                                                                  o.FechaInicio,
                                                                                  o.FechaFinal,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["PeriodoVacacionalID"]);
            }
            return o;
        }

        public static bool Eliminar(int PeriodoVacacionalID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.PeriodoVacacional() { PeriodoVacacionalID = PeriodoVacacionalID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.PeriodoVacacional o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PeriodoVacacional_Eliminar", o.PeriodoVacacionalID,
                                                                                        oInfoForLog.UsuarioIDForLog,
                                                                                        oInfoForLog.DescripcionForLog,
                                                                                        oInfoForLog.IpAddressForLog,
                                                                                        oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
