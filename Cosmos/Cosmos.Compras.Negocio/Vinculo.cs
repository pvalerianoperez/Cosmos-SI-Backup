
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Vinculo
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Vinculo> Listado() {            
            List<Cosmos.Compras.Entidades.Vinculo> lst = new List<Cosmos.Compras.Entidades.Vinculo>();            
            DataTable dt = SQLHelper.GetTable("Compras_Vinculo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Vinculo o = new Cosmos.Compras.Entidades.Vinculo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Vinculo Consultar(int vinculoID) {
            return Consultar(new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID  });
        }
        
        public static Cosmos.Compras.Entidades.Vinculo Consultar(Cosmos.Compras.Entidades.Vinculo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Vinculo_Consultar", o.VinculoID);
            o = new Cosmos.Compras.Entidades.Vinculo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Vinculo Guardar(int modificacionUsuarioID, int vinculoID, string vinculoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID, VinculoClave = vinculoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Vinculo Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Vinculo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Vinculo_Guardar", modificacionUsuarioID, o.VinculoID, o.VinculoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["VinculoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int vinculoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Vinculo() { VinculoID = vinculoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Vinculo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Vinculo_Eliminar", modificacionUsuarioID, o.VinculoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
