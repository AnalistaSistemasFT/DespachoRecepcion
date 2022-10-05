using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consumo
    {
        public string Orden { get; set; }
        public string PaqProducido { get; set; }
        public string PaqConsumido { get; set; }
        public string Item { get; set; }
        public string Ax_Item { get; set; }
        public decimal Peso { get; set; }
        public string Colada { get; set; }
        public string NumSerie { get; set; }
    }
}
