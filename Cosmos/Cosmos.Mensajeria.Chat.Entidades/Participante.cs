
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Chat.Entidades
{
    public class Participante : Cosmos.Seguridad.Entidades.Usuario
    {
        public PermisoConversacion Permiso { get; set; }

        public new void Load(DataRow dr)
        {
            if (dr != null)
            {

                base.Load(dr);

                Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion o = new Cosmos.Mensajeria.Chat.Entidades.PermisoConversacion();
                o.Load(dr);
                Permiso = o;


            }
        }

    }
}
