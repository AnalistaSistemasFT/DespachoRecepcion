using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ClientesInformix
    {
        private int IdClienteInf;
        private string NombreInf;

        public int p_IdClienteInf
        {
            get { return IdClienteInf; }
            set { IdClienteInf = value; }
        }
        public string p_NombreInf
        {
            get { return NombreInf; }
            set { NombreInf = value; }
        }
    }
}
