using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
   
   public  class CItemF
    {
        CAItemF itemf = new CAItemF();

        public DataSet TraerItemF(int Item)
        {
            return itemf.Traeritem(Item);
        }
    }
}
