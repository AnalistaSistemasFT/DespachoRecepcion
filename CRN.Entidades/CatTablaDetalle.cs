using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CatTablaDetalle
    {
        private int tablaId;
        private decimal nominal;
        private decimal minimo;
        private decimal maximo;

        public int Tablaid 
        {
            get { return tablaId; }
            set { tablaId = value; }        
        }
        public decimal Nominal
        {
            get { return nominal; }
            set { nominal = value; }
        }
        public decimal Min
        {
            get { return minimo; }
            set { minimo = value; }
        }
        public decimal Max
        {
            get { return maximo; }
            set { maximo = value; }
        }
    }
}
