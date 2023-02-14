
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class HorarioPersonal
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.HorarioPersonal> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.HorarioPersonal() { EmpresaID = empresaID });
        }

        public static List<Cosmos.Compras.Entidades.HorarioPersonal> Listado(Cosmos.Compras.Entidades.HorarioPersonal o) {            
            List<Cosmos.Compras.Entidades.HorarioPersonal> lst = new List<Cosmos.Compras.Entidades.HorarioPersonal>();            
            DataTable dt = SQLHelper.GetTable("Compras_HorarioPersonal_Listado", o.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.HorarioPersonal entidad = new Cosmos.Compras.Entidades.HorarioPersonal();
                    entidad.Load(dr);
                    lst.Add(entidad);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Consultar(int horarioPersonalID) {
            return Consultar(new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID  });
        }
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Consultar(Cosmos.Compras.Entidades.HorarioPersonal o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_HorarioPersonal_Consultar", o.HorarioPersonalID);
            o = new Cosmos.Compras.Entidades.HorarioPersonal();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Guardar(int modificacionUsuarioID, int horarioPersonalID, string horarioPersonalClave, int empresaID, string nombre, string nombreCorto) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID, HorarioPersonalClave = horarioPersonalClave, EmpresaID = empresaID, Nombre = nombre, NombreCorto = nombreCorto  });
        }
        
        public static Cosmos.Compras.Entidades.HorarioPersonal Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.HorarioPersonal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_HorarioPersonal_Guardar", modificacionUsuarioID, o.HorarioPersonalID, o.HorarioPersonalClave, o.EmpresaID, o.Nombre, o.NombreCorto);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["HorarioPersonalID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int horarioPersonalID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.HorarioPersonal() { HorarioPersonalID = horarioPersonalID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.HorarioPersonal o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_HorarioPersonal_Eliminar", modificacionUsuarioID, o.HorarioPersonalID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
