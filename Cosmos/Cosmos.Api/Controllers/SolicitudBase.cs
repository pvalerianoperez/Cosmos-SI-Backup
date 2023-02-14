using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmos.Api.Controllers
{
    public class SolicitudBase
    {
        public int UsuarioID { get; set; }
        public String SesionID { get; set; }
        public object Datos { get; set; }

    }
}