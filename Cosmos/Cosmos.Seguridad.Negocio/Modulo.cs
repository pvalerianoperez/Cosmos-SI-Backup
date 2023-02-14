
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Modulo
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Modulo> Listado() {            
            List<Cosmos.Seguridad.Entidades.Modulo> lst = new List<Cosmos.Seguridad.Entidades.Modulo>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Modulo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Modulo o = new Cosmos.Seguridad.Entidades.Modulo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Modulo Consultar(int moduloID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Modulo Consultar(Cosmos.Seguridad.Entidades.Modulo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Modulo_Consultar", o.ModuloID);
            o = new Cosmos.Seguridad.Entidades.Modulo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Modulo Guardar(int modificacionUsuarioID, int moduloID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Seguridad.Entidades.Modulo Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Modulo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Modulo_Guardar", modificacionUsuarioID, o.ModuloID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ModuloID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int moduloID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Modulo() { ModuloID = moduloID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Modulo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Modulo_Eliminar", modificacionUsuarioID, o.ModuloID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
