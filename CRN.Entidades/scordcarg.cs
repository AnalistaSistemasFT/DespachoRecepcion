using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class scordcarg
    {
        private int ordcargnro;
        private string ordcargsuc;
        private DateTime ordcargfec;
        private string ordcarghro;
        private int ordcargcam;
        private int ordcargcho;
        private decimal ordcargcno;
        private int ordcargeen;
        private int ordcargest;
        private string ordcarobs;

        public int p_ordcargnro
        {
            get { return ordcargnro; }
            set { ordcargnro = value; }
        }
        public string p_ordcargsuc
        {
            get { return ordcargsuc; }
            set { ordcargsuc = value; }
        }
        public DateTime p_ordcargfec
        {
            get { return ordcargfec; }
            set { ordcargfec = value; }
        }
        public string p_ordcarghro
        {
            get { return ordcarghro; }
            set { ordcarghro = value; }
        }
        public int p_ordcargcam
        {
            get { return ordcargcam; }
            set { ordcargcam = value; }
        }
        public int p_ordcargcho
        {
            get { return ordcargcho; }
            set { ordcargcho = value; }
        }
        public decimal p_ordcargcno
        {
            get { return ordcargcno; }
            set { ordcargcno = value; }
        }
        public int p_ordcargeen
        {
            get { return ordcargeen; }
            set { ordcargeen = value; }
        }
        public int p_ordcargest
        {
            get { return ordcargest; }
            set { ordcargest = value; }
        }
        public string p_ordcarobs
        {
            get { return ordcarobs; }
            set { ordcarobs = value; }
        }
    }
}
