
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class TipoHorario
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.TipoHorario> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.TipoHorario() { EmpresaID = empresaID });
        }
        public static List<Cosmos.Compras.Entidades.TipoHorario> Listado(Cosmos.Compras.Entidades.TipoHorario entidad) {            
            List<Cosmos.Compras.Entidades.TipoHorario> lst = new List<Cosmos.Compras.Entidades.TipoHorario>();            
            DataTable dt = SQLHelper.GetTable("Compras_TipoHorario_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.TipoHorario o = new Cosmos.Compras.Entidades.TipoHorario();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.TipoHorario Consultar(int tipoHorarioID) {
            return Consultar(new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID  });
        }
        
        public static Cosmos.Compras.Entidades.TipoHorario Consultar(Cosmos.Compras.Entidades.TipoHorario o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_TipoHorario_Consultar", o.TipoHorarioID);
            o = new Cosmos.Compras.Entidades.TipoHorario();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.TipoHorario Guardar(int modificacionUsuarioID, int tipoHorarioID, string tipoHorarioClave, string nombre, string nombreCorto, int empresaID, string homogeneo) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID, TipoHorarioClave = tipoHorarioClave, Nombre = nombre, NombreCorto = nombreCorto, EmpresaID = empresaID, Homogeneo = homogeneo  });
        }
        
        public static Cosmos.Compras.Entidades.TipoHorario Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoHorario o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoHorario_Guardar", modificacionUsuarioID, o.TipoHorarioID, o.TipoHorarioClave, o.Nombre, o.NombreCorto, o.EmpresaID, o.Homogeneo);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoHorarioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoHorarioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.TipoHorario() { TipoHorarioID = tipoHorarioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.TipoHorario o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_TipoHorario_Eliminar", modificacionUsuarioID, o.TipoHorarioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
