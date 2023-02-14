
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class RepresentanteProveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.RepresentanteProveedor> Listado() {            
            List<Cosmos.Compras.Entidades.RepresentanteProveedor> lst = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();            
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedor_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor o = new Cosmos.Compras.Entidades.RepresentanteProveedor();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Consultar(int representanteProveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Consultar(Cosmos.Compras.Entidades.RepresentanteProveedor o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_RepresentanteProveedor_Consultar", o.RepresentanteProveedorID);
            o = new Cosmos.Compras.Entidades.RepresentanteProveedor();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Guardar(int modificacionUsuarioID, int representanteProveedorID, int proveedorID, int personaID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID, ProveedorID = proveedorID, PersonaID = personaID  });
        }
        
        public static Cosmos.Compras.Entidades.RepresentanteProveedor Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedor_Guardar", modificacionUsuarioID, o.RepresentanteProveedorID, o.ProveedorID, o.PersonaID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["RepresentanteProveedorID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int representanteProveedorID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.RepresentanteProveedor() { RepresentanteProveedorID = representanteProveedorID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.RepresentanteProveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_RepresentanteProveedor_Eliminar", modificacionUsuarioID, o.RepresentanteProveedorID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static Cosmos.Compras.Entidades.RepresentanteProveedor ConsultarCompleto(int representanteProveedorID)
        {

            //crea un objeto de tipo entidad
            Cosmos.Compras.Entidades.RepresentanteProveedor o = Consultar(representanteProveedorID);
            if (o != null && o.RepresentanteProveedorID > 0)
            {
               
                //carga la persona relacionada
                if (o.PersonaID != 0)
                {
                    o.Load(SQLHelper.GetFirstRow("Compras_Persona_Consultar", o.PersonaID));
                }

                //domicilios
                o.Domicilios = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();
                DataTable dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*, b.RepresentanteProveedorDomicilioID, b.RepresentanteProveedorID, b.Nombre FROM vDomicilio a INNER JOIN RepresentanteProveedorDomicilio b ON a.DomicilioID = b.DomicilioID WHERE b.RepresentanteProveedorID={0}", o.RepresentanteProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio oDet = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
                    oDet.Load(item);
                    o.Domicilios.Add(oDet);
                }


                //telefonos
                o.Telefonos = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*,b.RepresentanteProveedorTelefonoID, b.RepresentanteProveedorID, b.Predeterminado, b.Extension, b.Comentarios FROM Telefono a INNER JOIN RepresentanteProveedorTelefono b ON a.TelefonoID = b.TelefonoID WHERE b.RepresentanteProveedorID={0}", o.RepresentanteProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorTelefono oDet = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
                    oDet.Load(item);
                    o.Telefonos.Add(oDet);
                }

                //mail
                o.Mails = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.* FROM RepresentanteProveedorMail a WHERE a.RepresentanteProveedorID={0}", o.RepresentanteProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedorMail oDet = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
                    oDet.Load(item);
                    o.Mails.Add(oDet);
                }

                
            }
            return o;
        }
    }
}
