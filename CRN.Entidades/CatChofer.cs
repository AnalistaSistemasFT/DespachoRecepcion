using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CatChofer
    {
        private string CI;
        private string Nombre;
        private string Procedencia;

        public string ci
        {
            get { return CI; }
            set { CI = value; }
        }
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public string procedencia
        {
            get { return Procedencia; }
            set { Procedencia = value; }
        }
    }
}
