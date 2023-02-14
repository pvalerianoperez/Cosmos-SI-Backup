using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Negocio
{
    public class TipoDocumento
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.TipoDocumento> Listado()
        {
            List<Cosmos.Academico.Entidades.TipoDocumento> lst = new List<Cosmos.Academico.Entidades.TipoDocumento>();
            DataTable dt = SQLHelper.GetTable("Academico_TipoDocumento_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.TipoDocumento o = new Cosmos.Academico.Entidades.TipoDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Consultar(int TipoDocumentoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.TipoDocumento() { TipoDocumentoID = TipoDocumentoID });
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Consultar(Cosmos.Academico.Entidades.TipoDocumento o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_TipoDocumento_Consultar", o.TipoDocumentoID);
            o = new Cosmos.Academico.Entidades.TipoDocumento();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Guardar(int documentoID,
                                                                   string documentoClave,
                                                                   string nombre,
                                                                   string nombreCorto,
                                                                   string descripcion,
                                                                   Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.TipoDocumento()
            {
                TipoDocumentoID = documentoID,
                TipoDocumentoClave = documentoClave,
                Nombre = nombre,
                NombreCorto = nombreCorto,
                Descripcion = descripcion
            },
                                                                        oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.TipoDocumento Guardar(Cosmos.Academico.Entidades.TipoDocumento o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_TipoDocumento_Guardar", o.TipoDocumentoID,
                                                                              o.TipoDocumentoClave,
                                                                              o.Nombre,
                                                                              o.NombreCorto,
                                                                              o.Descripcion,
                                                                              oInfoForLog.UsuarioIDForLog,
                                                                              oInfoForLog.DescripcionForLog,
                                                                              oInfoForLog.IpAddressForLog,
                                                                              oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TipoDocumentoID"]);
            }
            return o;
        }

        public static bool Eliminar(int TipoDocumentoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.TipoDocumento() { TipoDocumentoID = TipoDocumentoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.TipoDocumento o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_TipoDocumento_Eliminar", o.TipoDocumentoID,
                                                                               oInfoForLog.UsuarioIDForLog,
                                                                               oInfoForLog.DescripcionForLog,
                                                                               oInfoForLog.IpAddressForLog,
                                                                               oInfoForLog.HostNameForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

        #region InitTests
        public static int InitTests()
        {

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_TipoDocumento");

            return rows;
        }
        #endregion

    }
}