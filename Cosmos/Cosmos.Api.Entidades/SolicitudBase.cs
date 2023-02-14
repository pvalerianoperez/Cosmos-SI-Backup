using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmos.Api.Entidades
{
    public class SolicitudBase
    {
        public int UsuarioID { get; set; }
        public int EmpresaID { get; set; }
        public String SesionID { get; set; }
        public object Datos { get; set; }
        public List<ParametroApi> Parametros{ get; set; }

    }
}