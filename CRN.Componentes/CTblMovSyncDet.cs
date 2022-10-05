using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CTblMovSyncDet
    {
        public int OrdenId { get; set; }
        public string itemPv { get; set; }
        public string itemF { get; set; }
        public int piezas { get; set; }
        public int peso { get; set; }
        public int metros { get; set; }
        public int costounitario { get; set; }
        public int precioTon { get; set; }
        public string calidad { get; set; }
        public int cantidad { get; set; }
        public string unidad { get; set; }
        public int tipomovimiento { get; set; }
        public int porcdistribucion { get; set; }
    }
}
