
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class TipoDocumento
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoDocumento> Listado() {            
            List<Cosmos.Sistema.Entidades.TipoDocumento> lst = new List<Cosmos.Sistema.Entidades.TipoDocumento>();            
            DataTable dt = SQLHelper.GetTable("Sistema_TipoDocumento_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.TipoDocumento o = new Cosmos.Sistema.Entidades.TipoDocumento();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Consultar(int tipoDocumentoID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Consultar(Cosmos.Sistema.Entidades.TipoDocumento o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_TipoDocumento_Consultar", o.TipoDocumentoID);
            o = new Cosmos.Sistema.Entidades.TipoDocumento();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Guardar(int modificacionUsuarioID, int tipoDocumentoID, string tipoDocumentoClave, string nombre, string nombreCorto, bool estatus, int moduloID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID, TipoDocumentoClave = tipoDocumentoClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus, ModuloID = moduloID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoDocumento Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoDocumento_Guardar", modificacionUsuarioID, o.TipoDocumentoID, o.TipoDocumentoClave, o.Nombre, o.NombreCorto, o.Estatus, o.ModuloID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoDocumentoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoDocumentoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoDocumento() { TipoDocumentoID = tipoDocumentoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoDocumento o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoDocumento_Eliminar", modificacionUsuarioID, o.TipoDocumentoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
