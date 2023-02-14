
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class MedioContacto
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.MedioContacto> Listado() {            
            List<Cosmos.Compras.Entidades.MedioContacto> lst = new List<Cosmos.Compras.Entidades.MedioContacto>();            
            DataTable dt = SQLHelper.GetTable("Compras_MedioContacto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.MedioContacto o = new Cosmos.Compras.Entidades.MedioContacto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.MedioContacto Consultar(int medioContactoID) {
            return Consultar(new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID  });
        }
        
        public static Cosmos.Compras.Entidades.MedioContacto Consultar(Cosmos.Compras.Entidades.MedioContacto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_MedioContacto_Consultar", o.MedioContactoID);
            o = new Cosmos.Compras.Entidades.MedioContacto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.MedioContacto Guardar(int modificacionUsuarioID, int medioContactoID, int medioContactoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID, MedioContactoClave = medioContactoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.MedioContacto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.MedioContacto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_MedioContacto_Guardar", modificacionUsuarioID, o.MedioContactoID, o.MedioContactoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["MedioContactoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int medioContactoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.MedioContacto() { MedioContactoID = medioContactoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.MedioContacto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_MedioContacto_Eliminar", modificacionUsuarioID, o.MedioContactoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
