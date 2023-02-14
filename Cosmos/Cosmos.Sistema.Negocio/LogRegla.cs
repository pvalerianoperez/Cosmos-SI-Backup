using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Sistema.Negocio
{
    public  class LogRegla
    {

        #region CRUD

        public static List<Cosmos.Sistema.Entidades.LogRegla> Listado()
        {
            List<Cosmos.Sistema.Entidades.LogRegla> lst = new List<Cosmos.Sistema.Entidades.LogRegla>();
            DataTable dt = SQLHelper.GetTable("Sistema_Log_Regla_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.LogRegla o = new Cosmos.Sistema.Entidades.LogRegla();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Sistema.Entidades.LogRegla Consultar(int sistemaLogReglaID)
        {
            return Consultar(new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID });
        }

        public static Cosmos.Sistema.Entidades.LogRegla Consultar(Cosmos.Sistema.Entidades.LogRegla o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_Log_Regla_Consultar", o.SistemaLogReglaID);
            o = new Cosmos.Sistema.Entidades.LogRegla();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Sistema.Entidades.LogRegla Guardar(int modificacionUsuarioID, int sistemaLogReglaID, int userID, string tablanombre, Boolean c, Boolean r, Boolean u, Boolean d)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID, UserID = userID, TablaNombre = tablanombre, C = c, R = r, U = u, D = d });
        }

        public static Cosmos.Sistema.Entidades.LogRegla Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.LogRegla o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Log_Regla_Guardar", modificacionUsuarioID, o.SistemaLogReglaID, o.UserID, o.TablaNombre, o.C, o.R, o.U, o.D);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["SistemaLogReglaID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int sistemaLogReglaID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.LogRegla() { SistemaLogReglaID = sistemaLogReglaID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.LogRegla o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Log_Regla_Eliminar", modificacionUsuarioID, o.SistemaLogReglaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
