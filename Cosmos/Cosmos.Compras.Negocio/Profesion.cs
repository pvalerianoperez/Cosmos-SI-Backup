
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Profesion
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Profesion> Listado() {            
            List<Cosmos.Compras.Entidades.Profesion> lst = new List<Cosmos.Compras.Entidades.Profesion>();            
            DataTable dt = SQLHelper.GetTable("Compras_Profesion_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Profesion o = new Cosmos.Compras.Entidades.Profesion();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Profesion Consultar(int profesionID) {
            return Consultar(new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID  });
        }
        
        public static Cosmos.Compras.Entidades.Profesion Consultar(Cosmos.Compras.Entidades.Profesion o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Profesion_Consultar", o.ProfesionID);
            o = new Cosmos.Compras.Entidades.Profesion();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Profesion Guardar(int modificacionUsuarioID, int profesionID, string profesionClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID, ProfesionClave = profesionClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Profesion Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Profesion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Profesion_Guardar", modificacionUsuarioID, o.ProfesionID, o.ProfesionClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProfesionID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int profesionID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Profesion() { ProfesionID = profesionID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Profesion o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Profesion_Eliminar", modificacionUsuarioID, o.ProfesionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
