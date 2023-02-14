
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Puesto
    {

        #region CRUD
     
        public static List<Cosmos.Compras.Entidades.Puesto> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Puesto() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.Puesto> Listado(Cosmos.Compras.Entidades.Puesto entidad) {            
            List<Cosmos.Compras.Entidades.Puesto> lst = new List<Cosmos.Compras.Entidades.Puesto>();            
            DataTable dt = SQLHelper.GetTable("Compras_Puesto_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Puesto o = new Cosmos.Compras.Entidades.Puesto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Puesto Consultar(int puestoID) {
            return Consultar(new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID  });
        }
        
        public static Cosmos.Compras.Entidades.Puesto Consultar(Cosmos.Compras.Entidades.Puesto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Puesto_Consultar", o.PuestoID);
            o = new Cosmos.Compras.Entidades.Puesto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Puesto Guardar(int modificacionUsuarioID, int puestoID, string puestoClave, string nombre, string nombreCorto, decimal sueldo, string baseNeto, string tipo, string objetivo, string reqAcademicos, int tiempoDesempeno) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID, PuestoClave = puestoClave, Nombre = nombre, NombreCorto = nombreCorto, Sueldo = sueldo, BaseNeto = baseNeto, Tipo = tipo, Objetivo = objetivo, ReqAcademicos = reqAcademicos, TiempoDesempeno = tiempoDesempeno  });
        }
        
        public static Cosmos.Compras.Entidades.Puesto Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Puesto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Puesto_Guardar", modificacionUsuarioID, o.PuestoID, o.PuestoClave, o.Nombre, o.NombreCorto, o.Sueldo, o.BaseNeto, o.Tipo, o.Objetivo, o.ReqAcademicos, o.TiempoDesempeno, o.EmpresaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PuestoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int puestoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Puesto() { PuestoID = puestoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Puesto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Puesto_Eliminar", modificacionUsuarioID, o.PuestoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
