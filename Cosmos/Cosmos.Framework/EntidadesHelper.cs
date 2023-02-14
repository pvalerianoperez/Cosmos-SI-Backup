using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Framework
{
    public class EntidadesHelper
    {
        /// <summary>
        /// Busca el nombre de la columna que corresponde a la propiedad, es utilizado por las entidades para mapear 
        /// el contenido de una consulta SQL a la propiedad del objeto
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columna"></param>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static String ColumnaDatosPropiedadEntidad(DataRow dr, String columna, String tabla)
        {
            String r = "";
            if (tabla.StartsWith("Sistema"))
            {
                tabla = tabla.Replace("Sistema", "");
            }
            if (dr != null)
            {
                if (dr.Table != null)
                {
                    if (dr.Table.Columns[columna] != null)
                    {
                        r = columna;
                    }
                    else
                    {
                        columna = tabla + columna;
                        if (dr.Table.Columns[columna] != null)
                        {
                            r = columna;
                        }
                    }
                }
            }
            return r;
        }
    }
}
