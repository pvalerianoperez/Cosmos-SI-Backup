
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class OpcionTipoOpcion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> Listado() {            
            List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion> lst = new List<Cosmos.Seguridad.Entidades.OpcionTipoOpcion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_OpcionTipoOpcion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.OpcionTipoOpcion o = new Cosmos.Seguridad.Entidades.OpcionTipoOpcion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Consultar(int opcionID, int tipoOpcionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.OpcionTipoOpcion Consultar(Cosmos.Seguridad.Entidades.OpcionTipoOpcion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_OpcionTipoOpcion_Consultar", o.OpcionID, o.TipoOpcionID);
            o = new Cosmos.Seguridad.Entidades.OpcionTipoOpcion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static bool Guardar(int modificacionUsuarioID, int opcionID, int tipoOpcionID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.OpcionTipoOpcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_OpcionTipoOpcion_Guardar", modificacionUsuarioID, o.OpcionID, o.TipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int opcionID, int tipoOpcionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.OpcionTipoOpcion() { OpcionID = opcionID, TipoOpcionID = tipoOpcionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.OpcionTipoOpcion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_OpcionTipoOpcion_Eliminar", modificacionUsuarioID, o.OpcionID, o.TipoOpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
