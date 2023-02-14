
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class PeriodoEvaluacion
    {
        #region Columnas

        //    [PeriodoEvaluacionID] INT NOT NULL IDENTITY,
        //    [PeriodoEvaluacionClave]      VARCHAR(6)  NULL,
        //    [Nombre] VARCHAR(80) NOT NULL,
        //    [NombreCorto]                 VARCHAR(15) NULL,
        //    [Descripcion] VARCHAR(150) NULL,
        //    [PeriodoEvaluacionIDAnterior]
        //    [FechaInicio]                 DATETIME NOT NULL,
        //    [FechaFinal] DATETIME NOT NULL,
        //    [CicloID] INT NOT NULL,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.PeriodoEvaluacion> Listado()
        {
            List<Cosmos.Academico.Entidades.PeriodoEvaluacion> lst = new List<Cosmos.Academico.Entidades.PeriodoEvaluacion>();
            DataTable dt = SQLHelper.GetTable("Academico_PeriodoEvaluacion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.PeriodoEvaluacion o = new Cosmos.Academico.Entidades.PeriodoEvaluacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.PeriodoEvaluacion Consultar(int PeriodoEvaluacionID)
        {
            return Consultar(new Cosmos.Academico.Entidades.PeriodoEvaluacion() { PeriodoEvaluacionID = PeriodoEvaluacionID });
        }

        public static Cosmos.Academico.Entidades.PeriodoEvaluacion Consultar(Cosmos.Academico.Entidades.PeriodoEvaluacion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_PeriodoEvaluacion_Consultar", o.PeriodoEvaluacionID);
            o = new Cosmos.Academico.Entidades.PeriodoEvaluacion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.PeriodoEvaluacion Guardar(int PeriodoEvaluacionID,
                                                                           string PeriodoEvaluacionClave,
                                                                           string nombre,
                                                                           string nombreCorto,
                                                                           string descripcion,
                                                                           int PeriodoEvaluacionIDAnterior,
                                                                           DateTime FechaInicio,
                                                                           DateTime FechaFinal,
                                                                           int CicloID,
                                                                           Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.PeriodoEvaluacion() { PeriodoEvaluacionID = PeriodoEvaluacionID,
                                                                                PeriodoEvaluacionClave = PeriodoEvaluacionClave,
                                                                                Nombre = nombre,
                                                                                NombreCorto = nombreCorto,
                                                                                Descripcion = descripcion,
                                                                                PeriodoEvaluacionIDAnterior = PeriodoEvaluacionIDAnterior,
                                                                                FechaInicio = FechaInicio,
                                                                                FechaFinal = FechaFinal,
                                                                                CicloID = CicloID,
                                                                            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.PeriodoEvaluacion Guardar(Cosmos.Academico.Entidades.PeriodoEvaluacion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PeriodoEvaluacion_Guardar", o.PeriodoEvaluacionID,
                                                                                      o.PeriodoEvaluacionClave,
                                                                                      o.Nombre,
                                                                                      o.NombreCorto,
                                                                                      o.Descripcion,
                                                                                      o.PeriodoEvaluacionIDAnterior,
                                                                                      o.FechaInicio,
                                                                                      o.FechaFinal,
                                                                                      o.CicloID,
                                                                                      oInfoForLog.UsuarioIDForLog,
                                                                                      oInfoForLog.DescripcionForLog,
                                                                                      oInfoForLog.IpAddressForLog,
                                                                                      oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["PeriodoEvaluacionID"]);
            }
            return o;
        }

        public static bool Eliminar(int PeriodoEvaluacionID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.PeriodoEvaluacion() { PeriodoEvaluacionID = PeriodoEvaluacionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.PeriodoEvaluacion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PeriodoEvaluacion_Eliminar", o.PeriodoEvaluacionID,
                                                                                        oInfoForLog.UsuarioIDForLog,
                                                                                        oInfoForLog.DescripcionForLog,
                                                                                        oInfoForLog.IpAddressForLog,
                                                                                        oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
