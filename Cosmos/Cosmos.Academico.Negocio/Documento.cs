using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Cosmos.Seguridad.Entidades;

namespace Cosmos.Academico.Negocio
{
    public class Documento
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.Documento> Listado()
        {
            List<Cosmos.Academico.Entidades.Documento> lst = new List<Cosmos.Academico.Entidades.Documento>();
            DataTable dt = SQLHelper.GetTable("Academico_Documento_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.Documento o = new Cosmos.Academico.Entidades.Documento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.Documento Consultar(int DocumentoID)
        {
            return Consultar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = DocumentoID });
        }

        public static Cosmos.Academico.Entidades.Documento Consultar(Cosmos.Academico.Entidades.Documento o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Documento_Consultar", o.DocumentoID);
            o = new Cosmos.Academico.Entidades.Documento();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.Documento Guardar(int documentoID,
                                                                   string documentoClave,
                                                                   string nombre,
                                                                   string nombreCorto,
                                                                   string descripcion,
                                                                   Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = documentoID,
                                                                        DocumentoClave = documentoClave,
                                                                        Nombre = nombre,
                                                                        NombreCorto = nombreCorto,
                                                                        Descripcion = descripcion }, 
                                                                        oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.Documento Guardar(Cosmos.Academico.Entidades.Documento o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Documento_Guardar", o.DocumentoID,
                                                                              o.DocumentoClave,
                                                                              o.Nombre,
                                                                              o.NombreCorto,
                                                                              o.Descripcion,
                                                                              oInfoForLog.UsuarioIDForLog,
                                                                              oInfoForLog.DescripcionForLog,
                                                                              oInfoForLog.IpAddressForLog,
                                                                              oInfoForLog.HostNameForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["DocumentoID"]);
            }
            return o;
        }

        public static bool Eliminar(int DocumentoID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.Documento() { DocumentoID = DocumentoID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.Documento o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Documento_Eliminar", o.DocumentoID,
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

            int rows = SQLHelper.ExecuteNonQuery("Init_Academico_Documento");

            return rows;
        }
        #endregion

    }
}