
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Domicilio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Domicilio> Listado() {            
            List<Cosmos.Compras.Entidades.Domicilio> lst = new List<Cosmos.Compras.Entidades.Domicilio>();            
            DataTable dt = SQLHelper.GetTable("Compras_Domicilio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Domicilio o = new Cosmos.Compras.Entidades.Domicilio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Domicilio Consultar(int domicilioID) {
            return Consultar(new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID  });
        }
        
        public static Cosmos.Compras.Entidades.Domicilio Consultar(Cosmos.Compras.Entidades.Domicilio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Domicilio_Consultar", o.DomicilioID);
            o = new Cosmos.Compras.Entidades.Domicilio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Domicilio Guardar(int modificacionUsuarioID, int domicilioID, string calle, string numeroExterior, string numeroInterior, string entreCalle1, string entreCalle2, int codigoPostal, string colonia, string coordenadas, int ciudadID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID, Calle = calle, NumeroExterior = numeroExterior, NumeroInterior = numeroInterior, EntreCalle1 = entreCalle1, EntreCalle2 = entreCalle2, CodigoPostal = codigoPostal, Colonia = colonia, Coordenadas = coordenadas, CiudadID = ciudadID  });
        }
        
        public static Cosmos.Compras.Entidades.Domicilio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Domicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Domicilio_Guardar", modificacionUsuarioID, o.DomicilioID, o.Calle, o.NumeroExterior, o.NumeroInterior, o.EntreCalle1, o.EntreCalle2, o.CodigoPostal, o.Colonia, o.Coordenadas, o.CiudadID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["DomicilioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int domicilioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Domicilio() { DomicilioID = domicilioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Domicilio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Domicilio_Eliminar", modificacionUsuarioID, o.DomicilioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
