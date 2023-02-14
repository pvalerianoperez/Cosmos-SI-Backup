
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class PlanEstudio
    {
        #region Columnas

        //[PlanEstudioID] INT NOT NULL IDENTITY,
        //[PlanEstudioClave]              VARCHAR(6)  NULL,
        //[Nombre] VARCHAR(80) NOT NULL,
        //[NombreCorto]                   VARCHAR(15) NULL,
        //[Descripcion] VARCHAR(150) NULL,
        //[SeccionID] INT NOT NULL,
        //[CalificacionMinimaAprobatoria] DECIMAL(5, 2)          NULL,
        //[CreditosParaAcreditar]

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.PlanEstudio> Listado()
        {
            List<Cosmos.Academico.Entidades.PlanEstudio> lst = new List<Cosmos.Academico.Entidades.PlanEstudio>();
            DataTable dt = SQLHelper.GetTable("Academico_PlanEstudio_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.PlanEstudio o = new Cosmos.Academico.Entidades.PlanEstudio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.PlanEstudio Consultar(int PlanEstudioID)
        {
            return Consultar(new Cosmos.Academico.Entidades.PlanEstudio() { PlanEstudioID = PlanEstudioID });
        }

        public static Cosmos.Academico.Entidades.PlanEstudio Consultar(Cosmos.Academico.Entidades.PlanEstudio o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_PlanEstudio_Consultar", o.PlanEstudioID);
            o = new Cosmos.Academico.Entidades.PlanEstudio();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.PlanEstudio Guardar(int PlanEstudioID,
                                                                       string PlanEstudioClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string Descripcion,
                                                                       int SeccionID,
                                                                       Decimal CalificacionMinimaAprobatoria,
                                                                       int CreditosParaAcreditar,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.PlanEstudio() {
                                                                            PlanEstudioID = PlanEstudioID,
                                                                            PlanEstudioClave = PlanEstudioClave,
                                                                            Nombre = nombre,
                                                                            NombreCorto = nombreCorto,
                                                                            Descripcion = Descripcion,
                                                                            SeccionID = SeccionID,
                                                                            CalificacionMinimaAprobatoria = CalificacionMinimaAprobatoria,
                                                                            CreditosParaAcreditar = CreditosParaAcreditar,
                                                                        }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.PlanEstudio Guardar(Cosmos.Academico.Entidades.PlanEstudio o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PlanEstudio_Guardar", o.PlanEstudioID,
                                                                                  o.PlanEstudioClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  o.SeccionID,
                                                                                  o.CalificacionMinimaAprobatoria,
                                                                                  o.CreditosParaAcreditar,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["PlanEstudioID"]);
            }
            return o;
        }

        public static bool Eliminar(int PlanEstudioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.PlanEstudio() { PlanEstudioID = PlanEstudioID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.PlanEstudio o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_PlanEstudio_Eliminar", o.PlanEstudioID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
