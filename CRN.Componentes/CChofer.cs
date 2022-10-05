using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CChofer : oledb
    {
        public CChofer()
        {
            this.sConnName = "SQLSERVER";
        }

        public DataSet SeleccionarChofer()
        {
            string sInsert = @"select ci,Nombre,Procedencia from [tblCatChofer] order by  Nombre asc";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
    }
}
