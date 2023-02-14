
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Academico.Negocio
{
    public class InstitucionEducativa
    {

        #region CRUD

        public static List<Cosmos.Academico.Entidades.InstitucionEducativa> Listado()
        {
            List<Cosmos.Academico.Entidades.InstitucionEducativa> lst = new List<Cosmos.Academico.Entidades.InstitucionEducativa>();
            DataTable dt = SQLHelper.GetTable("Academico_Institucion_Educativa_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Academico.Entidades.InstitucionEducativa o = new Cosmos.Academico.Entidades.InstitucionEducativa();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Consultar(int institucionEducativaID)
        {
            return Consultar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = institucionEducativaID });
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Consultar(Cosmos.Academico.Entidades.InstitucionEducativa o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Academico_Institucion_Educativa_Consultar", o.InstitucionEducativaID);
            o = new Cosmos.Academico.Entidades.InstitucionEducativa();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Guardar(int institucionEducativaID, 
                                                                              string institucionEducativaClave, 
                                                                              string nombre, 
                                                                              string nombreCorto,
                                                                              string extraTexto1,
                                                                              string extraTexto2,
                                                                              string extraTexto3,
                                                                              DateTime extraFecha1,
                                                                              DateTime extraFecha2,
                                                                              Decimal extraDecimal1,
                                                                              Decimal extraDecimal2,
                                                                              Decimal extraDecimal3,
                                                                              Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Guardar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = institucionEducativaID,
                                                                                   InstitucionEducativaClave = institucionEducativaClave,
                                                                                   Nombre = nombre,
                                                                                   NombreCorto = nombreCorto,
                                                                                   ExtraTexto1 = extraTexto1,
                                                                                   ExtraTexto2 = extraTexto2,
                                                                                   ExtraTexto3 = extraTexto3,
                                                                                   ExtraFecha1 = extraFecha1,
                                                                                   ExtraFecha2 = extraFecha2,
                                                                                   ExtraDecimal1 = extraDecimal1,
                                                                                   ExtraDecimal2 = extraDecimal2,
                                                                                   ExtraDecimal3 = extraDecimal3
                                                                                 }, oInfoForLog);
        }

        public static Cosmos.Academico.Entidades.InstitucionEducativa Guardar(Cosmos.Academico.Entidades.InstitucionEducativa o,
                                                                              Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Institucion_Educativa_Guardar", o.InstitucionEducativaID, 
                                                                                          o.InstitucionEducativaClave, 
                                                                                          o.Nombre,
                                                                                          o.NombreCorto,
                                                                                          o.ExtraTexto1,
                                                                                          o.ExtraTexto2,
                                                                                          o.ExtraTexto3,
                                                                                          o.ExtraFecha1,
                                                                                          o.ExtraFecha2,
                                                                                          o.ExtraDecimal1,
                                                                                          o.ExtraDecimal2,
                                                                                          o.ExtraDecimal3,
                                                                                          oInfoForLog);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["InstitucionEducativaID"]);
            }
            return o;
        }

        public static bool Eliminar(int InstitucionEducativaID, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            return Eliminar(new Cosmos.Academico.Entidades.InstitucionEducativa() { InstitucionEducativaID = InstitucionEducativaID }, oInfoForLog);
        }

        public static bool Eliminar(Cosmos.Academico.Entidades.InstitucionEducativa o, Cosmos.Seguridad.Entidades.DataForLog oInfoForLog)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Academico_Institucion_Educativa_Eliminar", o.InstitucionEducativaID, oInfoForLog);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

    }
}
