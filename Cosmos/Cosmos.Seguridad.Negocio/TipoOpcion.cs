
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class TipoOpcion
    {

        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.TipoOpcion> Listado()
        {
            List<Cosmos.Seguridad.Entidades.TipoOpcion> lst = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcion_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.TipoOpcion o = new Cosmos.Seguridad.Entidades.TipoOpcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Consultar(int tipoOpcionID)
        {
            return Consultar(new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID });
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Consultar(Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcion_Consultar", o.TipoOpcionID);
            o = new Cosmos.Seguridad.Entidades.TipoOpcion();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Guardar(int modificacionUsuarioID, int tipoOpcionID, string nombre, string nombreCorto)
        {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID, Nombre = nombre, NombreCorto = nombreCorto });
        }

        public static Cosmos.Seguridad.Entidades.TipoOpcion Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Guardar", modificacionUsuarioID, o.TipoOpcionID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["TipoOpcionID"]);
            }
            return o;
        }

        public static bool Eliminar(int modificacionUsuarioID, int tipoOpcionID)
        {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.TipoOpcion() { TipoOpcionID = tipoOpcionID });
        }

        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.TipoOpcion o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Eliminar", modificacionUsuarioID, o.TipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static bool AccionGuardar(int modificacionUsuarioID, int tipoOpcionID, int accionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Accion_Guardar", modificacionUsuarioID, tipoOpcionID, accionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static bool AccionEliminar(int modificacionUsuarioID, int tipoOpcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Accion_Eliminar", modificacionUsuarioID, tipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static List<Cosmos.Seguridad.Entidades.Accion> AccionListado(int tipoOpcionID)
        {
            List<Cosmos.Seguridad.Entidades.Accion> lst = new List<Cosmos.Seguridad.Entidades.Accion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcion_Accion_Listado", tipoOpcionID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Accion o = new Cosmos.Seguridad.Entidades.Accion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static bool OpcionGuardar(int modificacionUsuarioID, int tipoOpcionID, int opcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Opcion_Guardar", modificacionUsuarioID, tipoOpcionID, opcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static bool OpcionEliminar(int modificacionUsuarioID, int tipoOpcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_TipoOpcion_Opcion_Eliminar", modificacionUsuarioID, tipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static List<Cosmos.Seguridad.Entidades.Opcion> OpcionListado(int tipoOpcionID)
        {
            List<Cosmos.Seguridad.Entidades.Opcion> lst = new List<Cosmos.Seguridad.Entidades.Opcion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_TipoOpcion_Opcion_Listado", tipoOpcionID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Opcion o = new Cosmos.Seguridad.Entidades.Opcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
    }
}
