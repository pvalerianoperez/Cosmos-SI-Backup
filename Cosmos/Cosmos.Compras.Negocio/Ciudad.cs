
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Ciudad
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Ciudad> Listado() {            
            List<Cosmos.Compras.Entidades.Ciudad> lst = new List<Cosmos.Compras.Entidades.Ciudad>();            
            DataTable dt = SQLHelper.GetTable("Compras_Ciudad_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Ciudad o = new Cosmos.Compras.Entidades.Ciudad();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Ciudad Consultar(int ciudadID) {
            return Consultar(new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID  });
        }
        
        public static Cosmos.Compras.Entidades.Ciudad Consultar(Cosmos.Compras.Entidades.Ciudad o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Ciudad_Consultar", o.CiudadID);
            o = new Cosmos.Compras.Entidades.Ciudad();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Ciudad Guardar(int modificacionUsuarioID, int ciudadID, string ciudadClave, string nombre, string nombreCorto, int municipioID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID, CiudadClave = ciudadClave, Nombre = nombre, NombreCorto = nombreCorto, MunicipioID = municipioID  });
        }
        
        public static Cosmos.Compras.Entidades.Ciudad Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Ciudad o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Ciudad_Guardar", modificacionUsuarioID, o.CiudadID, o.CiudadClave, o.Nombre, o.NombreCorto, o.MunicipioID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["CiudadID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int ciudadID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Ciudad() { CiudadID = ciudadID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Ciudad o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Ciudad_Eliminar", modificacionUsuarioID, o.CiudadID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
