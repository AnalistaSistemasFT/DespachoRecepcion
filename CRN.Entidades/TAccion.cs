using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class TAccion
    {
        private int iaccion_id;
        private string saccion_Desc;
        private int iresponsable_id;
        private string dtfecha_plazo;
        private int sestado_id;
        private string dtfecha_cierre;
        private int inoconformidad_id;

        public int IAccion_Id 
        {
            get { return iaccion_id; }
            set { iaccion_id = value; }        
        }
        public string SAccion_Desc 
        {
            get { return saccion_Desc; }
            set { saccion_Desc = value; }        
        }
        public int IResponsable_ID 
        {
            get { return iresponsable_id; }
            set { iresponsable_id = value; }        
        }
        public string DTfecha_plazo 
        {
            get { return dtfecha_plazo; }
            set { dtfecha_plazo = value; }        
        }
        public int INoconformidad_Id 
        {
            get { return inoconformidad_id; }
            set { inoconformidad_id = value; }        
        }
        public int EstadoId
        { 
            get {return sestado_id;}
            set { sestado_id = value; }
        
        }
        public string DTfecha_cierre
        {
            get { return dtfecha_cierre; }
            set { dtfecha_cierre = value; }
        }

    }
}
