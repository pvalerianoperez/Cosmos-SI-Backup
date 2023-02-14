
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class ConceptoIngreso
    {

        #region CRUD

        public static List<Cosmos.Compras.Entidades.ConceptoIngreso> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.ConceptoIngreso() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.ConceptoIngreso> Listado(Cosmos.Compras.Entidades.ConceptoIngreso entidad) {            
            List<Cosmos.Compras.Entidades.ConceptoIngreso> lst = new List<Cosmos.Compras.Entidades.ConceptoIngreso>();            
            DataTable dt = SQLHelper.GetTable("Compras_ConceptoIngreso_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.ConceptoIngreso o = new Cosmos.Compras.Entidades.ConceptoIngreso();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Consultar(int conceptoIngresoID) {
            return Consultar(new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Consultar(Cosmos.Compras.Entidades.ConceptoIngreso o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_ConceptoIngreso_Consultar", o.ConceptoIngresoID);
            o = new Cosmos.Compras.Entidades.ConceptoIngreso();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Guardar(int modificacionUsuarioID, int conceptoIngresoID, string nombre, string nombreCorto, int empresaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID  });
        }
        
        public static Cosmos.Compras.Entidades.ConceptoIngreso Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ConceptoIngreso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ConceptoIngreso_Guardar", modificacionUsuarioID, o.ConceptoIngresoID, o.Nombre, o.NombreCorto, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ConceptoIngresoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int conceptoIngresoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.ConceptoIngreso() { ConceptoIngresoID = conceptoIngresoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.ConceptoIngreso o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_ConceptoIngreso_Eliminar", modificacionUsuarioID, o.ConceptoIngresoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
