using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CParametros
    {
        CADParametros catParam = new CADParametros();
        public DataSet retornarTabla(string consulta)
        {
            return catParam.EjecutarConsult(consulta);
        }

        public void GuardarParam(CadParametros ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                catParam.GuardarParametros(ensayo);
                ts.Complete();
            }
        }
    }
}
