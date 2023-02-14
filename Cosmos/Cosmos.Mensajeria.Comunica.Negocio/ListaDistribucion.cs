using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Mensajeria.Comunica.Negocio
{
    public class ListaDistribucion
    {


        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> Listado()
        {
            List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion> lst = new List<Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_ListaDistribucion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o = new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Consultar(int listaDistribucionID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion() { ListaDistribucionID = listaDistribucionID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Consultar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_ListaDistribucion_Consultar", o.ListaDistribucionID);
            o = new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public int ListaDistribucionID { get; set; }
        public string ListaDistribucionClave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public Boolean Activa { get; set; }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Guardar(int listaDistribucionID, string listaDistribucionClave, string nombre, string nombreCorto)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion()
            {
                ListaDistribucionID = listaDistribucionID,
                ListaDistribucionClave = listaDistribucionClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion Guardar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_ListaDistribucion_Guardar", o.ListaDistribucionID,
                                                                                          o.ListaDistribucionClave,
                                                                                          o.Nombre,
                                                                                          o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["ListaDistribucionID"]);
            }
            return o;
        }

        public static bool Eliminar(int listaDistribucionID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion() { ListaDistribucionID = listaDistribucionID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.ListaDistribucion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_ListaDistribucion_Eliminar", o.ListaDistribucionID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

    }
}

