
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoFecha
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoFecha> Listado() {            
            List<Cosmos.Compras.Entidades.TipoFecha> lst = new List<Cosmos.Compras.Entidades.TipoFecha>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoFecha_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoFecha o = new Cosmos.Compras.Entidades.TipoFecha();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoFecha Consultar(int tipoFechaID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoFecha Consultar(Cosmos.Compras.Entidades.TipoFecha o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoFecha_Consultar", o.TipoFechaID);
            o = new Cosmos.Compras.Entidades.TipoFecha();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoFecha Guardar(int modificacionUsuarioID, int tipoFechaID, string tipoFechaClave, string nombre, string nombreCorto, bool estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID, TipoFechaClave = tipoFechaClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus  });
        }
        
        public static Cosmos.Compras.Entidades.TipoFecha Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoFecha o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoFecha_Guardar", modificacionUsuarioID, o.TipoFechaID, o.TipoFechaClave, o.Nombre, o.NombreCorto, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoFechaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoFechaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoFecha() { TipoFechaID = tipoFechaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoFecha o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoFecha_Eliminar", modificacionUsuarioID, o.TipoFechaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
