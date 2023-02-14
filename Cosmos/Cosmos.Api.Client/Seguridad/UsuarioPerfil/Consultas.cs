using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Api.Entidades;
using Newtonsoft.Json;

namespace Cosmos.Api.Client.Seguridad
{
    public partial class UsuarioPerfil
    {
        public static List<Cosmos.Entidades.Seguridad.UsuarioPerfil> PerfilesUsuario(int usuarioID)
        {

            return Usuario.ListadoPerfiles(usuarioID);
        }
    }
}
