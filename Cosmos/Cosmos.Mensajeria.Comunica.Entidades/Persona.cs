
using System;
using System.Data;
using System.Collections.Generic;
using Cosmos.Framework;

namespace Cosmos.Mensajeria.Comunica.Entidades
{
    public class Persona : Cosmos.Seguridad.Entidades.Usuario
    {
        //public PermisoConversacion Permiso { get; set; }

        public new void Load(DataRow dr)
        {
            if (dr != null)
            {

                base.Load(dr);

                //Cosmos.Mensajeria.Comunica.Entidades.PermisoConversacion o = new Cosmos.Mensajeria.Comunica.Entidades.PermisoConversacion();
                //o.Load(dr);
                //Permiso = o;


            }
        }

    }
}
