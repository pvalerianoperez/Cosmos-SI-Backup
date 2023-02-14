
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class EstatusDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusDocumento> Listado() {            
            List<Cosmos.Sistema.Entidades.EstatusDocumento> lst = new List<Cosmos.Sistema.Entidades.EstatusDocumento>();            
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusDocumento_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.EstatusDocumento o = new Cosmos.Sistema.Entidades.EstatusDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Consultar(int sistemaEstatusDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Consultar(Cosmos.Sistema.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusDocumento_Consultar", o.SistemaEstatusDocumentoID);
            o = new Cosmos.Sistema.Entidades.EstatusDocumento();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Guardar(int modificacionUsuarioID, int sistemaEstatusDocumentoID, string sistemaEstatusDocumentoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, SistemaEstatusDocumentoClave = sistemaEstatusDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusDocumento Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusDocumento_Guardar", modificacionUsuarioID, o.SistemaEstatusDocumentoID, o.SistemaEstatusDocumentoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SistemaEstatusDocumentoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sistemaEstatusDocumentoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusDocumento() { SistemaEstatusDocumentoID = sistemaEstatusDocumentoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusDocumento_Eliminar", modificacionUsuarioID, o.SistemaEstatusDocumentoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
