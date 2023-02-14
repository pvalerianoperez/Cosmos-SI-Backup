
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class Ciclo
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Ciclo> Listado()
        {
            List<Cosmos.Academico.Entidades.Ciclo> lst = new List<Cosmos.Academico.Entidades.Ciclo>();
            DataTable dt = SQLHelper.GetTable("Academico_Ciclo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Ciclo o = new Cosmos.Academico.Entidades.Ciclo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Ciclo Consultar(int CicloID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Ciclo() { CicloID = CicloID });
        }

        public static Cosmos.Academico.Entidades.Ciclo Consultar(Cosmos.Academico.Entidades.Ciclo o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Ciclo_Consultar", o.CicloID);
            o = new Cosmos.Academico.Entidades.Ciclo();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Ciclo Guardar(int CicloID, 
                                                               string CicloClave, 
                                                               string nombre, 
                                                               string nombreCorto,
                                                               string descripcion,
                                                               int CalendarioID,
                                                               DateTime FechaInicio,
                                                               DateTime FechaFinal,
                                                               int CicloIDAnterior,
                                                               int CicloTipoID,
                                                               Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Ciclo() {  CicloID = CicloID,
                                                                                            CicloClave = CicloClave,
                                                                                            Nombre = nombre,
                                                                                            NombreCorto = nombreCorto,
                                                                                            Descripcion = descripcion,
                                                                                            CalendarioID = CalendarioID,
                                                                                            FechaInicio = FechaInicio,
                                                                                            FechaFinal = FechaFinal,
                                                                                            CicloIDAnterior = CicloIDAnterior,
                                                                                            CicloTipoID = CicloTipoID
                                                                                         }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Ciclo Guardar(Cosmos.Academico.Entidades.Ciclo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Ciclo_Guardar",  
                                                o.CicloID, 
                                                o.CicloClave, 
                                                o.Nombre, 
                                                o.NombreCorto,
                                                o.Descripcion,
                                                o.CalendarioID,
                                                o.FechaInicio,
                                                o.FechaFinal,
                                                o.CicloIDAnterior,
                                                o.CicloTipoID,
                                                oInfoForLog
                                                );
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CicloID"]);
            }
            return o;
        }

        public static bool Eliminar(int CicloID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.Ciclo() { CicloID = CicloID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.Ciclo o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Ciclo_Eliminar", o.CicloID, oInfoForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion



        public static List<Cosmos.Academico.Entidades.Ciclo> Listado_xCalendarioID(int CalendarioID)
        {
            List<Cosmos.Academico.Entidades.Ciclo> lst = new List<Cosmos.Academico.Entidades.Ciclo>();
            DataTable dt = SQLHelper.GetTable("Academico_Ciclo_Listado_xCalendarioID", CalendarioID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Ciclo o = new Cosmos.Academico.Entidades.Ciclo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
    }
}
