using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CTblMovSync
    {
        public int OrdenId { get; set; }
        public string fecha { get; set; }
        public string centrotrabajo { get; set; }
        public string status { get; set; }
        public string tipoOrden { get; set; }
        public int sucursalid { get; set; }
        public int sucursaldestino { get; set; }
        public string ordenligado { get; set; }
        public string itemflijado { get; set; }
        public int esdecliente { get; set; }
    }
}
