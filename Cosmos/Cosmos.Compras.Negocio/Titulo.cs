
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Titulo
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Titulo> Listado() {            
            List<Cosmos.Compras.Entidades.Titulo> lst = new List<Cosmos.Compras.Entidades.Titulo>();            
            DataTable dt = SQLHelper.GetTable("Compras_Titulo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Titulo o = new Cosmos.Compras.Entidades.Titulo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Titulo Consultar(int tituloID) {
            return Consultar(new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID  });
        }
        
        public static Cosmos.Compras.Entidades.Titulo Consultar(Cosmos.Compras.Entidades.Titulo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Titulo_Consultar", o.TituloID);
            o = new Cosmos.Compras.Entidades.Titulo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Titulo Guardar(int modificacionUsuarioID, int tituloID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Titulo Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Titulo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Titulo_Guardar", modificacionUsuarioID, o.TituloID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TituloID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tituloID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Titulo() { TituloID = tituloID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Titulo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Titulo_Eliminar", modificacionUsuarioID, o.TituloID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
