
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class OfertaAcademica
    {
        #region Columnas

        //[OfertaAcademicaID] INT NOT NULL PRIMARY KEY IDENTITY,
        //[CicloID] INT NOT NULL, 
        //[PlantelID] INT NOT NULL, 
        //[SeccionID] INT NOT NULL, 

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.OfertaAcademica> Listado()
        {
            List<Cosmos.Academico.Entidades.OfertaAcademica> lst = new List<Cosmos.Academico.Entidades.OfertaAcademica>();
            DataTable dt = SQLHelper.GetTable("Academico_OfertaAcademica_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.OfertaAcademica o = new Cosmos.Academico.Entidades.OfertaAcademica();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.OfertaAcademica Consultar(int OfertaAcademicaID)
        {
            return Consultar(new Cosmos.Academico.Entidades.OfertaAcademica() { OfertaAcademicaID = OfertaAcademicaID });
        }

        public static Cosmos.Academico.Entidades.OfertaAcademica Consultar(Cosmos.Academico.Entidades.OfertaAcademica o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_OfertaAcademica_Consultar", o.OfertaAcademicaID);
            o = new Cosmos.Academico.Entidades.OfertaAcademica();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.OfertaAcademica Guardar(int OfertaAcademicaID,
                                                                         int CicloID,
                                                                         int PlantelID,
                                                                         int SeccionID,
                                                                         Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.OfertaAcademica() { OfertaAcademicaID = OfertaAcademicaID, CicloID = CicloID, PlantelID = PlantelID, SeccionID = SeccionID }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.OfertaAcademica Guardar(Cosmos.Academico.Entidades.OfertaAcademica o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_OfertaAcademica_Guardar", o.OfertaAcademicaID,
                                                                                  o.CicloID,
                                                                                  o.PlantelID,
                                                                                  o.SeccionID,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["OfertaAcademicaID"]);
            }
            return o;
        }

        public static bool Eliminar(int OfertaAcademicaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.OfertaAcademica() { OfertaAcademicaID = OfertaAcademicaID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.OfertaAcademica o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_OfertaAcademica_Eliminar", o.OfertaAcademicaID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
