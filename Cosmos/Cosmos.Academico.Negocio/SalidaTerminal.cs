using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class SalidaTerminal
    {
        #region Columnas

    //  [SalidaTerminalID] INT NOT NULL PRIMARY KEY IDENTITY,
    //  [SalidaTerminalClave] VARCHAR(6) NULL, 
    //  [Nombre] VARCHAR(80) NOT NULL,
    //  [NombreCorto] VARCHAR(15) NULL, 
    //  [Descripcion] VARCHAR(150) NULL, 
    //  [PlanEstudioID] INT NOT NULL, 
    //  [Activa] BIT NOT NULL DEFAULT 1,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.SalidaTerminal> Listado()
        {
            List<Cosmos.Academico.Entidades.SalidaTerminal> lst = new List<Cosmos.Academico.Entidades.SalidaTerminal>();
            DataTable dt = SQLHelper.GetTable("Academico_SalidaTerminal_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.SalidaTerminal o = new Cosmos.Academico.Entidades.SalidaTerminal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.SalidaTerminal Consultar(int SalidaTerminalID)
        {
            return Consultar(new Cosmos.Academico.Entidades.SalidaTerminal() { SalidaTerminalID = SalidaTerminalID });
        }

        public static Cosmos.Academico.Entidades.SalidaTerminal Consultar(Cosmos.Academico.Entidades.SalidaTerminal o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_SalidaTerminal_Consultar", o.SalidaTerminalID);
            o = new Cosmos.Academico.Entidades.SalidaTerminal();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.SalidaTerminal Guardar(int SalidaTerminalID,
                                                                       string SalidaTerminalClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string Descripcion,
                                                                       int PlanEstudioID,
                                                                       bool Activa,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.SalidaTerminal()
            {
                SalidaTerminalID = SalidaTerminalID,
                SalidaTerminalClave = SalidaTerminalClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = Descripcion,
                PlanEstudioID = PlanEstudioID,
                Activa = Activa
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.SalidaTerminal Guardar(Cosmos.Academico.Entidades.SalidaTerminal o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_SalidaTerminal_Guardar", o.SalidaTerminalID,
                                                                                  o.SalidaTerminalClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  o.PlanEstudioID,
                                                                                  o.Activa,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["SalidaTerminalID"]);
            }
            return o;
        }

        public static bool Eliminar(int SalidaTerminalID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.SalidaTerminal() { SalidaTerminalID = SalidaTerminalID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.SalidaTerminal o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_SalidaTerminal_Eliminar", o.SalidaTerminalID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
