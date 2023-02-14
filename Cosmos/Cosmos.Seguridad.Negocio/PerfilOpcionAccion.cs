
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class PerfilOpcionAccion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> Listado() {            
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> lst = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_PerfilOpcionAccion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.PerfilOpcionAccion o = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Consultar(int perfilID, int opcionID, int accionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcionAccion Consultar(Cosmos.Seguridad.Entidades.PerfilOpcionAccion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_PerfilOpcionAccion_Consultar", o.PerfilID, o.OpcionID, o.AccionID);
            o = new Cosmos.Seguridad.Entidades.PerfilOpcionAccion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static bool Guardar(int modificacionUsuarioID, int perfilID, int opcionID, int accionID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.PerfilOpcionAccion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_PerfilOpcionAccion_Guardar", modificacionUsuarioID, o.PerfilID, o.OpcionID, o.AccionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int perfilID, int opcionID, int accionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID, AccionID = accionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.PerfilOpcionAccion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_PerfilOpcionAccion_Eliminar", modificacionUsuarioID, o.PerfilID, o.OpcionID, o.AccionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static bool EliminarPerfilOpcion(int perfilID, int opcionID)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_PerfilOpcionAccion_EliminarPerfilOpcion", perfilID, opcionID);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                return true;
            }

            return false;
        }

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> ListadoPerfilIDOpcionID(int perfilID, int opcionID)
        {
            List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion> lst = new List<Cosmos.Seguridad.Entidades.PerfilOpcionAccion>();
            DataTable dt = SQLHelper.GetTable("Seguridad_PerfilOpcionAccion_ListadoPerfilIDOpcionID", perfilID, opcionID);
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
