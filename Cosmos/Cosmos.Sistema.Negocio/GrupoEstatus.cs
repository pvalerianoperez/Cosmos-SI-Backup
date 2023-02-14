
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class GrupoEstatus
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.GrupoEstatus> Listado() {            
            List<Cosmos.Sistema.Entidades.GrupoEstatus> lst = new List<Cosmos.Sistema.Entidades.GrupoEstatus>();            
            DataTable dt = SQLHelper.GetTable("Sistema_GrupoEstatus_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.GrupoEstatus o = new Cosmos.Sistema.Entidades.GrupoEstatus();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Consultar(int sistemaGrupoEstatusID) {
            return Consultar(new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Consultar(Cosmos.Sistema.Entidades.GrupoEstatus o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_GrupoEstatus_Consultar", o.SistemaGrupoEstatusID);
            o = new Cosmos.Sistema.Entidades.GrupoEstatus();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Guardar(int modificacionUsuarioID, int sistemaGrupoEstatusID, int sistemaGrupoID, string nombre, int tipoDocumentoID, string color, bool activo) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID, SistemaGrupoID = sistemaGrupoID, Nombre = nombre, TipoDocumentoID = tipoDocumentoID, Color = color, Activo = activo  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoEstatus Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.GrupoEstatus o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_GrupoEstatus_Guardar", modificacionUsuarioID, o.SistemaGrupoEstatusID, o.SistemaGrupoID, o.Nombre, o.TipoDocumentoID, o.Color, o.Activo);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaGrupoEstatusID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaGrupoEstatusID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.GrupoEstatus() { SistemaGrupoEstatusID = sistemaGrupoEstatusID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.GrupoEstatus o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_GrupoEstatus_Eliminar", modificacionUsuarioID, o.SistemaGrupoEstatusID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
