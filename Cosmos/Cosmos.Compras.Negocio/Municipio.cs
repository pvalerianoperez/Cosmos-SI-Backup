
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Municipio
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Municipio> Listado() {            
            List<Cosmos.Compras.Entidades.Municipio> lst = new List<Cosmos.Compras.Entidades.Municipio>();            
            DataTable dt = SQLHelper.GetTable("Compras_Municipio_Listado");
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Municipio o = new Cosmos.Compras.Entidades.Municipio();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Municipio Consultar(int municipioID) {
            return Consultar(new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID  });
        }
        
        public static Cosmos.Compras.Entidades.Municipio Consultar(Cosmos.Compras.Entidades.Municipio o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Municipio_Consultar", o.MunicipioID);
            o = new Cosmos.Compras.Entidades.Municipio();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Municipio Guardar(int modificacionUsuarioID, int municipioID, string municipioClave, string nombre, string nombreCorto, int estadoID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID, MunicipioClave = municipioClave, Nombre = nombre, NombreCorto = nombreCorto, EstadoID = estadoID  });
        }
        
        public static Cosmos.Compras.Entidades.Municipio Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Municipio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Municipio_Guardar", modificacionUsuarioID, o.MunicipioID, o.MunicipioClave, o.Nombre, o.NombreCorto, o.EstadoID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["MunicipioID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int municipioID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Municipio() { MunicipioID = municipioID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Municipio o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Municipio_Eliminar", modificacionUsuarioID, o.MunicipioID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }
        
       
        
        #endregion
        
       
    }
}
