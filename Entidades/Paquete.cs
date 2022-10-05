using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {
        public string PaqueteId { get; set; }
        public string Item { get; set; }
        public int Piezas { get; set; }
        public decimal Peso { get; set; }
        public decimal Stock { get; set; }
        public string Ax_Item { get; set; }
        public string Unidad { get; set; }
        public string Colada{ get; set; }
        public string NumSerie { get; set; }
        public string Centro { get; set; }
        public string Machine { get; set; }
        public string Issue { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoPaquete { get; set; }
        public string Status { get; set; }
    }
}
