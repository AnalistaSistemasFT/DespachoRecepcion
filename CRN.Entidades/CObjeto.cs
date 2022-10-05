using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CObjeto
    {
        private int idObjeto;
        private string NObjeto;

        public int ObjetoID
        {
            get { return idObjeto; }
            set {idObjeto = value; }
        }

        public string NombreO
        {
            get { return NObjeto; }
            set { NObjeto = value; }
        }
    }
}
