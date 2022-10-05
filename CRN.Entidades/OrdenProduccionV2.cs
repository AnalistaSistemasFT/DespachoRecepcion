using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class OrdenProduccionV2
    {

        public int Icorrelativo { get; set; }
        public string orden { get; set; }
        public string grupoProd { get; set; }
        public string sistemId { get; set; }
        public string cantidad { get; set; }
        public string sUm { get; set; }
        public string fechaReg { get; set; }
        public string fechaentr { get; set; }
        public string tipo { get; set;}
        public string fabrica { get; set; }
        public string centrotrabajo { get; set;}
        public string descripcion { get; set;}
        public string status { get; set; }
    }
}
