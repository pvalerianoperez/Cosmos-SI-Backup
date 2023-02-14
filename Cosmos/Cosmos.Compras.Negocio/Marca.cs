
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Marca
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Marca> Listado() {            
            List<Cosmos.Compras.Entidades.Marca> lst = new List<Cosmos.Compras.Entidades.Marca>();            
            DataTable dt = SQLHelper.GetTable("Compras_Marca_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Marca o = new Cosmos.Compras.Entidades.Marca();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Marca Consultar(int marcaID) {
            return Consultar(new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID  });
        }
        
        public static Cosmos.Compras.Entidades.Marca Consultar(Cosmos.Compras.Entidades.Marca o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Marca_Consultar", o.MarcaID);
            o = new Cosmos.Compras.Entidades.Marca();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Marca Guardar(int modificacionUsuarioID, int marcaID, string marcaClave, string nombre, string nombreCorto, string estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID, MarcaClave = marcaClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus  });
        }
        
        public static Cosmos.Compras.Entidades.Marca Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Marca o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Marca_Guardar", modificacionUsuarioID, o.MarcaID, o.MarcaClave, o.Nombre, o.NombreCorto, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["MarcaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int marcaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Marca() { MarcaID = marcaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Marca o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Marca_Eliminar", modificacionUsuarioID, o.MarcaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
