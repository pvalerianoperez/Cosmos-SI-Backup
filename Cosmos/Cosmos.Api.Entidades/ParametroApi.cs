using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Api.Entidades
{
    public class ParametroApi
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public ParametroApi() {
        }
        public ParametroApi(string nombre, string valor){
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
