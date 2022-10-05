using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public  class Sector
    {
        private int id_sector;
        private string id_centro;
        private int id_parametro;
        private int id_parametro1;
        private int id_parametro2;

        public int Id_Sector 
        {
            get { return id_sector; }
            set { id_sector = value; }        
        }
        public string Id_Centro
        {
            get { return id_centro; }
            set { id_centro = value; }
        }
        public int Id_Parametro
        {
            get { return id_parametro; }
            set { id_parametro = value; }
        }
        public int Id_Parametro1
        {
            get { return id_parametro1; }
            set { id_parametro1 = value; }
        }
        public int Id_Parametro2
        {
            get { return id_parametro2; }
            set { id_parametro2 = value; }
        }
    }
}
