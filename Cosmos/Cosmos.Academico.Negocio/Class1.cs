
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;



namespace Cosmos.Academico.Negocio
{
    public class Class1
    {
        #region Columnas



        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Class1> Listado()
        {
            List<Cosmos.Academico.Entidades.Class1> lst = new List<Cosmos.Academico.Entidades.Class1>();
            DataTable dt = SQLHelper.GetTable("Academico_Class1_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Class1 o = new Cosmos.Academico.Entidades.Class1();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Class1 Consultar(int Class1ID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Class1() { Class1ID = Class1ID });
        }

        public static Cosmos.Academico.Entidades.Class1 Consultar(Cosmos.Academico.Entidades.Class1 o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Class1_Consultar", o.Class1ID);
            o = new Cosmos.Academico.Entidades.Class1();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Class1 Guardar(int Class1ID,
                                                                       string Class1Clave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Class1() { Class1ID = Class1ID,
                                                                     Class1Clave = Class1Clave,
                                                                     Nombre = nombre,
                                                                     NombreCorto = nombreCorto
                                                                  }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Class1 Guardar(Cosmos.Academico.Entidades.Class1 o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Class1_Guardar", o.Class1ID,
                                                                                  o.Class1Clave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["Class1ID"]);
            }
            return o;
        }

        public static bool Eliminar(int Class1ID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.Class1() { Class1ID = Class1ID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.Class1 o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Class1_Eliminar", o.Class1ID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
