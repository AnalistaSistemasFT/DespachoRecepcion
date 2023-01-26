using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class scentreg_inf
    {
        private decimal sctitdoc;
        private decimal sctindoc;
        private decimal sctictra;
        private DateTime sctifdoc;
        private DateTime sctifreg;
        private decimal scticsuc;
        private string sctidevo;
        private string schraent;
        private decimal sctipdoc;
        private decimal scnrodoc;

        public decimal p_sctitdoc
        {
            get { return sctitdoc; }
            set { sctitdoc = value; }
        }
        public decimal p_sctindoc
        {
            get { return sctindoc; }
            set { sctindoc = value; }
        }
        public decimal p_sctictra
        {
            get { return sctictra; }
            set { sctictra = value; }
        }
        public DateTime p_sctifdoc
        {
            get { return sctifdoc; }
            set { sctifdoc = value; }
        }
        public DateTime p_sctifreg
        {
            get { return sctifreg; }
            set { sctifreg = value; }
        }
        public decimal p_scticsuc
        {
            get { return scticsuc; }
            set { scticsuc = value; }
        }
        public string p_sctidevo
        {
            get { return sctidevo; }
            set { sctidevo = value; }
        }
        public string p_schraent
        {
            get { return schraent; }
            set { schraent = value; }
        }
        public decimal p_sctipdoc
        {
            get { return sctipdoc; }
            set { sctipdoc = value; }
        }
        public decimal p_scnrodoc
        {
            get { return scnrodoc; }
            set { scnrodoc = value; }
        }
    }
}
