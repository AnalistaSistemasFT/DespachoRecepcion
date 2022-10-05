using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADInformix : oledb
    {
        public CADInformix()
        {
            this.sConnName = "FTINF";
        }
        public DataSet TraerTodosClientes()
        {
            string consulta = "select scclccli, scclnomb from scmaecli";
            return this.consultar(consulta);
        }
        public DataSet TraerDescProducto()
        {
            string consulta = "select scmanart, scmadesc from scmaster";
            return this.consultar(consulta);
        }
    }
}
