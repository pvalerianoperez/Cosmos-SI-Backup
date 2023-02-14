using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Mensajeria.Comunica.Negocio
{
    public class ReporteEnvio
    {


        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> Listado()
        {
            List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio> lst = new List<Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_ReporteEnvio_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o = new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Consultar(int reporteEnvioID, int remitenteID, DateTime fechaInicial, DateTime fechaFinal)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio() { ReporteEnvioID = reporteEnvioID, RemitenteID = remitenteID, FechaInicial = fechaInicial, FechaFinal = fechaFinal });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Consultar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_ReporteEnvio_Consultar", o.ReporteEnvioID, o.RemitenteID, o.FechaInicial, o.FechaFinal);
            o = new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public int ReporteEnvioID { get; set; }
        public int RemitenteID { get; set; }
        public string Tema { get; set; }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Guardar( int reporteEnvioID,
                                                                                 int remitenteID,
                                                                                 string tema )
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio()
            {
                ReporteEnvioID = reporteEnvioID,
                RemitenteID = remitenteID,
                Tema = tema,
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio Guardar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_ReporteEnvio_Guardar", o.ReporteEnvioID,
                                                                                          o.RemitenteID,
                                                                                          o.Tema );
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                //o = Consultar((int)dr["ReporteEnvioID"]);
            }
            return o;
        }

        public static bool Eliminar(int reporteEnvioID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio() { ReporteEnvioID = reporteEnvioID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.ReporteEnvio o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_ReporteEnvio_Eliminar", o.ReporteEnvioID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

    }
}

