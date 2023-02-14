
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;



namespace Cosmos.Mensajeria.Chat.Negocio
{
    public class Conversacion
    {

        #region CRUD

        public static List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> Listado()
        {
            List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> lst = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_Conversacion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.Conversacion o = new Cosmos.Mensajeria.Chat.Entidades.Conversacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Consultar(int conversacionID, bool conParticipantes)
        {
            return Consultar(new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = conversacionID }, conParticipantes);
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Consultar(Cosmos.Mensajeria.Chat.Entidades.Conversacion o, bool ConParticipantes)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_Conversacion_Consultar", o.ConversacionID);
            o = new Cosmos.Mensajeria.Chat.Entidades.Conversacion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }

            if (ConParticipantes == true)
            {
                o.Participantes = Cosmos.Mensajeria.Chat.Negocio.Conversacion.Listado_Participantes(o.ConversacionID);
            }

            return o;
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Guardar(int modificacionUsuarioID, int conversacionID, string nombre)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = conversacionID, Nombre = nombre});
        }

        public static Cosmos.Mensajeria.Chat.Entidades.Conversacion Guardar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.Conversacion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_Conversacion_Guardar", modificacionUsuarioID, o.ConversacionID, o.Nombre);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Guardar(modificacionUsuarioID, o);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int ConversacionID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Mensajeria.Chat.Entidades.Conversacion() { ConversacionID = ConversacionID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Mensajeria.Chat.Entidades.Conversacion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Chat_Conversacion_Eliminar", modificacionUsuarioID, o.ConversacionID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static List<Cosmos.Mensajeria.Chat.Entidades.Participante> Listado_Participantes(int ConversacionID)
        {
            List<Cosmos.Mensajeria.Chat.Entidades.Participante> lst = new List<Cosmos.Mensajeria.Chat.Entidades.Participante>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Chat_ConversacionUsuario_Listado_xConversacionID", ConversacionID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.Participante o = new Cosmos.Mensajeria.Chat.Entidades.Participante();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> Conversaciones(int UsuarioID)
        {
            List<Cosmos.Mensajeria.Chat.Entidades.Conversacion> lst = new List<Cosmos.Mensajeria.Chat.Entidades.Conversacion>();
            DataTable dt = SQLHelper.GetTable("MMensajeria_Chat_ConversacionUsuario_Listado_xUsuarioID", UsuarioID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.Conversacion o = new Cosmos.Mensajeria.Chat.Entidades.Conversacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        /// <summary>
        /// Agrega a un participante a una conversación
        /// </summary>
        /// <returns>0 = Ok</returns>
        public int AgregarParicipante(int UsuarioID, int PermisoConversacionID)
        {
            int iError = 0;

            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }

            return iError;
        }

    }
}
