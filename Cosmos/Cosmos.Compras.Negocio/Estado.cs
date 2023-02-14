
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Estado
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Estado> Listado() {            
            List<Cosmos.Compras.Entidades.Estado> lst = new List<Cosmos.Compras.Entidades.Estado>();            
            DataTable dt = SQLHelper.GetTable("Compras_Estado_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Estado o = new Cosmos.Compras.Entidades.Estado();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Estado Consultar(int estadoID) {
            return Consultar(new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID  });
        }
        
        public static Cosmos.Compras.Entidades.Estado Consultar(Cosmos.Compras.Entidades.Estado o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Estado_Consultar", o.EstadoID);
            o = new Cosmos.Compras.Entidades.Estado();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Estado Guardar(int modificacionUsuarioID, int estadoID, string estadoClave, string nombre, string nombreCorto, int paisID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID, EstadoClave = estadoClave, Nombre = nombre, NombreCorto = nombreCorto, PaisID = paisID  });
        }
        
        public static Cosmos.Compras.Entidades.Estado Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Estado o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Estado_Guardar", modificacionUsuarioID, o.EstadoID, o.EstadoClave, o.Nombre, o.NombreCorto, o.PaisID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstadoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estadoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Estado() { EstadoID = estadoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Estado o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Estado_Eliminar", modificacionUsuarioID, o.EstadoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
