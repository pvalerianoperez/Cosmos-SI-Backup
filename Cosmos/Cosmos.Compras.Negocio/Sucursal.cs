
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Sucursal
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Sucursal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Sucursal> Listado(Cosmos.Compras.Entidades.Sucursal entidad) {            
            List<Cosmos.Compras.Entidades.Sucursal> lst = new List<Cosmos.Compras.Entidades.Sucursal>();            
            DataTable dt = SQLHelper.GetTable("Compras_Sucursal_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Sucursal o = new Cosmos.Compras.Entidades.Sucursal();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Sucursal Consultar(int sucursalID) {
            return Consultar(new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.Sucursal Consultar(Cosmos.Compras.Entidades.Sucursal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Sucursal_Consultar", o.SucursalID);
            o = new Cosmos.Compras.Entidades.Sucursal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Sucursal Guardar(int modificacionUsuarioID, int sucursalID, string sucursalClave, string nombre, string nombreCorto, int empresaID, int domicilioID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID, SucursalClave = sucursalClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID, DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.Sucursal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Sucursal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Sucursal_Guardar", modificacionUsuarioID, o.SucursalID, o.SucursalClave, o.Nombre, o.NombreCorto, o.EmpresaID, o.DomicilioID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SucursalID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int sucursalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Sucursal() { SucursalID = sucursalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Sucursal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Sucursal_Eliminar", modificacionUsuarioID, o.SucursalID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
