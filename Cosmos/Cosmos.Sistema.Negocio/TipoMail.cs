
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class TipoMail
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.TipoMail> Listado() {            
            List<Cosmos.Sistema.Entidades.TipoMail> lst = new List<Cosmos.Sistema.Entidades.TipoMail>();            
            DataTable dt = SQLHelper.GetTable("Sistema_TipoMail_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.TipoMail o = new Cosmos.Sistema.Entidades.TipoMail();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.TipoMail Consultar(int tipoMailID) {
            return Consultar(new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoMail Consultar(Cosmos.Sistema.Entidades.TipoMail o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_TipoMail_Consultar", o.TipoMailID);
            o = new Cosmos.Sistema.Entidades.TipoMail();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.TipoMail Guardar(int modificacionUsuarioID, int tipoMailID, string tipoMailClave, string nombre, string nombreCorto, bool estatus) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID, TipoMailClave = tipoMailClave, Nombre = nombre, NombreCorto = nombreCorto, Estatus = estatus  });
        }
        
        public static Cosmos.Sistema.Entidades.TipoMail Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoMail_Guardar", modificacionUsuarioID, o.TipoMailID, o.TipoMailClave, o.Nombre, o.NombreCorto, o.Estatus);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["TipoMailID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int tipoMailID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.TipoMail() { TipoMailID = tipoMailID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.TipoMail o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_TipoMail_Eliminar", modificacionUsuarioID, o.TipoMailID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
