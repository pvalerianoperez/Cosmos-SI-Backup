
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Chat.Negocio
{
    public partial class TipoMensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> Listado()
        {
            List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje> lst = new List<Cosmos.Mensajeria.Chat.Entidades.TipoMensaje>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_TipoMensaje_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o = new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Consultar(int TipoMensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = TipoMensajeID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Consultar(Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_TipoMensaje_Consultar", o.TipoMensajeID);
            o = new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Guardar(int modificacionUsuarioID, int TipoMensajeID, string nombre, string nombreCorto)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = TipoMensajeID, TipoNombre = nombre });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.TipoMensaje Guardar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_TipoMensaje_Guardar", modificacionUsuarioID, o.TipoMensajeID, o.TipoNombre);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TipoMensajeID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int TipoMensajeID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.TipoMensaje() { TipoMensajeID = TipoMensajeID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.TipoMensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_TipoMensaje_Eliminar", modificacionUsuarioID, o.TipoMensajeID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion


    }
}
