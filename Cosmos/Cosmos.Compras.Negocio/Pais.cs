
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Pais
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Pais> Listado() {            
            List<Cosmos.Compras.Entidades.Pais> lst = new List<Cosmos.Compras.Entidades.Pais>();            
            DataTable dt = SQLHelper.GetTable("Compras_Pais_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Pais o = new Cosmos.Compras.Entidades.Pais();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Pais Consultar(int paisID) {
            return Consultar(new Cosmos.Compras.Entidades.Pais() { PaisID = paisID  });
        }
        
        public static Cosmos.Compras.Entidades.Pais Consultar(Cosmos.Compras.Entidades.Pais o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Pais_Consultar", o.PaisID);
            o = new Cosmos.Compras.Entidades.Pais();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Pais Guardar(int modificacionUsuarioID, int paisID, string paisClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Pais() { PaisID = paisID, PaisClave = paisClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Pais Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Pais o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Pais_Guardar", modificacionUsuarioID, o.PaisID, o.PaisClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PaisID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int paisID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Pais() { PaisID = paisID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Pais o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Pais_Eliminar", modificacionUsuarioID, o.PaisID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
