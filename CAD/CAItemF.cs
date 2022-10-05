using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CAItemF:oledb
    {
        public CAItemF()
        {
            this.sConnName = "FTINF";
        }

        public DataSet Traeritem(int Item)
        {
            string sError = string.Empty;
            string sInsert = @"select * from scmaster  where scmanart = {0}";
            sInsert = string.Format(sInsert, Item);
            return consultar(sInsert);

        }
    }
}
