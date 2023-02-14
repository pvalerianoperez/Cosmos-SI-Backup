
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class MetodoCosteo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.MetodoCosteo> Listado() {            
            List<Cosmos.Sistema.Entidades.MetodoCosteo> lst = new List<Cosmos.Sistema.Entidades.MetodoCosteo>();            
            DataTable dt = SQLHelper.GetTable("Sistema_MetodoCosteo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.MetodoCosteo o = new Cosmos.Sistema.Entidades.MetodoCosteo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Consultar(int metodoCosteoID) {
            return Consultar(new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID  });
        }
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Consultar(Cosmos.Sistema.Entidades.MetodoCosteo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_MetodoCosteo_Consultar", o.MetodoCosteoID);
            o = new Cosmos.Sistema.Entidades.MetodoCosteo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Guardar(int modificacionUsuarioID, int metodoCosteoID, string metodoCosteoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID, MetodoCosteoClave = metodoCosteoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.MetodoCosteo Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.MetodoCosteo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_MetodoCosteo_Guardar", modificacionUsuarioID, o.MetodoCosteoID, o.MetodoCosteoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["MetodoCosteoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int metodoCosteoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.MetodoCosteo() { MetodoCosteoID = metodoCosteoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.MetodoCosteo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_MetodoCosteo_Eliminar", modificacionUsuarioID, o.MetodoCosteoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
