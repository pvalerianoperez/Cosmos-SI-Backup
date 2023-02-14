
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Accion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Accion> Listado() {            
            List<Cosmos.Seguridad.Entidades.Accion> lst = new List<Cosmos.Seguridad.Entidades.Accion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Accion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Accion o = new Cosmos.Seguridad.Entidades.Accion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Accion Consultar(int accionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Accion Consultar(Cosmos.Seguridad.Entidades.Accion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Accion_Consultar", o.AccionID);
            o = new Cosmos.Seguridad.Entidades.Accion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Accion Guardar(int modificacionUsuarioID, int accionID, string accionClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID, AccionClave = accionClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Seguridad.Entidades.Accion Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Accion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Accion_Guardar", modificacionUsuarioID, o.AccionID, o.AccionClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["AccionID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int accionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Accion() { AccionID = accionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Accion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Accion_Eliminar", modificacionUsuarioID, o.AccionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static List<Cosmos.Seguridad.Entidades.Accion> ListadoTipoOpcionID(int tipoOpcionID)
        {
            List<Cosmos.Seguridad.Entidades.Accion> lst = new List<Cosmos.Seguridad.Entidades.Accion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Accion_ListadoTipoOpcionID", tipoOpcionID);
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

        public static List<Cosmos.Seguridad.Entidades.Accion> ListadoOpcionID(int opcionID)
        {
            List<Cosmos.Seguridad.Entidades.Accion> lst = new List<Cosmos.Seguridad.Entidades.Accion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Accion_ListadoOpcionID", opcionID);
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
    }
}
