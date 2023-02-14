
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class BitacoraEstatus
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.BitacoraEstatus> Listado() {            
            List<Cosmos.Sistema.Entidades.BitacoraEstatus> lst = new List<Cosmos.Sistema.Entidades.BitacoraEstatus>();            
            DataTable dt = SQLHelper.GetTable("Sistema_BitacoraEstatus_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.BitacoraEstatus o = new Cosmos.Sistema.Entidades.BitacoraEstatus();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Consultar(int bitacoraEstatusID) {
            return Consultar(new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID  });
        }
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Consultar(Cosmos.Sistema.Entidades.BitacoraEstatus o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_BitacoraEstatus_Consultar", o.BitacoraEstatusID);
            o = new Cosmos.Sistema.Entidades.BitacoraEstatus();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Guardar(int modificacionUsuarioID, int bitacoraEstatusID, int tipoDocumentoID, int documentoID, int usuarioID, int sistemaEstatusDocumentoID, int sistemaEstatusDocumentoIDAnterior, DateTime fechaHora) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID, TipoDocumentoID = tipoDocumentoID, DocumentoID = documentoID, UsuarioID = usuarioID, SistemaEstatusDocumentoID = sistemaEstatusDocumentoID, SistemaEstatusDocumentoIDAnterior = sistemaEstatusDocumentoIDAnterior, FechaHora = fechaHora  });
        }
        
        public static Cosmos.Sistema.Entidades.BitacoraEstatus Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.BitacoraEstatus o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_BitacoraEstatus_Guardar", modificacionUsuarioID, o.BitacoraEstatusID, o.TipoDocumentoID, o.DocumentoID, o.UsuarioID, o.SistemaEstatusDocumentoID, o.SistemaEstatusDocumentoIDAnterior, o.FechaHora);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["BitacoraEstatusID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int bitacoraEstatusID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.BitacoraEstatus() { BitacoraEstatusID = bitacoraEstatusID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.BitacoraEstatus o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_BitacoraEstatus_Eliminar", modificacionUsuarioID, o.BitacoraEstatusID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
