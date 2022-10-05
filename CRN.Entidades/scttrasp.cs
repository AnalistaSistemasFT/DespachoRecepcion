using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class scttrasp
    {
        private decimal sctttdoc;
        private decimal scttndoc;
        private decimal sctiptra;
        private DateTime scttfdoc;
        private DateTime scttfreg;
        private decimal scttsuce;
        private decimal scttsucr;
        private string scttdesc;

        public decimal p_sctttdoc
        {
            get { return sctttdoc; }
            set { sctttdoc = value; }
        }
        public decimal p_scttndoc
        {
            get { return scttndoc; }
            set { scttndoc = value; }
        }
        public decimal p_sctiptra
        {
            get { return sctiptra; }
            set { sctiptra = value; }
        }
        public DateTime p_scttfdoc
        {
            get { return scttfdoc; }
            set { scttfdoc = value; }
        }
        public DateTime p_scttfreg
        {
            get { return scttfreg; }
            set { scttfreg = value; }
        }
        public decimal p_scttsuce
        {
            get { return scttsuce; }
            set { scttsuce = value; }
        }
        public decimal p_scttsucr
        {
            get { return scttsucr; }
            set { scttsucr = value; }
        }
        public string p_scttdesc
        {
            get { return scttdesc; }
            set { scttdesc = value; }
        }
    }
}
