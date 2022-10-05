using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class SucursalElegir
    {
        private int sccodfin;
        private string sctcdesc;
        public int p_sccodfin
        {
            get { return sccodfin; }
            set { sccodfin = value; }
        }

        public string p_sctcdesc
        {
            get { return sctcdesc; }
            set { sctcdesc = value; }
        }
    }
}
