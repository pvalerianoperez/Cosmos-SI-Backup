
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Banco
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Banco> Listado() {            
            List<Cosmos.Compras.Entidades.Banco> lst = new List<Cosmos.Compras.Entidades.Banco>();            
            DataTable dt = SQLHelper.GetTable("Compras_Banco_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Banco o = new Cosmos.Compras.Entidades.Banco();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Banco Consultar(int bancoID) {
            return Consultar(new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID  });
        }
        
        public static Cosmos.Compras.Entidades.Banco Consultar(Cosmos.Compras.Entidades.Banco o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Banco_Consultar", o.BancoID);
            o = new Cosmos.Compras.Entidades.Banco();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Banco Guardar(int modificacionUsuarioID, int bancoID, string bancoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID, BancoClave = bancoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Banco Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Banco o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Banco_Guardar", modificacionUsuarioID, o.BancoID, o.BancoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["BancoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int bancoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Banco() { BancoID = bancoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Banco o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Banco_Eliminar", modificacionUsuarioID, o.BancoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
