
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Fecha
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Fecha> Listado() {            
            List<Cosmos.Compras.Entidades.Fecha> lst = new List<Cosmos.Compras.Entidades.Fecha>();            
            DataTable dt = SQLHelper.GetTable("Compras_Fecha_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Fecha o = new Cosmos.Compras.Entidades.Fecha();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Fecha Consultar(int fechaID) {
            return Consultar(new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID  });
        }
        
        public static Cosmos.Compras.Entidades.Fecha Consultar(Cosmos.Compras.Entidades.Fecha o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Fecha_Consultar", o.FechaID);
            o = new Cosmos.Compras.Entidades.Fecha();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Fecha Guardar(int modificacionUsuarioID, int fechaID, DateTime valor, int personaID, int tipoFechaID, string comentario) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID, Valor = valor, PersonaID = personaID, TipoFechaID = tipoFechaID, Comentario = comentario  });
        }
        
        public static Cosmos.Compras.Entidades.Fecha Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Fecha o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Fecha_Guardar", modificacionUsuarioID, o.FechaID, o.Valor, o.PersonaID, o.TipoFechaID, o.Comentario);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["FechaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int fechaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Fecha() { FechaID = fechaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Fecha o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Fecha_Eliminar", modificacionUsuarioID, o.FechaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
