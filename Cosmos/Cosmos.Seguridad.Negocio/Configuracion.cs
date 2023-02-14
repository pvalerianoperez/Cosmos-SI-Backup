
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Configuracion
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Configuracion> Listado() {            
            List<Cosmos.Seguridad.Entidades.Configuracion> lst = new List<Cosmos.Seguridad.Entidades.Configuracion>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Configuracion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Configuracion o = new Cosmos.Seguridad.Entidades.Configuracion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Configuracion Consultar(int configuracionID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Configuracion Consultar(Cosmos.Seguridad.Entidades.Configuracion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Configuracion_Consultar", o.ConfiguracionID);
            o = new Cosmos.Seguridad.Entidades.Configuracion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Configuracion Guardar(int modificacionUsuarioID, int configuracionID, string nombre, int maximoIntentosLogin, bool activa) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID, Nombre = nombre, MaximoIntentosLogin = maximoIntentosLogin, Activa = activa  });
        }
        
        public static Cosmos.Seguridad.Entidades.Configuracion Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Configuracion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Configuracion_Guardar", modificacionUsuarioID, o.ConfiguracionID, o.Nombre, o.MaximoIntentosLogin, o.Activa);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ConfiguracionID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int configuracionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Configuracion() { ConfiguracionID = configuracionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Configuracion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Configuracion_Eliminar", modificacionUsuarioID, o.ConfiguracionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
