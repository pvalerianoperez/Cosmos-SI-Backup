
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class TipoTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoTelefono> Listado() {            
            List<Cosmos.Sistema.Entidades.TipoTelefono> lst = new List<Cosmos.Sistema.Entidades.TipoTelefono>();            
            DataTable dt = SQLHelper.GetTable("Sistema_TipoTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.TipoTelefono o = new Cosmos.Sistema.Entidades.TipoTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Consultar(int tipoTelefonoID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Consultar(Cosmos.Sistema.Entidades.TipoTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_TipoTelefono_Consultar", o.TipoTelefonoID);
            o = new Cosmos.Sistema.Entidades.TipoTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Guardar(int modificacionUsuarioID, int tipoTelefonoID, string tipoTelefonoClave, string nombre, string nombreCorto, bool estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID, TipoTelefonoClave = tipoTelefonoClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoTelefono Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoTelefono_Guardar", modificacionUsuarioID, o.TipoTelefonoID, o.TipoTelefonoClave, o.Nombre, o.NombreCorto, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoTelefono() { TipoTelefonoID = tipoTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoTelefono_Eliminar", modificacionUsuarioID, o.TipoTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
