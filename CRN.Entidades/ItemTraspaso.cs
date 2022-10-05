using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ItemTraspaso
    {
        private string Articulo;
        private string Descripcion;
        private int Cantidad;
        private decimal Costo;

        public string p_Articulo
        {
            get { return Articulo; }
            set { Articulo = value; }
        }
        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public int p_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public decimal p_Costo
        {
            get { return Costo; }
            set { Costo = value; }
        }
    }
}
