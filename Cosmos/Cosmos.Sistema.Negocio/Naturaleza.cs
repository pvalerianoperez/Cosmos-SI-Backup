
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class Naturaleza
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Naturaleza> Listado() {            
            List<Cosmos.Sistema.Entidades.Naturaleza> lst = new List<Cosmos.Sistema.Entidades.Naturaleza>();            
            DataTable dt = SQLHelper.GetTable("Sistema_Naturaleza_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.Naturaleza o = new Cosmos.Sistema.Entidades.Naturaleza();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.Naturaleza Consultar(int NaturalezaID) {
            return Consultar(new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID  });
        }
        
        public static Cosmos.Sistema.Entidades.Naturaleza Consultar(Cosmos.Sistema.Entidades.Naturaleza o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_Naturaleza_Consultar", o.NaturalezaID);
            o = new Cosmos.Sistema.Entidades.Naturaleza();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.Naturaleza Guardar(int modificacionUsuarioID, int NaturalezaID, string NaturalezaClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID, NaturalezaClave = NaturalezaClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.Naturaleza Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Naturaleza o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Naturaleza_Guardar", modificacionUsuarioID, o.NaturalezaID, o.NaturalezaClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["NaturalezaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int NaturalezaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Naturaleza() { NaturalezaID = NaturalezaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Naturaleza o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Naturaleza_Eliminar", modificacionUsuarioID, o.NaturalezaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
