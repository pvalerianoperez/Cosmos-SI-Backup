using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;




namespace Cosmos.Mensajeria.Comunica.Negocio
{
    public class DeviceToken
    {


        #region CRUD

        public static List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> Listado()
        {
            List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken> lst = new List<Cosmos.Mensajeria.Comunica.Entidades.DeviceToken>();
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_DeviceToken_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o = new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken();
                    o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Consultar(int deviceTokenID)
        {
            return Consultar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken() { DeviceTokenID = deviceTokenID });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Consultar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            //consulta la base de datos
            DataTable dt = SQLHelper.GetTable("Mensajeria_Comunica_DeviceToken_Consultar", o.DeviceTokenID);
            o = new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken();
            if (dt != null && dt.Rows.Count > 0)
            {
                o.Load(dt.Rows[0]);
            }
            return o;
        }

        public int DeviceTokenID { get; set; }
        public string Token { get; set; }
        public string OS { get; set; }
        public string VersionOS { get; set; }
        public string VersionApp { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Guardar(int deviceTokenID, string deviceToken, string os, string versionOS, string versionApp, string descripcion, DateTime fechaRegistro)
        {
            return Guardar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken()
            {
                DeviceTokenID = deviceTokenID,
                Token = deviceToken,
                OS = os,
                VersionOS = versionOS,
                VersionApp = versionApp,
                Descripcion = descripcion,
                FechaRegistro = fechaRegistro
            });
        }

        public static Cosmos.Mensajeria.Comunica.Entidades.DeviceToken Guardar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_DeviceToken_Guardar", o.DeviceTokenID,
                                                                                          o.Token,
                                                                                          o.OS,
                                                                                          o.VersionOS,
                                                                                          o.VersionApp,
                                                                                          o.Descripcion,
                                                                                          o.FechaRegistro);
            if (!SQLHelper.ErrorRespuestaSQL(dr))
            {
                o = Consultar((int)dr["DeviceTokenID"]);
            }
            return o;
        }

        public static bool Eliminar(int deviceTokenID)
        {
            return Eliminar(new Cosmos.Mensajeria.Comunica.Entidades.DeviceToken() { DeviceTokenID = deviceTokenID });
        }

        public static bool Eliminar(Cosmos.Mensajeria.Comunica.Entidades.DeviceToken o)
        {
            //consulta la base de datos
            DataRow dr = SQLHelper.GetFirstRow("Mensajeria_Comunica_DeviceToken_Eliminar", o.DeviceTokenID);
            return SQLHelper.ErrorRespuestaSQL(dr);
        }

        #endregion

    }
}
