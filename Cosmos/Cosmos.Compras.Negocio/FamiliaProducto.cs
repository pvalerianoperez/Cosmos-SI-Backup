
using Cosmos.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Cosmos.Compras.Negocio
{
    public class FamiliaProducto
    {
        #region CRUD

        public static List<Cosmos.Compras.Entidades.FamiliaProducto> Listado()
        {
            List<Cosmos.Compras.Entidades.FamiliaProducto> lst = new List<Cosmos.Compras.Entidades.FamiliaProducto>();
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.FamiliaProducto o = new Cosmos.Compras.Entidades.FamiliaProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Compras.Entidades.FamiliaProducto Consultar(int familiaProductoID)
        {
            return Consultar(new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID });
        }

        public static Cosmos.Compras.Entidades.FamiliaProducto Consultar(Cosmos.Compras.Entidades.FamiliaProducto o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_Consultar", o.FamiliaProductoID);
            o = new Cosmos.Compras.Entidades.FamiliaProducto();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Compras.Entidades.FamiliaProducto Guardar(int modificacionUsuarioID, int familiaProductoID, int padreID, string familiaClave, string familiaClavePadre, string nombre, string nombreCorto)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID, PadreID = padreID, FamiliaClave = familiaClave, FamiliaClavePadre = familiaClavePadre, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Compras.Entidades.FamiliaProducto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.FamiliaProducto o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_FamiliaProducto_Guardar", modificacionUsuarioID, o.FamiliaProductoID, o.PadreID, o.FamiliaClave, o.FamiliaClavePadre, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["FamiliaProductoID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int familiaProductoID, int padreID, string familiaClave, string familiaClavePadre, string nombre, string nombreCorto)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.FamiliaProducto() { FamiliaProductoID = familiaProductoID, PadreID = padreID, FamiliaClave = familiaClave, FamiliaClavePadre = familiaClavePadre, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.FamiliaProducto o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_FamiliaProducto_Eliminar", modificacionUsuarioID, o.FamiliaProductoID, o.PadreID, o.FamiliaClave, o.FamiliaClavePadre, o.Nombre, o.NombreCorto);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion


        public static List<Entidades.FamiliaProducto> ListadoSubFamilia(int padreID)
        {
            List<Cosmos.Compras.Entidades.FamiliaProducto> lst = new List<Cosmos.Compras.Entidades.FamiliaProducto>();
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_ListadoSubFamilia");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.FamiliaProducto o = new Cosmos.Compras.Entidades.FamiliaProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;            
        }
        public static void CambiarPadre(int familiaProductoID, int padreID)
        {
            string s = "null";
            if (padreID > 0) { s = padreID.ToString(); }
            SQLHelper.ExecuteNonQuery("Compras_FamiliaProducto_CambiarPadre", familiaProductoID, padreID);
        }

    }
}
