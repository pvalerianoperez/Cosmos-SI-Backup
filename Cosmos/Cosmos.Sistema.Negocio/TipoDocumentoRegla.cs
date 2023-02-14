
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class TipoDocumentoRegla
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> Listado() {            
            List<Cosmos.Sistema.Entidades.TipoDocumentoRegla> lst = new List<Cosmos.Sistema.Entidades.TipoDocumentoRegla>();            
            DataTable dt = SQLHelper.GetTable("Sistema_TipoDocumentoRegla_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.TipoDocumentoRegla o = new Cosmos.Sistema.Entidades.TipoDocumentoRegla();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Consultar(int tipoDocumentoReglaID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Consultar(Cosmos.Sistema.Entidades.TipoDocumentoRegla o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_TipoDocumentoRegla_Consultar", o.TipoDocumentoReglaID);
            o = new Cosmos.Sistema.Entidades.TipoDocumentoRegla();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Guardar(int modificacionUsuarioID, int tipoDocumentoReglaID, int sistemaEstatusTipoDocumentoID, int sistemaEstatusTipoDocumentoIDPermite) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, SistemaEstatusTipoDocumentoIDPermite = sistemaEstatusTipoDocumentoIDPermite  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumentoRegla Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoDocumentoRegla o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoDocumentoRegla_Guardar", modificacionUsuarioID, o.TipoDocumentoReglaID, o.SistemaEstatusTipoDocumentoID, o.SistemaEstatusTipoDocumentoIDPermite);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoDocumentoReglaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoDocumentoReglaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoDocumentoRegla() { TipoDocumentoReglaID = tipoDocumentoReglaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoDocumentoRegla o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoDocumentoRegla_Eliminar", modificacionUsuarioID, o.TipoDocumentoReglaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
