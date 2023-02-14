
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class ProgramaEstudio
    {
        #region Columnas

        //[ProgramaEstudioID] INT NOT NULL IDENTITY,
        //[PlanEstudioID]         INT NOT NULL,
        //[AsignaturaID] INT NOT NULL,
        //[Clave] VARCHAR(6) NULL,
        //[ProgramaEstudioTipoID] INT NOT NULL,
        //[AreaFormacionID] INT NOT NULL,
        //[HorasTeoria]
        //INT NULL,
        //[HorasPractica]         INT NULL,
        //[HorasTotales]          INT NULL,
        //[Creditos]              INT NULL,
        //[DuracionSemanas]       INT NULL,
        //[Grado] INT NULL,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.ProgramaEstudio> Listado()
        {
            List<Cosmos.Academico.Entidades.ProgramaEstudio> lst = new List<Cosmos.Academico.Entidades.ProgramaEstudio>();
            DataTable dt = SQLHelper.GetTable("Academico_ProgramaEstudio_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.ProgramaEstudio o = new Cosmos.Academico.Entidades.ProgramaEstudio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.ProgramaEstudio Consultar(int ProgramaEstudioID)
        {
            return Consultar(new Cosmos.Academico.Entidades.ProgramaEstudio() { ProgramaEstudioID = ProgramaEstudioID });
        }

        public static Cosmos.Academico.Entidades.ProgramaEstudio Consultar(Cosmos.Academico.Entidades.ProgramaEstudio o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_ProgramaEstudio_Consultar", o.ProgramaEstudioID);
            o = new Cosmos.Academico.Entidades.ProgramaEstudio();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.ProgramaEstudio Guardar(int ProgramaEstudioID,
                                                                           int PlanEstudioID,
                                                                           int AsignaturaID,
                                                                           string clave,
                                                                           int ProgramaEstudioTipoID,
                                                                           int AreaFormacionID,
                                                                           int HorasTeoria,
                                                                           int HorasPractica,
                                                                           int HorasTotales,
                                                                           int Creditos,
                                                                           int DuracionSemanas,
                                                                           int Grado,
                                                                           Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.ProgramaEstudio()
                                                                            {
                                                                                ProgramaEstudioID = ProgramaEstudioID,
                                                                                PlanEstudioID = PlanEstudioID,
                                                                                AsignaturaID = AsignaturaID,
                                                                                Clave = clave,
                                                                                ProgramaEstudioTipoID = ProgramaEstudioTipoID,
                                                                                AreaFormacionID = AreaFormacionID,
                                                                                HorasTeoria = HorasTeoria,
                                                                                HorasPractica = HorasPractica,
                                                                                HorasTotales = HorasTotales,
                                                                                Creditos = Creditos,
                                                                                DuracionSemanas = DuracionSemanas,
                                                                                Grado = Grado
                                                                            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.ProgramaEstudio Guardar(Cosmos.Academico.Entidades.ProgramaEstudio o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_ProgramaEstudio_Guardar", o.ProgramaEstudioID,
                                                                                  o.PlanEstudioID,
                                                                                  o.AsignaturaID,
                                                                                  o.Clave,
                                                                                  o.ProgramaEstudioTipoID,
                                                                                  o.AreaFormacionID,
                                                                                  o.HorasTeoria,
                                                                                  o.HorasPractica,
                                                                                  o.HorasTotales,
                                                                                  o.Creditos,
                                                                                  o.DuracionSemanas,
                                                                                  o.Grado,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["ProgramaEstudioID"]);
            }
            return o;
        }

        public static bool Eliminar(int ProgramaEstudioID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.ProgramaEstudio() { ProgramaEstudioID = ProgramaEstudioID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.ProgramaEstudio o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_ProgramaEstudio_Eliminar", o.ProgramaEstudioID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
