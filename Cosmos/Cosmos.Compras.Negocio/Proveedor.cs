
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Proveedor
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Proveedor> Listado() {            
            List<Cosmos.Compras.Entidades.Proveedor> lst = new List<Cosmos.Compras.Entidades.Proveedor>(); 
            DataTable dt = SQLHelper.GetTable("Compras_Proveedor_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Proveedor o = new Cosmos.Compras.Entidades.Proveedor();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Proveedor Consultar(int proveedorID) {
            return Consultar(new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID  });
        }        
        
        public static Cosmos.Compras.Entidades.Proveedor Consultar(Cosmos.Compras.Entidades.Proveedor o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Proveedor_Consultar", o.ProveedorID);
            o = new Cosmos.Compras.Entidades.Proveedor();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Proveedor Guardar(int modificacionUsuarioID, int proveedorID, int personaID, string nombreCorto, int tipoProveedorID, int giroEmpresaID, int medioContactoID, int vinculoID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID, PersonaID = personaID, NombreCorto = nombreCorto, TipoProveedorID = tipoProveedorID, GiroEmpresaID = giroEmpresaID, MedioContactoID = medioContactoID, VinculoID = vinculoID  });
        }
        
        public static Cosmos.Compras.Entidades.Proveedor Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Proveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Proveedor_Guardar", modificacionUsuarioID, o.ProveedorID, o.PersonaID, o.NombreCorto, o.TipoProveedorID, o.GiroEmpresaID, o.MedioContactoID, o.VinculoID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["ProveedorID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int proveedorID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Proveedor() { ProveedorID = proveedorID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Proveedor o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Proveedor_Eliminar", modificacionUsuarioID, o.ProveedorID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static Cosmos.Compras.Entidades.Proveedor ConsultarCompleto(int proveedorID)
        {

            //crea un objeto de tipo entidad
            Cosmos.Compras.Entidades.Proveedor o = Consultar(proveedorID);
            if (o != null && o.ProveedorID > 0)
            {
                //carga la persona relacionada
                if (o.PersonaID != 0)
                {
                    o.Load(SQLHelper.GetFirstRow("Compras_Persona_Consultar", o.PersonaID));
                }

                //domicilios
                o.Domicilios = new List<Cosmos.Compras.Entidades.ProveedorDomicilio>();
                DataTable dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*, b.ProveedorDomicilioID, b.ProveedorID, b.Nombre FROM vDomicilio a INNER JOIN ProveedorDomicilio b ON a.DomicilioID = b.DomicilioID WHERE b.ProveedorID={0}", o.ProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorDomicilio oDet = new Cosmos.Compras.Entidades.ProveedorDomicilio();
                    oDet.Load(item);
                    o.Domicilios.Add(oDet);
                }

                //sucursales
                o.Sucursales = new List<Cosmos.Compras.Entidades.ProveedorSucursal>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*,b.ProveedorSucursalID, b.ProveedorID, b.ProveedorClave FROM Sucursal a INNER JOIN ProveedorSucursal b ON a.SucursalID = b.SucursalID WHERE b.ProveedorID={0}", o.ProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorSucursal oDet = new Cosmos.Compras.Entidades.ProveedorSucursal();
                    oDet.Load(item);
                    o.Sucursales.Add(oDet);
                }

                //telefonos
                o.Telefonos = new List<Cosmos.Compras.Entidades.ProveedorTelefono>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*, b.ProveedorTelefonoID, b.Comentarios, b.Predeterminado FROM Telefono a INNER JOIN ProveedorTelefono b ON a.TelefonoID = b.TelefonoID WHERE b.ProveedorID={0}", o.ProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorTelefono oDet = new Cosmos.Compras.Entidades.ProveedorTelefono();
                    oDet.Load(item);
                    o.Telefonos.Add(oDet);
                }

                //mail
                o.Mails = new List<Cosmos.Compras.Entidades.ProveedorMail>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.* FROM ProveedorMail a WHERE a.ProveedorID={0}", o.ProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.ProveedorMail oDet = new Cosmos.Compras.Entidades.ProveedorMail();
                    oDet.Load(item);
                    o.Mails.Add(oDet);
                }

                //representantes
                o.Representantes = new List<Cosmos.Compras.Entidades.RepresentanteProveedor>();
                dtX = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*, b.RepresentanteProveedorID, b.ProveedorID FROM Persona a INNER JOIN RepresentanteProveedor b ON a.PersonaID = b.PersonaID WHERE b.ProveedorID={0}", o.ProveedorID));
                foreach (DataRow item in dtX.Rows)
                {
                    Cosmos.Compras.Entidades.RepresentanteProveedor oDet = new Cosmos.Compras.Entidades.RepresentanteProveedor();
                    oDet.Load(item);

                    oDet.Domicilios = new List<Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio>();
                    DataTable dtX1 = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*, b.RepresentanteProveedorDomicilioID, b.RepresentanteProveedorID FROM Domicilio a INNER JOIN RepresentanteProveedorDomicilio b ON a.DomicilioID = b.DomicilioID WHERE b.RepresentanteProveedorID={0}", oDet.RepresentanteProveedorID));
                    foreach (DataRow itemX1 in dtX1.Rows)
                    {
                        Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio oDetX1 = new Cosmos.Compras.Entidades.RepresentanteProveedorDomicilio();
                        oDetX1.Load(itemX1);
                        oDet.Domicilios.Add(oDetX1);
                    }

                    oDet.Mails = new List<Cosmos.Compras.Entidades.RepresentanteProveedorMail>();
                    dtX1 = SQLHelper.GetTableFromQuery(string.Format("SELECT a.* FROM RepresentanteProveedorMail a WHERE a.RepresentanteProveedorID={0}", oDet.RepresentanteProveedorID));
                    foreach (DataRow itemX1 in dtX1.Rows)
                    {
                        Cosmos.Compras.Entidades.RepresentanteProveedorMail oDetX1 = new Cosmos.Compras.Entidades.RepresentanteProveedorMail();
                        oDetX1.Load(itemX1);
                        oDet.Mails.Add(oDetX1);
                    }

                    oDet.Telefonos = new List<Cosmos.Compras.Entidades.RepresentanteProveedorTelefono>();
                    dtX1 = SQLHelper.GetTableFromQuery(string.Format("SELECT a.*,b.RepresentanteProveedorTelefonoID, b.RepresentanteProveedorID, b.Predeterminado, b.Extension, b.Comentarios FROM Telefono a INNER JOIN RepresentanteProveedorTelefono b ON a.TelefonoID = b.TelefonoID WHERE b.RepresentanteProveedorID={0}", oDet.RepresentanteProveedorID));
                    foreach (DataRow itemX1 in dtX1.Rows)
                    {
                        Cosmos.Compras.Entidades.RepresentanteProveedorTelefono oDetX1 = new Cosmos.Compras.Entidades.RepresentanteProveedorTelefono();
                        oDetX1.Load(itemX1);
                        oDet.Telefonos.Add(oDetX1);
                    }

                    o.Representantes.Add(oDet);
                }
            }
            return o;
        }
    }
}
