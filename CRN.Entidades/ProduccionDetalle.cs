using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ProduccionDetalle
    {

        public string ordenid { get; set; }
        public string paqueteid { get; set; }
        public string itemid { get; set; }
        public string descitem { get; set; }
        public decimal peso { get; set; }
        public decimal piezas { get; set; }
        public decimal metros { get; set; }
        public string unidadmedida { get; set; }
        public string estado { get; set; }
        public string operador { get; set; }
        public string fechainicial { get; set; }
        public string fechafinal { get; set; }
        public string turno { get; set; }
        public string tipo { get; set; }

    }
}
