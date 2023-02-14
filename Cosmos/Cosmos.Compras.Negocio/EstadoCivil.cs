
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class EstadoCivil
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstadoCivil> Listado() {            
            List<Cosmos.Compras.Entidades.EstadoCivil> lst = new List<Cosmos.Compras.Entidades.EstadoCivil>();            
            DataTable dt = SQLHelper.GetTable("Compras_EstadoCivil_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.EstadoCivil o = new Cosmos.Compras.Entidades.EstadoCivil();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.EstadoCivil Consultar(int estadoCivilID) {
            return Consultar(new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID  });
        }
        
        public static Cosmos.Compras.Entidades.EstadoCivil Consultar(Cosmos.Compras.Entidades.EstadoCivil o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_EstadoCivil_Consultar", o.EstadoCivilID);
            o = new Cosmos.Compras.Entidades.EstadoCivil();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.EstadoCivil Guardar(int modificacionUsuarioID, int estadoCivilID, string estadoCivilClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID, EstadoCivilClave = estadoCivilClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.EstadoCivil Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstadoCivil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstadoCivil_Guardar", modificacionUsuarioID, o.EstadoCivilID, o.EstadoCivilClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstadoCivilID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estadoCivilID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstadoCivil() { EstadoCivilID = estadoCivilID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstadoCivil o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstadoCivil_Eliminar", modificacionUsuarioID, o.EstadoCivilID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
