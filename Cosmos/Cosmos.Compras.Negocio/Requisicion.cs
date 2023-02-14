using Cosmos.Api.Entidades;
using Cosmos.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Compras.Negocio
{
    class Requisicion
    {
        /// <summary>
        /// Busqueda de requisiciones utilizando parametros
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static DataTable Busqueda(ConsultaDocumentos parametros)
        {
            //ejecuta la consulta
            return SQLHelper.GetTable("Compras_Requisicion_Busqueda",
                parametros.EmpresaID,
                parametros.SucursalID,
                parametros.FechaInicial,
                parametros.FechaFinal,
                "");
        }

        /// <summary>
        /// Consultar la requisicion
        /// </summary>
        /// <param name="requisicionEncabezadoID"></param>
        /// <returns></returns>
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(int requisicionEncabezadoID)
        {
            return Consultar(new Cosmos.Compras.Entidades.RequisicionEncabezado() { RequisicionEncabezadoID = requisicionEncabezadoID });
        }

        /// <summary>
        /// Consultar la requisicion
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Cosmos.Compras.Entidades.RequisicionEncabezado Consultar(Cosmos.Compras.Entidades.RequisicionEncabezado o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Requisicion_Consultar", o.RequisicionEncabezadoID);
            o = new Cosmos.Compras.Entidades.RequisicionEncabezado();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);                
                o.Detalles = ConsultarDetalle(o.RequisicionEncabezadoID);
            }
            return o;
        }

        /// <summary>
        /// Consultar el detalle de una requisicion
        /// </summary>
        /// <param name="requisicionEncabezadoID"></param>
        /// <returns></returns>
        public static List<Cosmos.Compras.Entidades.RequisicionDetalle> ConsultarDetalle(int requisicionEncabezadoID)
        {
            List<Cosmos.Compras.Entidades.RequisicionDetalle> lst = new List<Cosmos.Compras.Entidades.RequisicionDetalle>();
            DataTable dt = SQLHelper.GetTable("Compras_Requisicion_ConsultarDetalle", requisicionEncabezadoID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RequisicionDetalle o = new Cosmos.Compras.Entidades.RequisicionDetalle();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }


    }
}
