
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Seguridad.Negocio
{
    public partial class UsuarioOpcionBitacora
    {
    
        #region CRUD

        public static List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora> Listado() {            
            List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora> lst = new List<Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora>();            
            DataTable dt = SQLHelper.GetTable("Seguridad_UsuarioOpcionBitacora_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora o = new Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static bool Guardar(int modificacionUsuarioID, int usuarioID, DateTime fecha, int empresaID, int moduloID, int opcionID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora() { UsuarioID = usuarioID, Fecha = fecha, EmpresaID = empresaID, ModuloID = moduloID, OpcionID = opcionID  });
        }
        
        public static bool Guardar(int modificacionUsuarioID, Cosmos.Seguridad.Entidades.UsuarioOpcionBitacora o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Seguridad_UsuarioOpcionBitacora_Guardar", modificacionUsuarioID, o.UsuarioID, o.Fecha, o.EmpresaID, o.ModuloID, o.OpcionID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
        #endregion
        
       
    }
}
