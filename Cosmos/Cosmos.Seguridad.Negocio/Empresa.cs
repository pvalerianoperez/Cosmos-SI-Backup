
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class Empresa
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.Empresa> Listado() {            
            List<Cosmos.Seguridad.Entidades.Empresa> lst = new List<Cosmos.Seguridad.Entidades.Empresa>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_Empresa_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.Empresa o = new Cosmos.Seguridad.Entidades.Empresa();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Seguridad.Entidades.Empresa Consultar(int empresaID) {
            return Consultar(new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID  });
        }
        
        public static Cosmos.Seguridad.Entidades.Empresa Consultar(Cosmos.Seguridad.Entidades.Empresa o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Seguridad_Empresa_Consultar", o.EmpresaID);
            o = new Cosmos.Seguridad.Entidades.Empresa();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Seguridad.Entidades.Empresa Guardar(int modificacionUsuarioID, int empresaID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Seguridad.Entidades.Empresa Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Empresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Empresa_Guardar", modificacionUsuarioID, o.EmpresaID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["EmpresaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int empresaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.Empresa() { EmpresaID = empresaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.Empresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_Empresa_Eliminar", modificacionUsuarioID, o.EmpresaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
