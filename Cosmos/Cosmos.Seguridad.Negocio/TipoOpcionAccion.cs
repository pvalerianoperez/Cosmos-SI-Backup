
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class TipoOpcionAccion
    {

        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.TipoOpcionAccion> Listado()
        {
            List<Cosmos.Seguridad.Entidades.TipoOpcionAccion> lst = new List<Cosmos.Seguridad.Entidades.TipoOpcionAccion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcionAccion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.TipoOpcionAccion o = new Cosmos.Seguridad.Entidades.TipoOpcionAccion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcionAccion Consultar(int tipoOpcionID, int accionID)
        {
            return Consultar(new Cosmos.Seguridad.Entidades.TipoOpcionAccion() { TipoOpcionID = tipoOpcionID, AccionID = accionID });
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcionAccion Consultar(Cosmos.Seguridad.Entidades.TipoOpcionAccion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcionAccion_Consultar", o.TipoOpcionID, o.AccionID);
            o = new Cosmos.Seguridad.Entidades.TipoOpcionAccion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static bool Guardar(int modificacionUsuarioID, int tipoOpcionID, int accionID)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.TipoOpcionAccion() { TipoOpcionID = tipoOpcionID, AccionID = accionID });
        }

        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.TipoOpcionAccion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcionAccion_Guardar", modificacionUsuarioID, o.TipoOpcionID, o.AccionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static bool Eliminar(int modificacionUsuarioID, int tipoOpcionID, int accionID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.TipoOpcionAccion() { TipoOpcionID = tipoOpcionID, AccionID = accionID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.TipoOpcionAccion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcionAccion_Eliminar", modificacionUsuarioID, o.TipoOpcionID, o.AccionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion


    }
}
