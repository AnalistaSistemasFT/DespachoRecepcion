using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Orden
    {
        public Orden()
        {
            //ProducidoList = new List<Paquete>();
            ConsumidoList = new List<Paquete>();
            ConsumidoPartList = new List<Consumo>();
        }
        public string OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public List<Paquete> ProducidoList { get; set; }
        public List<Paquete> ConsumidoList { get; set; }
        public List<Consumo> ConsumidoPartList { get; set; }
    }
}
