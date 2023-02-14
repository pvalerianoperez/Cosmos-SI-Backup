using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Mensajeria.Comunica.Negocio
{
    public class Mensaje
    {


        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> Listado(bool conRegistrosBorrados)
        {
            List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje> lst = new List<Cosmos.Mensajeria.Comunica.Entidades.Mensaje>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_Mensaje_Listado", conRegistrosBorrados);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Comunica.Entidades.Mensaje o = new Cosmos.Mensajeria.Comunica.Entidades.Mensaje();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Consultar(int mensajeID, int remitenteID, DateTime fechaBorrado)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje() { MensajeID = mensajeID, RemitenteID = remitenteID, FechaBorrado = fechaBorrado });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Consultar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_Mensaje_ConsultarPorRemitente", o.MensajeID, o.RemitenteID, o.FechaBorrado);
            o = new Cosmos.Mensajeria.Comunica.Entidades.Mensaje();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public int MensajeID { get; set; }
        public int CanalComunicacionID { get; set; }
        public int TipoMensajeID { get; set; }
        public int RemitenteID { get; set; }
        public int DestinatarioID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaProgramadaEnvio { get; set; }
        public DateTime FechaEnviado { get; set; }
        public DateTime FechaLeido { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string Tema { get; set; }
        public string Body { get; set; }
        public bool RequiereAcuse { get; set; }
        public bool Acusado { get; set; }
        public string Error { get; set; }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Guardar(int mensajeID,
                                                                           int canalComunicacionID,
                                                                           int tipoMensajeID,
                                                                           int remitenteID,
                                                                           int destinatarioID,
                                                                           DateTime fechaProgramadaEnvio, 
                                                                           DateTime fechaEnviado,
                                                                           DateTime fechaLeido, 
                                                                           string tema, 
                                                                           string mensaje,
                                                                           bool requiereAcuse,
                                                                           bool acusado)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje()
            {
                MensajeID = mensajeID,
                CanalComunicacionID = canalComunicacionID,
                RemitenteID = remitenteID,
                DestinatarioID = destinatarioID,
                FechaProgramadaEnvio = fechaProgramadaEnvio,
                FechaEnviado = fechaEnviado,
                FechaLeido = fechaLeido,
                Tema = tema,
                Body = mensaje,
                RequiereAcuse = requiereAcuse,
                Acusado = acusado
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.Mensaje Guardar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_Mensaje_Guardar", o.MensajeID,
                                                                                          o.CanalComunicacionID,
                                                                                          o.RemitenteID,
                                                                                          o.DestinatarioID,
                                                                                          o.FechaProgramadaEnvio,
                                                                                          o.FechaEnviado,
                                                                                          o.FechaLeido,
                                                                                          o.Tema,
                                                                                          o.Body,
                                                                                          o.RequiereAcuse,
                                                                                          o.Acusado);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                //o = Consultar((int)dr["MensajeID"]);
            }
            return o;
        }

        public static bool Eliminar(int mensajeID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.Mensaje() { MensajeID = mensajeID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.Mensaje o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_Mensaje_Eliminar", o.MensajeID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

    }
}

