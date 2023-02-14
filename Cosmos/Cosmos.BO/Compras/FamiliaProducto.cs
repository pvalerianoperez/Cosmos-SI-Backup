using N400.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static N400.Framework.CastHelper;

namespace Cosmos.BO.Compras
{
    public class FamiliaProducto
    {
        public static List<Entidades.Compras.FamiliaProducto> Listado() {            
            List<Entidades.Compras.FamiliaProducto> lst = new List<Entidades.Compras.FamiliaProducto>();            
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Entidades.Compras.FamiliaProducto o = new Entidades.Compras.FamiliaProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
        public static List<Entidades.Compras.FamiliaProducto> ListadoSubFamilia(int padreID)
        {
            List<Entidades.Compras.FamiliaProducto> lst = new List<Entidades.Compras.FamiliaProducto>();
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_ListadoSubFamilia", padreID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entidades.Compras.FamiliaProducto o = new Entidades.Compras.FamiliaProducto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Entidades.Compras.FamiliaProducto Consultar(int familiaProductoID) {
            Entidades.Compras.FamiliaProducto o = new Entidades.Compras.FamiliaProducto();
            DataTable dt = SQLHelper.GetTable("Compras_FamiliaProducto_Consultar", familiaProductoID);
            if (dt != null && dt.Rows.Count>0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static void CambiarPadre(int familiaProductoID, int padreID) {
            string s = "null";
            if (padreID > 0) { s = padreID.ToString(); }
            SQLHelper.ExecuteNonQuery("Compras_FamiliaProducto_CambiarPadre", familiaProductoID, padreID);                       
        }

        public static int Guardar(int modificacionUsuarioID, int familiaProductoID, int padreID, string familiaClave, string nombre, string nombreCorto) {
            int id = 0;
            DataRow dr = SQLHelper.GetFirstRow("Compras_FamiliaProducto_Guardar", modificacionUsuarioID, familiaProductoID, familiaClave, nombre, nombreCorto);
            if (!Funciones.ErrorRespuestaSQL(dr)) {
                id = (int)dr["FamiliaProductoID"];
            }
            return id;
        }

        public static bool Eliminar(int modificacionUsuarioID, int familiaProductoID) {
            DataRow dr = SQLHelper.GetFirstRow("Compras_FamiliaProducto_Eliminar", modificacionUsuarioID, familiaProductoID);
            return Funciones.ErrorRespuestaSQL(dr);
        }

    }
}
