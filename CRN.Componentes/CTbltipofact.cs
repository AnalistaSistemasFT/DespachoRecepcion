using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CTbltipofact : oledb
    {
        public CTbltipofact()
        {
            this.sConnName = "SQLSERVER2";
        }
        public DataSet TraerTipoFactu(int _idSucursal)
        {
            string sSelect = "select tipodoctras from tbltipofac where isucursal_id = " + _idSucursal;
            return this.consultar(sSelect);
        }
    }
}
