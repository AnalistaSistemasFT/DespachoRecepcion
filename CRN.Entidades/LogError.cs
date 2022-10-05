using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class LogError
    {
        private string CodigoError;
        private string Descripcion;
        private string Usuario;

        public string p_CodigoError
        {
            get { return CodigoError; }
            set { CodigoError = value; }
        }
        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public string p_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
    }
}
