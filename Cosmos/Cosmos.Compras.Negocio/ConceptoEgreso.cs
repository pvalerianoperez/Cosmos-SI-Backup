
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ConceptoEgreso
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.ConceptoEgreso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.ConceptoEgreso() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.ConceptoEgreso> Listado(Cosmos.Compras.Entidades.ConceptoEgreso entidad) {            
            List<Cosmos.Compras.Entidades.ConceptoEgreso> lst = new List<Cosmos.Compras.Entidades.ConceptoEgreso>();            
            DataTable dt = SQLHelper.GetTable("Compras_ConceptoEgreso_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ConceptoEgreso o = new Cosmos.Compras.Entidades.ConceptoEgreso();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Consultar(int conceptoEgresoID) {
            return Consultar(new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Consultar(Cosmos.Compras.Entidades.ConceptoEgreso o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ConceptoEgreso_Consultar", o.ConceptoEgresoID);
            o = new Cosmos.Compras.Entidades.ConceptoEgreso();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Guardar(int modificacionUsuarioID, int conceptoEgresoID, string conceptoEgresoClave, string nombre, string nombreCorto, string compraFactura, string desglosar, int empresaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID, ConceptoEgresoClave = conceptoEgresoClave, Nombre = nombre, NombreCorto = nombreCorto, CompraFactura = compraFactura, Desglosar = desglosar, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoEgreso Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ConceptoEgreso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ConceptoEgreso_Guardar", modificacionUsuarioID, o.ConceptoEgresoID, o.ConceptoEgresoClave, o.Nombre, o.NombreCorto, o.CompraFactura, o.Desglosar, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ConceptoEgresoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int conceptoEgresoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ConceptoEgreso() { ConceptoEgresoID = conceptoEgresoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ConceptoEgreso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ConceptoEgreso_Eliminar", modificacionUsuarioID, o.ConceptoEgresoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
