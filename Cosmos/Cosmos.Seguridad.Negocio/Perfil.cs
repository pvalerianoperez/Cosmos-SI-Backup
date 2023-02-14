
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Perfil
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Perfil> Listado() {            
            List<Cosmos.Seguridad.Entidades.Perfil> lst = new List<Cosmos.Seguridad.Entidades.Perfil>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Perfil_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Perfil o = new Cosmos.Seguridad.Entidades.Perfil();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Perfil Consultar(int perfilID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Perfil Consultar(Cosmos.Seguridad.Entidades.Perfil o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Perfil_Consultar", o.PerfilID);
            o = new Cosmos.Seguridad.Entidades.Perfil();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Perfil Guardar(int modificacionUsuarioID, int perfilID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Seguridad.Entidades.Perfil Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Perfil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Perfil_Guardar", modificacionUsuarioID, o.PerfilID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PerfilID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int perfilID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Perfil() { PerfilID = perfilID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Perfil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Perfil_Eliminar", modificacionUsuarioID, o.PerfilID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static bool OpcionGuardar(int modificacionUsuarioID, int perfilID, int opcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Perfil_Opcion_Guardar", modificacionUsuarioID, perfilID, opcionID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                return true;
            }

            return false;
        }
        public static bool OpcionEliminar(int modificacionUsuarioID, int perfilID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Perfil_Opcion_Eliminar", modificacionUsuarioID, perfilID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                return true;
            }

            return false;
        }
        public static List<Cosmos.Seguridad.Entidades.Opcion> OpcionListado(int perfilID)
        {
            List<Cosmos.Seguridad.Entidades.Opcion> lst = new List<Cosmos.Seguridad.Entidades.Opcion>();
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Perfil_Opcion_Listado", perfilID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Opcion o = new Entidades.Opcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Seguridad.Entidades.Opcion> ConsultarOpciones(int perfilID)
        {
            List<Cosmos.Seguridad.Entidades.Opcion> lst = new List<Cosmos.Seguridad.Entidades.Opcion>();
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Perfil_ConsultarOpciones", perfilID);            
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
        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> ConsultarAcciones(int perfilID, int opcionID)
        {
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> lst = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Perfil_ConsultarAcciones", perfilID, opcionID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.PerfilOpcionAccion o = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

    }
}
