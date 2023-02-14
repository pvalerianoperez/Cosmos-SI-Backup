
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Area
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Area> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Area() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Area> Listado(Cosmos.Compras.Entidades.Area entidad) {            
            List<Cosmos.Compras.Entidades.Area> lst = new List<Cosmos.Compras.Entidades.Area>();            
            DataTable dt = SQLHelper.GetTable("Compras_Area_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Area o = new Cosmos.Compras.Entidades.Area();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Area Consultar(int areaId) {
            return Consultar(new Cosmos.Compras.Entidades.Area() { AreaId = areaId  });
        }
        
        public static Cosmos.Compras.Entidades.Area Consultar(Cosmos.Compras.Entidades.Area o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Area_Consultar", o.AreaId);
            o = new Cosmos.Compras.Entidades.Area();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Area Guardar(int modificacionUsuarioID, int areaId, string areaClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Area() { AreaId = areaId, AreaClave = areaClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.Area Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Area o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Area_Guardar", modificacionUsuarioID, o.AreaId, o.AreaClave, o.Nombre, o.NombreCorto, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["AreaId"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int areaId) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Area() { AreaId = areaId  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Area o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Area_Eliminar", modificacionUsuarioID, o.AreaId);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
