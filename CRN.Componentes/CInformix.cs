using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CInformix
    {
        CADInformix _cadInformix = new CADInformix();
        public DataSet TraerTodosClientes()
        {
            return _cadInformix.TraerTodosClientes();
        }
        public DataSet TraerDescProducto()
        {
            return _cadInformix.TraerDescProducto();
        }
    }
}
