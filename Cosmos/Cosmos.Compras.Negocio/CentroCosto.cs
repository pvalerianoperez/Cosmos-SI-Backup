
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class CentroCosto
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.CentroCosto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.CentroCosto() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.CentroCosto> Listado(Cosmos.Compras.Entidades.CentroCosto entidad) {            
            List<Cosmos.Compras.Entidades.CentroCosto> lst = new List<Cosmos.Compras.Entidades.CentroCosto>();            
            DataTable dt = SQLHelper.GetTable("Compras_CentroCosto_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.CentroCosto o = new Cosmos.Compras.Entidades.CentroCosto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.CentroCosto Consultar(int centroCostoID) {
            return Consultar(new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID  });
        }
        
        public static Cosmos.Compras.Entidades.CentroCosto Consultar(Cosmos.Compras.Entidades.CentroCosto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_CentroCosto_Consultar", o.CentroCostoID);
            o = new Cosmos.Compras.Entidades.CentroCosto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.CentroCosto Guardar(int modificacionUsuarioID, int centroCostoID, string centroCostoClave, string nombre, string nombreCorto, string administracion) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID, CentroCostoClave = centroCostoClave, Nombre = nombre, NombreCorto = nombreCorto, Administracion = administracion  });
        }
        
        public static Cosmos.Compras.Entidades.CentroCosto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.CentroCosto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_CentroCosto_Guardar", modificacionUsuarioID, o.CentroCostoID, o.EmpresaID, o.CentroCostoClave, o.Nombre, o.NombreCorto, o.Administracion);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["CentroCostoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int centroCostoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.CentroCosto() { CentroCostoID = centroCostoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.CentroCosto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_CentroCosto_Eliminar", modificacionUsuarioID, o.CentroCostoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
