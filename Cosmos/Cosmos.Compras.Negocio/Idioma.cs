
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Idioma
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Idioma> Listado() {            
            List<Cosmos.Compras.Entidades.Idioma> lst = new List<Cosmos.Compras.Entidades.Idioma>();            
            DataTable dt = SQLHelper.GetTable("Compras_Idioma_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Idioma o = new Cosmos.Compras.Entidades.Idioma();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Idioma Consultar(int idiomaID) {
            return Consultar(new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID  });
        }
        
        public static Cosmos.Compras.Entidades.Idioma Consultar(Cosmos.Compras.Entidades.Idioma o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Idioma_Consultar", o.IdiomaID);
            o = new Cosmos.Compras.Entidades.Idioma();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Idioma Guardar(int modificacionUsuarioID, int idiomaID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Idioma Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Idioma o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Idioma_Guardar", modificacionUsuarioID, o.IdiomaID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["IdiomaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int idiomaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Idioma() { IdiomaID = idiomaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Idioma o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Idioma_Eliminar", modificacionUsuarioID, o.IdiomaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
