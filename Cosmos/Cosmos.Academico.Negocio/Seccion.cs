
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class Seccion
    {
        #region Columnas

        //      [SeccionID] INT NOT NULL IDENTITY,
        //      [SeccionClave]     VARCHAR(6)   NULL,
        //      [Nombre] VARCHAR(80)  NOT NULL,
        //      [NombreCorto]      VARCHAR(15)  NULL,
        //      [Descripcion] VARCHAR(150) NULL,
        //      [NivelEducativoID] INT NOT NULL,

        #endregion

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Seccion> Listado()
        {
            List<Cosmos.Academico.Entidades.Seccion> lst = new List<Cosmos.Academico.Entidades.Seccion>();
            DataTable dt = SQLHelper.GetTable("Academico_Seccion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Seccion o = new Cosmos.Academico.Entidades.Seccion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Seccion Consultar(int SeccionID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Seccion() { SeccionID = SeccionID });
        }

        public static Cosmos.Academico.Entidades.Seccion Consultar(Cosmos.Academico.Entidades.Seccion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Seccion_Consultar", o.SeccionID);
            o = new Cosmos.Academico.Entidades.Seccion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Seccion Guardar(int SeccionID,
                                                                       string SeccionClave,
                                                                       string nombre,
                                                                       string nombreCorto,
                                                                       string Descripcion,
                                                                       int NivelEducativoID,
                                                                       Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Seccion()
            {
                SeccionID = SeccionID,
                SeccionClave = SeccionClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = Descripcion,
                NivelEducativoID = NivelEducativoID
            }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Seccion Guardar(Cosmos.Academico.Entidades.Seccion o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Seccion_Guardar", o.SeccionID,
                                                                                  o.SeccionClave,
                                                                                  o.Nombre,
                                                                                  o.NombreCorto,
                                                                                  o.Descripcion,
                                                                                  o.NivelEducativoID,
                                                                                  oInfoForLog.UsuarioIDForLog,
                                                                                  oInfoForLog.DescripcionForLog,
                                                                                  oInfoForLog.IpAddressForLog,
                                                                                  oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["SeccionID"]);
            }
            return o;
        }

        public static bool Eliminar(int SeccionID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(oInfoForLog, new Cosmos.Academico.Entidades.Seccion() { SeccionID = SeccionID });
        }

        public static bool Eliminar(Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, Cosmos.Academico.Entidades.Seccion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Seccion_Eliminar", o.SeccionID,
                                                                                   oInfoForLog.UsuarioIDForLog,
                                                                                   oInfoForLog.DescripcionForLog,
                                                                                   oInfoForLog.IpAddressForLog,
                                                                                   oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
