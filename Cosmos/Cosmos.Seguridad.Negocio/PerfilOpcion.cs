
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class PerfilOpcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.PerfilOpcion> Listado() {            
            List<Cosmos.Seguridad.Entidades.PerfilOpcion> lst = new List<Cosmos.Seguridad.Entidades.PerfilOpcion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_PerfilOpcion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.PerfilOpcion o = new Cosmos.Seguridad.Entidades.PerfilOpcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcion Consultar(int perfilID, int opcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.PerfilOpcion Consultar(Cosmos.Seguridad.Entidades.PerfilOpcion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_PerfilOpcion_Consultar", o.PerfilID, o.OpcionID);
            o = new Cosmos.Seguridad.Entidades.PerfilOpcion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static bool Guardar(int modificacionUsuarioID, int perfilID, int opcionID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.PerfilOpcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_PerfilOpcion_Guardar", modificacionUsuarioID, o.PerfilID, o.OpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int perfilID, int opcionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.PerfilOpcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_PerfilOpcion_Eliminar", modificacionUsuarioID, o.PerfilID, o.OpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
