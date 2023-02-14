using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmos.Api.Entidades
{
    public class RespuestaBase
    {
        public String SesionID { get; set; }
        public int UsuarioID { get; set; }
        public bool Exitoso { get; set; }
        public int CodigoRespuesta { get; set; }
        public String MensajeRespuesta { get; set; }
        public int CodigoError { get; set; }
        public String MensajeError { get; set; }
        public Object Datos { get; set; }
        public List<ParametroApi> Parametros { get; set; }

    }
}