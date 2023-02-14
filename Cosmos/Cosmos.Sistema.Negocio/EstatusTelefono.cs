
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class EstatusTelefono
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.EstatusTelefono> Listado() {            
            List<Cosmos.Sistema.Entidades.EstatusTelefono> lst = new List<Cosmos.Sistema.Entidades.EstatusTelefono>();            
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusTelefono_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.EstatusTelefono o = new Cosmos.Sistema.Entidades.EstatusTelefono();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Consultar(int estatusTelefonoID) {
            return Consultar(new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Consultar(Cosmos.Sistema.Entidades.EstatusTelefono o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_EstatusTelefono_Consultar", o.EstatusTelefonoID);
            o = new Cosmos.Sistema.Entidades.EstatusTelefono();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Guardar(int modificacionUsuarioID, int estatusTelefonoID, string estatusTelefonoClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID, EstatusTelefonoClave = estatusTelefonoClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Sistema.Entidades.EstatusTelefono Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusTelefono_Guardar", modificacionUsuarioID, o.EstatusTelefonoID, o.EstatusTelefonoClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EstatusTelefonoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int estatusTelefonoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.EstatusTelefono() { EstatusTelefonoID = estatusTelefonoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.EstatusTelefono o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_EstatusTelefono_Eliminar", modificacionUsuarioID, o.EstatusTelefonoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
