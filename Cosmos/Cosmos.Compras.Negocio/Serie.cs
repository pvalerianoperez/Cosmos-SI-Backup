
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Compras.Negocio
{
    public partial class Serie
    {

        #region CRUD
        public static List<Cosmos.Compras.Entidades.Serie> Listado(int empresaID)
        {
            return Listado(new Cosmos.Compras.Entidades.Sucursal() { EmpresaID = empresaID});
        }

        public static List<Cosmos.Compras.Entidades.Serie> Listado(Cosmos.Compras.Entidades.Sucursal entidad) {            
            List<Cosmos.Compras.Entidades.Serie> lst = new List<Cosmos.Compras.Entidades.Serie>();            
            DataTable dt = SQLHelper.GetTable("Compras_Serie_Listado", entidad.EmpresaID);
            if (dt != null) {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Serie o = new Cosmos.Compras.Entidades.Serie();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }        
        
        public static Cosmos.Compras.Entidades.Serie Consultar(int serieID) {
            return Consultar(new Cosmos.Compras.Entidades.Serie() { SerieID = serieID  });
        }
        
        public static Cosmos.Compras.Entidades.Serie Consultar(Cosmos.Compras.Entidades.Serie o) {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Compras_Serie_Consultar", o.SerieID);
            o = new Cosmos.Compras.Entidades.Serie();
            if (dt != null && dt.Rows.Count>0)
            {            
                o.Load(dt.Rows[0]);
            }
            return o;
        }  
        
        public static Cosmos.Compras.Entidades.Serie Guardar(int modificacionUsuarioID, int serieID, int tipoDocumentoID, string serieClave, int folioInicial, int folioFinal, int ultimoFolio, bool estatus, bool predeterminado, int sucursalID) {
            return Guardar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Serie() { SerieID = serieID, TipoDocumentoID = tipoDocumentoID, SerieClave = serieClave, FolioInicial = folioInicial, FolioFinal = folioFinal, UltimoFolio = ultimoFolio, Estatus = estatus, Predeterminado = predeterminado, SucursalID = sucursalID  });
        }
        
        public static Cosmos.Compras.Entidades.Serie Guardar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Serie o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Serie_Guardar", modificacionUsuarioID, o.SerieID, o.TipoDocumentoID, o.SerieClave, o.FolioInicial, o.FolioFinal, o.UltimoFolio, o.Estatus, o.Predeterminado, o.SucursalID);
            if (!SQLHelper.ErrorRespuestaSQL(dr)) {            
                o =  Consultar((int)dr["SerieID"]);
            }
            return o;
        }
        
        public static bool Eliminar(int modificacionUsuarioID, int serieID) {
            return Eliminar(modificacionUsuarioID, new Cosmos.Compras.Entidades.Serie() { SerieID = serieID  });
        }
        
        public static bool Eliminar(int modificacionUsuarioID, Cosmos.Compras.Entidades.Serie o) {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Compras_Serie_Eliminar", modificacionUsuarioID, o.SerieID);
            return !SQLHelper.ErrorRespuestaSQL(dr);
        }



        #endregion

        public static List<Cosmos.Compras.Entidades.Serie> ListadoSerieRequisiciones()
        {
            List<Cosmos.Compras.Entidades.Serie> lst = new List<Cosmos.Compras.Entidades.Serie>();
            DataTable dt = SQLHelper.GetTable("Compras_Serie_ListadoSerieRequisiciones");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Serie o = new Cosmos.Compras.Entidades.Serie();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static List<Cosmos.Compras.Entidades.Serie> ListadoSerieTipoDocumento(int tipoDocumentoID, int sucursalID)
        {
            List<Cosmos.Compras.Entidades.Serie> lst = new List<Cosmos.Compras.Entidades.Serie>();
            DataTable dt = SQLHelper.GetTable("Compras_Serie_ListadoSerieTipoDocumento", tipoDocumentoID, sucursalID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Compras.Entidades.Serie o = new Cosmos.Compras.Entidades.Serie();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }
    }
}
