
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Unidad
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Unidad> Listado() {            
            List<Cosmos.Compras.Entidades.Unidad> lst = new List<Cosmos.Compras.Entidades.Unidad>();            
            DataTable dt = SQLHelper.GetTable("Compras_Unidad_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Unidad o = new Cosmos.Compras.Entidades.Unidad();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Unidad Consultar(int unidadID) {
            return Consultar(new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID  });
        }
        
        public static Cosmos.Compras.Entidades.Unidad Consultar(Cosmos.Compras.Entidades.Unidad o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Unidad_Consultar", o.UnidadID);
            o = new Cosmos.Compras.Entidades.Unidad();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Unidad Guardar(int modificacionUsuarioID, int unidadID, string unidadClave, string nombre, string nombreCorto, string estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID, UnidadClave = unidadClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus  });
        }
        
        public static Cosmos.Compras.Entidades.Unidad Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Unidad o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Unidad_Guardar", modificacionUsuarioID, o.UnidadID, o.UnidadClave, o.Nombre, o.NombreCorto, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["UnidadID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int unidadID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Unidad() { UnidadID = unidadID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Unidad o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Unidad_Eliminar", modificacionUsuarioID, o.UnidadID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
