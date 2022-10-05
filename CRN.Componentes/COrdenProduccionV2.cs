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
    public class COrdenProduccionV2
    {
        CADOrdenProduccionV2 ord = new CADOrdenProduccionV2();
        public DataSet retornarTabla(string consulta)
        {
            return ord.RetornarOrdenP(consulta);
        }

        public void GuardarTablaNuevo(OrdenProduccionV2 opp)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ord.GuardarOrdenProduccionV2(opp);
                ts.Complete();
            }
        }
        public bool EjecutarSentenciasU(string consulta) 
        {
            int res = ord.EjecutarSentencias(consulta);
            if (res == 1)
                return true;
            else
                return false;        
        }
    }
}
