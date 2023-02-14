
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Sistema.Negocio
{
    public partial class PersonalTipoContacto
    {
    
        #region CRUD

        public static List<Cosmos.Sistema.Entidades.PersonalTipoContacto> Listado() {            
            List<Cosmos.Sistema.Entidades.PersonalTipoContacto> lst = new List<Cosmos.Sistema.Entidades.PersonalTipoContacto>();            
            DataTable dt = SQLHelper.GetTable("Sistema_PersonalTipoContacto_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Sistema.Entidades.PersonalTipoContacto o = new Cosmos.Sistema.Entidades.PersonalTipoContacto();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Consultar(int personalTipoContactoID) {
            return Consultar(new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID  });
        }
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Consultar(Cosmos.Sistema.Entidades.PersonalTipoContacto o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Sistema_PersonalTipoContacto_Consultar", o.PersonalTipoContactoID);
            o = new Cosmos.Sistema.Entidades.PersonalTipoContacto();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Guardar(int modificacionUsuarioID, int personalTipoContactoID, string nombre, string nombreCorto, bool conyuge) {
            return Guardar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID, Nombre = nombre, NombreCorto = nombreCorto, Conyuge = conyuge  });
        }
        
        public static Cosmos.Sistema.Entidades.PersonalTipoContacto Guardar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.PersonalTipoContacto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_PersonalTipoContacto_Guardar", modificacionUsuarioID, o.PersonalTipoContactoID, o.Nombre, o.NombreCorto, o.Conyuge);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["PersonalTipoContactoID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int personalTipoContactoID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Sistema.Entidades.PersonalTipoContacto() { PersonalTipoContactoID = personalTipoContactoID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Sistema.Entidades.PersonalTipoContacto o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Sistema_PersonalTipoContacto_Eliminar", modificacionUsuarioID, o.PersonalTipoContactoID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
