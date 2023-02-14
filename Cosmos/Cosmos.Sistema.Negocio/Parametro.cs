
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class Parametro
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Parametro> Listado() {            
            List<Cosmos.Sistema.Entidades.Parametro> lst = new List<Cosmos.Sistema.Entidades.Parametro>();            
            DataTable dt = SQLHelper.GetTable("Sistema_Parametro_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.Parametro o = new Cosmos.Sistema.Entidades.Parametro();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.Parametro Consultar(int sistemaParametroID) {
            return Consultar(new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID  });
        }
        
        public static Cosmos.Sistema.Entidades.Parametro Consultar(Cosmos.Sistema.Entidades.Parametro o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_Parametro_Consultar", o.SistemaParametroID);
            o = new Cosmos.Sistema.Entidades.Parametro();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.Parametro Guardar(int modificacionUsuarioID, int sistemaParametroID, string nombre, int moduloID, string valor) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID, Nombre = nombre, ModuloID = moduloID, Valor = valor  });
        }
        
        public static Cosmos.Sistema.Entidades.Parametro Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Parametro o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Parametro_Guardar", modificacionUsuarioID, o.SistemaParametroID, o.Nombre, o.ModuloID, o.Valor);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaParametroID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaParametroID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Parametro() { SistemaParametroID = sistemaParametroID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Parametro o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Parametro_Eliminar", modificacionUsuarioID, o.SistemaParametroID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
