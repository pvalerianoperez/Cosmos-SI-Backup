
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Almacen
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Almacen> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Almacen> Listado(Cosmos.Compras.Entidades.Sucursal entidad) {            
            List<Cosmos.Compras.Entidades.Almacen> lst = new List<Cosmos.Compras.Entidades.Almacen>();            
            DataTable dt = SQLHelper.GetTable("Compras_Almacen_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Almacen o = new Cosmos.Compras.Entidades.Almacen();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Almacen Consultar(int almacenID) {
            return Consultar(new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID  });
        }
        
        public static Cosmos.Compras.Entidades.Almacen Consultar(Cosmos.Compras.Entidades.Almacen o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Almacen_Consultar", o.AlmacenID);
            o = new Cosmos.Compras.Entidades.Almacen();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Almacen Guardar(int modificacionUsuarioID, int almacenID, string almacenClave, string nombre, string nombreCorto, int sucursalID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID, AlmacenClave = almacenClave, Nombre = nombre, NombreCorto = nombreCorto, SucursalID = sucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.Almacen Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Almacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Almacen_Guardar", modificacionUsuarioID, o.AlmacenID, o.AlmacenClave, o.Nombre, o.NombreCorto, o.SucursalID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["AlmacenID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int almacenID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Almacen() { AlmacenID = almacenID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Almacen o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Almacen_Eliminar", modificacionUsuarioID, o.AlmacenID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
