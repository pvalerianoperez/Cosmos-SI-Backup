
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Zona
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Zona> Listado() {            
            List<Cosmos.Compras.Entidades.Zona> lst = new List<Cosmos.Compras.Entidades.Zona>();            
            DataTable dt = SQLHelper.GetTable("Compras_Zona_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Zona o = new Cosmos.Compras.Entidades.Zona();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Zona Consultar(int zonaID) {
            return Consultar(new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID  });
        }
        
        public static Cosmos.Compras.Entidades.Zona Consultar(Cosmos.Compras.Entidades.Zona o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Zona_Consultar", o.ZonaID);
            o = new Cosmos.Compras.Entidades.Zona();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Zona Guardar(int modificacionUsuarioID, int zonaID, string zonaClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID, ZonaClave = zonaClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Zona Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Zona o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Zona_Guardar", modificacionUsuarioID, o.ZonaID, o.ZonaClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ZonaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int zonaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Zona() { ZonaID = zonaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Zona o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Zona_Eliminar", modificacionUsuarioID, o.ZonaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
