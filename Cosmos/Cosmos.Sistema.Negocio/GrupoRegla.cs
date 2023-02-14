
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class GrupoRegla
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.GrupoRegla> Listado() {            
            List<Cosmos.Sistema.Entidades.GrupoRegla> lst = new List<Cosmos.Sistema.Entidades.GrupoRegla>();            
            DataTable dt = SQLHelper.GetTable("Sistema_GrupoRegla_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.GrupoRegla o = new Cosmos.Sistema.Entidades.GrupoRegla();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Consultar(int sistemaGrupoReglaID) {
            return Consultar(new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Consultar(Cosmos.Sistema.Entidades.GrupoRegla o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_GrupoRegla_Consultar", o.SistemaGrupoReglaID);
            o = new Cosmos.Sistema.Entidades.GrupoRegla();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Guardar(int modificacionUsuarioID, int sistemaGrupoReglaID, int sistemaGrupoEstatusID, int sistemaEstatusTipoDocumentoID, bool activo) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID, SistemaGrupoEstatusID = sistemaGrupoEstatusID, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, Activo = activo  });
        }
        
        public static Cosmos.Sistema.Entidades.GrupoRegla Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.GrupoRegla o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_GrupoRegla_Guardar", modificacionUsuarioID, o.SistemaGrupoReglaID, o.SistemaGrupoEstatusID, o.SistemaEstatusTipoDocumentoID, o.Activo);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaGrupoReglaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaGrupoReglaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.GrupoRegla() { SistemaGrupoReglaID = sistemaGrupoReglaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.GrupoRegla o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_GrupoRegla_Eliminar", modificacionUsuarioID, o.SistemaGrupoReglaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
