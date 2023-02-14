
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class EstatusDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.EstatusDocumento> Listado() {            
            List<Cosmos.Compras.Entidades.EstatusDocumento> lst = new List<Cosmos.Compras.Entidades.EstatusDocumento>();            
            DataTable dt = SQLHelper.GetTable("Compras_EstatusDocumento_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.EstatusDocumento o = new Cosmos.Compras.Entidades.EstatusDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Consultar(int estatusDocumentoID) {
            return Consultar(new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Consultar(Cosmos.Compras.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_EstatusDocumento_Consultar", o.EstatusDocumentoID);
            o = new Cosmos.Compras.Entidades.EstatusDocumento();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Guardar(int modificacionUsuarioID, int estatusDocumentoID, string estatusDocumentoClave, string nombre, string nombreCorto, int sistemaEstatusTipoDocumentoID, bool predeterminado) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID, EstatusDocumentoClave = estatusDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, SistemaEstatusTipoDocumentoID = sistemaEstatusTipoDocumentoID, Predeterminado = predeterminado  });
        }
        
        public static Cosmos.Compras.Entidades.EstatusDocumento Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstatusDocumento_Guardar", modificacionUsuarioID, o.EstatusDocumentoID, o.EstatusDocumentoClave, o.Nombre, o.NombreCorto, o.SistemaEstatusTipoDocumentoID, o.Predeterminado);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstatusDocumentoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estatusDocumentoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.EstatusDocumento() { EstatusDocumentoID = estatusDocumentoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.EstatusDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_EstatusDocumento_Eliminar", modificacionUsuarioID, o.EstatusDocumentoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static List<Cosmos.Compras.Entidades.EstatusDocumento> ListadoTipoDocumentoID(int tipoDocumentoID)
        {
            List<Cosmos.Compras.Entidades.EstatusDocumento> lst = new List<Cosmos.Compras.Entidades.EstatusDocumento>();
            DataTable dt = SQLHelper.GetTable("Compras_EstatusDocumento_ListadoTipoDocumentoID", tipoDocumentoID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.EstatusDocumento o = new Cosmos.Compras.Entidades.EstatusDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
    }
}
