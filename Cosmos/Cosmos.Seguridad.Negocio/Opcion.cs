
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Opcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Opcion> Listado() {            
            List<Cosmos.Seguridad.Entidades.Opcion> lst = new List<Cosmos.Seguridad.Entidades.Opcion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Opcion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Opcion o = new Cosmos.Seguridad.Entidades.Opcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Opcion Consultar(int opcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Opcion Consultar(Cosmos.Seguridad.Entidades.Opcion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Opcion_Consultar", o.OpcionID);
            o = new Cosmos.Seguridad.Entidades.Opcion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Opcion Guardar(int modificacionUsuarioID, int opcionID, int moduloID, int padreID, string nombre, string nombreCorto, string recursoWebsite, bool activo, bool protegido, bool popup, bool visibleMenu, string icono, int orden) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID, ModuloID = moduloID, PadreID = padreID, Nombre = nombre, NombreCorto = nombreCorto, RecursoWebsite = recursoWebsite, Activo = activo, Protegido = protegido, Popup = popup, VisibleMenu = visibleMenu, Icono = icono, Orden = orden  });
        }
        
        public static Cosmos.Seguridad.Entidades.Opcion Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Opcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Opcion_Guardar", modificacionUsuarioID, o.OpcionID, o.ModuloID, o.PadreID, o.Nombre, o.NombreCorto, o.RecursoWebsite, o.Activo, o.Protegido, o.Popup, o.VisibleMenu, o.Icono, o.Orden);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["OpcionID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int opcionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Opcion() { OpcionID = opcionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Opcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Opcion_Eliminar", modificacionUsuarioID, o.OpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static bool TipoOpcionEliminar(int modificacionUsuarioID, int tipoOpcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Opcion_TipoOpcion_Eliminar", modificacionUsuarioID, tipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static bool TipoOpcionGuardar(int modificacionUsuarioID, int opcionID, int tipoOpcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Opcion_TipoOpcion_Guardar", modificacionUsuarioID, opcionID, tipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }

        public static List<Cosmos.Seguridad.Entidades.Opcion> ListadoPerfilID(int perfilID)
        {
            List<Cosmos.Seguridad.Entidades.Opcion> lst = new List<Cosmos.Seguridad.Entidades.Opcion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Opcion_ListadoPerfilID", perfilID);
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

        public static List<Cosmos.Seguridad.Entidades.TipoOpcion> TipoOpcionListado(int opcionID)
        {
            List<Cosmos.Seguridad.Entidades.TipoOpcion> lst = new List<Cosmos.Seguridad.Entidades.TipoOpcion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Opcion_TipoOpcion_Listado", opcionID);
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
    }
}
