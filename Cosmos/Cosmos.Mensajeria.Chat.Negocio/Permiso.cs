
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;


namespace Cosmos.Mensajeria.Chat.Negocio
{
    public class Permiso
    {
        public static List<Cosmos.Mensajeria.Chat.Entidades.Permiso> Listado()
        {
            List<Cosmos.Mensajeria.Chat.Entidades.Permiso> lst = new List<Cosmos.Mensajeria.Chat.Entidades.Permiso>();
            DataTable dt = SQLHelper.GetTable("Seguridad_Modulo_Listado");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cosmos.Mensajeria.Chat.Entidades.Permiso o = new Cosmos.Mensajeria.Chat.Entidades.Permiso();
                    //o.Load(dr);
                    lst.Add(o);
                }
            }
            return lst;
        }



    }
}
