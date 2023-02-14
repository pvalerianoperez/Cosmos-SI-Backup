
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class Grupo
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.Grupo> Listado() {            
            List<Cosmos.Sistema.Entidades.Grupo> lst = new List<Cosmos.Sistema.Entidades.Grupo>();            
            DataTable dt = SQLHelper.GetTable("Sistema_Grupo_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.Grupo o = new Cosmos.Sistema.Entidades.Grupo();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.Grupo Consultar(int sistemaGrupoID) {
            return Consultar(new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID  });
        }
        
        public static Cosmos.Sistema.Entidades.Grupo Consultar(Cosmos.Sistema.Entidades.Grupo o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_Grupo_Consultar", o.SistemaGrupoID);
            o = new Cosmos.Sistema.Entidades.Grupo();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.Grupo Guardar(int modificacionUsuarioID, int sistemaGrupoID, string nombre, int moduloID, bool activo) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID, Nombre = nombre, ModuloID = moduloID, Activo = activo  });
        }
        
        public static Cosmos.Sistema.Entidades.Grupo Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Grupo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Grupo_Guardar", modificacionUsuarioID, o.SistemaGrupoID, o.Nombre, o.ModuloID, o.Activo);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaGrupoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaGrupoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.Grupo() { SistemaGrupoID = sistemaGrupoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.Grupo o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_Grupo_Eliminar", modificacionUsuarioID, o.SistemaGrupoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
