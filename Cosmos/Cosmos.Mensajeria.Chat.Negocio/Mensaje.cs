
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Chat.Negocio
{
    public partial class Mensaje
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> Listado( bool ConRegistrosBorrados)
        {
            List<Cosmos.Mensajeria.Chat.Entidades.Mensaje> lst = new List<Cosmos.Mensajeria.Chat.Entidades.Mensaje>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_Mensaje_Listado", ConRegistrosBorrados);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.Mensaje o = new Cosmos.Mensajeria.Chat.Entidades.Mensaje();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Consultar(int MensajeID)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = MensajeID });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Consultar(Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_Mensaje_Consultar", o.MensajeID);
            o = new Cosmos.Mensajeria.Chat.Entidades.Mensaje();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Guardar(int modificacionUsuarioID, int mensajeID, int usuarioID, int conversacionID, int tipoMensajeID, string mensaje)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = mensajeID, UsuarioID = usuarioID, ConversacionID = conversacionID, TipoMensajeID = tipoMensajeID, ContentMensaje = mensaje });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje Guardar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_Mensaje_Guardar", modificacionUsuarioID, o.MensajeID, o.UsuarioID, o.ConversacionID, o.TipoMensajeID, o.ContentMensaje);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["MensajeID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int mensajeID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { MensajeID = mensajeID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_Mensaje_Eliminar", modificacionUsuarioID, o.MensajeID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje ConsultaMensajesXConversacion(int usuarioID, int conversacionID, Boolean consulta_sin_fecha)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.Mensaje() { UsuarioID = usuarioID, ConversacionID = conversacionID, Consulta_sin_Fecha = consulta_sin_fecha });
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Mensaje ConsultaMensajesXConversacion(Cosmos.Mensajeria.Chat.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_Mensaje_Consulta_Mensajes_xConversacion", o.UsuarioID, o.ConversacionID, o.Consulta_sin_Fecha);
            o = new Cosmos.Mensajeria.Chat.Entidades.Mensaje();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }


    }
}
