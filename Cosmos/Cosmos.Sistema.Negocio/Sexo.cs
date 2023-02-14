
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class Sexo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Sexo> Listado() {            
            List<Cosmos.Sistema.Entidades.Sexo> lst = new List<Cosmos.Sistema.Entidades.Sexo>();            
            DataTable dt = SQLHelper.GetTable("Sistema_Sexo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.Sexo o = new Cosmos.Sistema.Entidades.Sexo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.Sexo Consultar(int sexoID) {
            return Consultar(new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID  });
        }
        
        public static Cosmos.Sistema.Entidades.Sexo Consultar(Cosmos.Sistema.Entidades.Sexo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_Sexo_Consultar", o.SexoID);
            o = new Cosmos.Sistema.Entidades.Sexo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.Sexo Guardar(int modificacionUsuarioID, int sexoID, string sexoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID, SexoClave = sexoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.Sexo Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Sexo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Sexo_Guardar", modificacionUsuarioID, o.SexoID, o.SexoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SexoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sexoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Sexo() { SexoID = sexoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Sexo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Sexo_Eliminar", modificacionUsuarioID, o.SexoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
