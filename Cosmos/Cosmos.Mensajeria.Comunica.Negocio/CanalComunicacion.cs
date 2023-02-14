using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;




namespace Cosmos.Mensajeria.Comunica.Negocio
{
    public class CanalComunicacion
    {


        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> Listado()
        {
            List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion> lst = new List<Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_CanalComunicacion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o = new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Consultar(int canalComunicacionID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion() { CanalComunicacionID = canalComunicacionID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Consultar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_CanalComunicacion_Consultar", o.CanalComunicacionID);
            o = new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public int CanalComunicacionID { get; set; }
        public string CanalComunicacionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Guardar(int canalComunicacionID, string canalComunicacionClave, string nombre, string nombreCorto, bool activo)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion()
            {
                CanalComunicacionID = canalComunicacionID, CanalComunicacionClave = canalComunicacionClave, Nombre = nombre, NombreCorto = nombreCorto, Activo = activo
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion Guardar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_CanalComunicacion_Guardar", o.CanalComunicacionID,
                                                                                          o.CanalComunicacionClave,
                                                                                          o.Nombre,
                                                                                          o.NombreCorto,
                                                                                          o.Activo);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["CanalComunicacionID"]);
            }
            return o;
        }

        public static bool Eliminar(int canalComunicacionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion() { CanalComunicacionID = canalComunicacionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.CanalComunicacion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_CanalComunicacion_Eliminar", o.CanalComunicacionID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

    }
}
