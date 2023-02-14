
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class GiroEmpresa
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.GiroEmpresa> Listado() {            
            List<Cosmos.Compras.Entidades.GiroEmpresa> lst = new List<Cosmos.Compras.Entidades.GiroEmpresa>();            
            DataTable dt = SQLHelper.GetTable("Compras_GiroEmpresa_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.GiroEmpresa o = new Cosmos.Compras.Entidades.GiroEmpresa();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Consultar(int giroEmpresaID) {
            return Consultar(new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID  });
        }
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Consultar(Cosmos.Compras.Entidades.GiroEmpresa o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_GiroEmpresa_Consultar", o.GiroEmpresaID);
            o = new Cosmos.Compras.Entidades.GiroEmpresa();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Guardar(int modificacionUsuarioID, int giroEmpresaID, string giroEmpresaClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID, GiroEmpresaClave = giroEmpresaClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.GiroEmpresa Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.GiroEmpresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_GiroEmpresa_Guardar", modificacionUsuarioID, o.GiroEmpresaID, o.GiroEmpresaClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["GiroEmpresaID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int giroEmpresaID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.GiroEmpresa() { GiroEmpresaID = giroEmpresaID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.GiroEmpresa o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_GiroEmpresa_Eliminar", modificacionUsuarioID, o.GiroEmpresaID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
