
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class EstatusTipoDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> Listado() {            
            List<Cosmos.Sistema.Entidades.EstatusTipoDocumento> lst = new List<Cosmos.Sistema.Entidades.EstatusTipoDocumento>();            
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusTipoDocumento_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.EstatusTipoDocumento o = new Cosmos.Sistema.Entidades.EstatusTipoDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Consultar(int sistemaEstatusTipoDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Consultar(Cosmos.Sistema.Entidades.EstatusTipoDocumento o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusTipoDocumento_Consultar", o.SistemaEstatusTipoDocumentoID);
            o = new Cosmos.Sistema.Entidades.EstatusTipoDocumento();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Guardar(int modificacionUsuarioID, int sistemaEstatusTipoDocumentoID, int sistemaEstatusDocumentoID, int tipoDocumentoID, bool predeterminado, bool restringido, bool monto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, TipoDocumentoID = tipoDocumentoID, Predeterminado = predeterminado, Restringido = restringido, Monto = monto  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTipoDocumento Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusTipoDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusTipoDocumento_Guardar", modificacionUsuarioID, o.SistemaEstatusTipoDocumentoID, o.SistemaEstatusDocumentoID, o.TipoDocumentoID, o.Predeterminado, o.Restringido, o.Monto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaEstatusTipoDocumentoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaEstatusTipoDocumentoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusTipoDocumento() { SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusTipoDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusTipoDocumento_Eliminar", modificacionUsuarioID, o.SistemaEstatusTipoDocumentoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
