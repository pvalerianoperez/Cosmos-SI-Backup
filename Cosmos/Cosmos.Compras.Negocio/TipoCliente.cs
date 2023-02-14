
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoCliente
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.TipoCliente> Listado() {            
            List<Cosmos.Compras.Entidades.TipoCliente> lst = new List<Cosmos.Compras.Entidades.TipoCliente>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoCliente_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoCliente o = new Cosmos.Compras.Entidades.TipoCliente();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoCliente Consultar(int tipoClienteID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoCliente Consultar(Cosmos.Compras.Entidades.TipoCliente o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoCliente_Consultar", o.TipoClienteID);
            o = new Cosmos.Compras.Entidades.TipoCliente();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoCliente Guardar(int modificacionUsuarioID, int tipoClienteID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.TipoCliente Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoCliente o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoCliente_Guardar", modificacionUsuarioID, o.TipoClienteID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoClienteID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoClienteID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoCliente() { TipoClienteID = tipoClienteID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoCliente o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoCliente_Eliminar", modificacionUsuarioID, o.TipoClienteID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
