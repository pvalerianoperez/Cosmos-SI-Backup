
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class UsuarioIntentos
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioIntentos> Listado() {            
            List<Cosmos.Seguridad.Entidades.UsuarioIntentos> lst = new List<Cosmos.Seguridad.Entidades.UsuarioIntentos>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_UsuarioIntentos_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.UsuarioIntentos o = new Cosmos.Seguridad.Entidades.UsuarioIntentos();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static bool Guardar(int modificacionUsuarioID, int usuarioID, DateTime fecha, string iP, string contrasena) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.UsuarioIntentos() { UsuarioID = usuarioID, Fecha = fecha, IP = iP, Contrasena = contrasena  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.UsuarioIntentos o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_UsuarioIntentos_Guardar", modificacionUsuarioID, o.UsuarioID, o.Fecha, o.IP, o.Contrasena);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        #endregion
        
       
    }
}
