using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ListaNroOrdenInf
    {
        private string id;
        private int cant;

        public string _id
        {
            get { return id; }
            set { id = value; }
        }
        public int _cant
        {
            get { return cant; }
            set { cant = value; }
        }
    }
}
