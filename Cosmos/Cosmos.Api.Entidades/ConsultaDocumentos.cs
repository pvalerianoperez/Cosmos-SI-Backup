using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Api.Entidades
{
    public class ConsultaDocumentos
    {
        public int EmpresaID { get; set; }
        public int SucursalID { get; set; }
        public int[] TipoDocumentoID { get; set; }
        public int[] EstatusDocumentoID { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool IncluirPendientes { get; set; }
        public bool IncluirTerminados { get; set; }
    }
}
