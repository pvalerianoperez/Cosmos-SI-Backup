using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Seguridad.Entidades
{
   
    public class OpcionListado : Opcion
    {
        public string Migaja { get; set; }
        public List<string> AccionesDisponibles { get; set; }
        public List<string> AccionesPermitidas { get; set; }
    }
}
