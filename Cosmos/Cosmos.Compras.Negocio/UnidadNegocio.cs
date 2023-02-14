
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class UnidadNegocio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.UnidadNegocio> Listado() {            
            List<Cosmos.Compras.Entidades.UnidadNegocio> lst = new List<Cosmos.Compras.Entidades.UnidadNegocio>();            
            DataTable dt = SQLHelper.GetTable("Compras_UnidadNegocio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.UnidadNegocio o = new Cosmos.Compras.Entidades.UnidadNegocio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Consultar(int unidadNegocioID) {
            return Consultar(new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID  });
        }
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Consultar(Cosmos.Compras.Entidades.UnidadNegocio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_UnidadNegocio_Consultar", o.UnidadNegocioID);
            o = new Cosmos.Compras.Entidades.UnidadNegocio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Guardar(int modificacionUsuarioID, int unidadNegocioID, string unidadNegocioClave, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID, UnidadNegocioClave = unidadNegocioClave, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.UnidadNegocio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UnidadNegocio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UnidadNegocio_Guardar", modificacionUsuarioID, o.UnidadNegocioID, o.UnidadNegocioClave, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["UnidadNegocioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int unidadNegocioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.UnidadNegocio() { UnidadNegocioID = unidadNegocioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.UnidadNegocio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_UnidadNegocio_Eliminar", modificacionUsuarioID, o.UnidadNegocioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
