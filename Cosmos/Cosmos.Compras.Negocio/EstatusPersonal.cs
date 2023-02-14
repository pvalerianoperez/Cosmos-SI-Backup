
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class EstatusPersonal
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstatusPersonal> Listado() {            
            List<Cosmos.Compras.Entidades.EstatusPersonal> lst = new List<Cosmos.Compras.Entidades.EstatusPersonal>();            
            DataTable dt = SQLHelper.GetTable("Compras_EstatusPersonal_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.EstatusPersonal o = new Cosmos.Compras.Entidades.EstatusPersonal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Consultar(int estatusPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Consultar(Cosmos.Compras.Entidades.EstatusPersonal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_EstatusPersonal_Consultar", o.EstatusPersonalID);
            o = new Cosmos.Compras.Entidades.EstatusPersonal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Guardar(int modificacionUsuarioID, int estatusPersonalID, string estatusPersonalClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID, EstatusPersonalClave = estatusPersonalClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusPersonal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstatusPersonal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstatusPersonal_Guardar", modificacionUsuarioID, o.EstatusPersonalID, o.EstatusPersonalClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstatusPersonalID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estatusPersonalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstatusPersonal() { EstatusPersonalID = estatusPersonalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstatusPersonal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstatusPersonal_Eliminar", modificacionUsuarioID, o.EstatusPersonalID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
